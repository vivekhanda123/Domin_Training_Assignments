using System.Text;
namespace File_IO_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    string path = "C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\Test.txt";
            //    string path1 = @"C:\Users\Admin\Desktop\Hexa Training\Domain Specific\Git\Day 4\Test.txt";
            //    if (File.Exists(path))
            //    {
            //        File.Delete(path);
            //    }
            //    using (FileStream fs = File.Create(path))
            //    {
            //        AddTextinTheFile(fs, "Hello!...");
            //        Console.WriteLine("Enter the content to write in the file");
            //        string content = Console.ReadLine();
            //        AddTextinTheFile(fs, content);
            //        //AddTextinTheFile(fs, "\n Welcome to file IO Concept");
            //        //AddTextinTheFile(fs, "\r Welcome to file IO Concept");
            //    }
            //    Console.ReadLine();
            //    static void AddTextinTheFile(FileStream fs, string input)
            //    {
            //        byte[] byteInfo = new UTF32Encoding().GetBytes(input);
            //        fs.Write(byteInfo, 0, byteInfo.Length);
            //    }

            //Directory_Info directory_Info = new Directory_Info();
            //directory_Info.Demo();

            Stream_writer_reader stream_Writer_Reader = new Stream_writer_reader();
            stream_Writer_Reader.WriteAndRead();

            Console.ReadKey();
        }
    }
}
