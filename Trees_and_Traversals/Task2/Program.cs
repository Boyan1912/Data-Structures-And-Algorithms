namespace Task2
{
    using System;
    using System.IO;

    class Program
    {
        //Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe.Use the class System.IO.Directory.
        
        static void Main()
        {
            string sourcePath = "C:\\WINDOWS";
            TraverseDirectory(sourcePath);
        }

        static void TraverseDirectory(string dirPath)
        {
            try
            {
                var exeFiles = Directory.EnumerateFiles(dirPath, "*.exe");
                foreach (string fileName in exeFiles)
                {
                    Console.WriteLine(fileName);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var directories = Directory.EnumerateDirectories(dirPath);
                foreach (string dir in directories)
                {
                    TraverseDirectory(dir);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
