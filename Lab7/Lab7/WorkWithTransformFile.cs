using System;

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
            TransformFile tf = new TransformFile();
            tf.ReadFromFileToTransform(filePath, out textForOldFile, out textForNewFile);
            tf.WriteToFileAfterTransform(filePath, textForOldFile);
            tf.WriteToFileAfterTransform(filePathNew, textForNewFile);
        }
        catch
        {
            Console.WriteLine("Файла источника не существует!");
        }   
    }
}
}
