using System;
using System.IO;

namespace Lab7
{
class WorkWithTransformFile
{
    public void StartWork()
    {
        string filePath = @"d:\Program.cs",
               filePathNew = @"d:\ProgramTransform.cs",
               textForOldFile,
               textForNewFile;
        try
        {
            StreamReader sw = new StreamReader(filePath);
            using (TransformFile tf = new TransformFile(sw))
            {
                tf.ReadFromFileToTransform(out textForOldFile, out textForNewFile);
                tf.WriteToFileAfterTransform(filePath, textForOldFile);
                tf.WriteToFileAfterTransform(filePathNew, textForNewFile);
            }
        }
        catch
        {
            Console.WriteLine("Файла источника не существует!");
        }   
    }
}
}
