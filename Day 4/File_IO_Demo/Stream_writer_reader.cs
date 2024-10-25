using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO_Demo
{
    internal class Stream_writer_reader
    {
        public void WriteAndRead()
        {
            string filepath = "C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\Test.txt";

            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine("Sample content from console Application....");
            }
            using (StreamReader reader = new StreamReader(filepath))
            {
                string contentReadFromFile = reader.ReadToEnd();
                Console.WriteLine(contentReadFromFile);
            }
        }
    }
}
