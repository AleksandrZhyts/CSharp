
namespace Lab7
{
class Program
{
    static void Main(string[] args)
    {
        var runTask1 = new WorkWithReadWriteFile();
        runTask1.StartWork();
        var runTask2 = new WorkWithTransformFile();
        runTask2.StartWork();
    }
}
}
