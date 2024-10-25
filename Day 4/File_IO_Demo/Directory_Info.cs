using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO_Demo
{
    internal class Directory_Info
    {
        public void Demo()
        {
            string sourcePath = "C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\SampleSource";
            string destinationPath = "C:\\Users\\Admin\\Desktop\\Hexa Training\\Domain Specific\\Git\\Day 4\\SampleDestination";

            DirectoryInfo sdi = new DirectoryInfo(sourcePath);
            Console.WriteLine(sdi);
            DirectoryInfo ddi = new DirectoryInfo(destinationPath);
            Console.WriteLine(ddi);

            //foreach(DirectoryInfo directoryInfo in sdi.GetDirectories())
            //{
            //    Console.WriteLine($"{directoryInfo.FullName} \n");
            //    foreach( FileInfo fileInfo in directoryInfo.GetFiles())
            //    {
            //        Console.WriteLine($"{fileInfo.FullName}");
            //    }
            //}

            foreach(FileInfo fi in sdi.GetFiles())
            {
                fi.CopyTo(Path.Combine(ddi.FullName, fi.Name), true);
                Console.WriteLine($"Copying the {ddi.FullName} {fi.Name}");
            }

            foreach(DirectoryInfo directoryInfo in sdi.GetDirectories())
            {
                DirectoryInfo destinationSubDir = ddi.CreateSubdirectory(directoryInfo.Name);
                foreach(FileInfo file in directoryInfo.GetFiles())
                {
                    file.CopyTo(Path.Combine(destinationSubDir.FullName, file.Name), true);
                    Console.WriteLine($"Cppying {destinationSubDir.Name}, {file.Name}");
                }
            }
        }
    }
}
