using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using System.Text.RegularExpressions;

namespace WhetherViewer
{
public class Viewer
{
    #region field
    Dictionary<string, string> listCity;
    #endregion

    public Viewer(string IniFileName)
    {
        ReadConfigLogs(IniFileName);
    }

    private void ReadConfigLogs(string IniFileName)
    {
        using (FileStream file = new FileStream(IniFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            listCity = new Dictionary<string, string>();
            byte[] readBytes = new byte[(int)file.Length];
            file.Read(readBytes, 0, readBytes.Length);
            string readText = Encoding.Default.GetString(readBytes);
            string[] arrayWords = readText.Split(" \r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrayWords.Length; i += 2)
            {
                try
                {
                    listCity.Add(arrayWords[i], arrayWords[i + 1]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            file.Close();
        }
    }

    public void ShowListCity()
    {
        Console.WriteLine($"{"Code:",8}{"City:",10}");
        foreach (KeyValuePair<string, string> p in listCity)
            Console.WriteLine($"  {p.Key,-10}{p.Value,-20}");
    }

    public void ShowWeather(string codeCity)
    {
        string City;
        if (listCity.TryGetValue(codeCity, out City))
        {
            XPathDocument doc = new XPathDocument("http://informer.gismeteo.by/rss/" + codeCity + ".xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("/rss/channel/item");
            while (iterator.MoveNext())
            {
                XPathNodeIterator it = iterator.Current.Select("title");
                it.MoveNext();
                string manufactured = it.Current.Value;
                it = iterator.Current.Select("description");
                it.MoveNext();
                string model = it.Current.Value;
                Console.WriteLine("{0} {1}", manufactured, model);
            }
        }
        else Console.WriteLine("City with such code is not in the list");
    }

    public void FindWamerstWeather(out string City, out int Temprature)
    {
        City = "";
        Temprature = 0;
        foreach (KeyValuePair<string, string> p in listCity)
        {
            XPathDocument doc = new XPathDocument("http://informer.gismeteo.by/rss/" + p.Key + ".xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("/rss/channel/item");
            while (iterator.MoveNext())
            {
                XPathNodeIterator it = iterator.Current.Select("title");
                it.MoveNext();
                it = iterator.Current.Select("description");
                it.MoveNext();
                string model = it.Current.Value;

                string pattern = @"([-+]+)*\d+[..]+([-+])*\d+";
                Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
                MatchCollection matchCollection = regex.Matches(model);

                string[] listTempreture = (matchCollection[0].Value).Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int currentValueTemp = (Convert.ToInt32(listTempreture[0]) + Convert.ToInt32(listTempreture[1])) / 2;
                if (City.CompareTo("") == 0)
                {
                    City = p.Value;
                    Temprature = currentValueTemp; 
                } 
                else if (Temprature < currentValueTemp)
                {
                    City = p.Value;
                    Temprature = currentValueTemp;
                }  
            }

        }
    }
}
}
