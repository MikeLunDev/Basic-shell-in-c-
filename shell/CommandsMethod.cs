using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace shell
{
    class CommandsMethod
    {

        public void MoveToPath(string input)
        {
            string fileName = input.Split(" ")[1];
            string destinationDirectory = input.Split(" ")[2];
            var currDir = Directory.GetCurrentDirectory();
            var fileCurrentSource = Path.Combine(currDir, fileName);
            if (File.Exists(Path.Combine(currDir, fileName)))
                Directory.Move(fileCurrentSource, destinationDirectory);
            else Console.WriteLine("File do not exists");
        }

        public void GetCd()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);

        }

        public void GetDir()
        {

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                FileInfo[] allFiles = dirInfo.GetFiles();
                try
                {

                    DirectoryInfo[] allDirectories = dirInfo.GetDirectories();
                    foreach (var dir in allDirectories)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" {dir.CreationTime} <DIR> {dir.Name} ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("exeption {0}", e);
                }
                foreach (FileInfo file in allFiles)
                {
                    Console.WriteLine();
                    Console.WriteLine($" {file.CreationTime} {file.Length / 1000}KB { file.Name} ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("exeption {0}", e);
            }

        }

        public void GetParentDir()
        {
            try
            {
                DirectoryInfo currDir = new DirectoryInfo(".");

                Directory.SetCurrentDirectory(currDir.Parent.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("exeption {0}", e);

            }
        }

        public void GoToFolderDirectory(string input)
        {
            try
            {
                string target = input.Split(" ")[1];
                var dir = Directory.GetDirectories(Directory.GetCurrentDirectory(), $"{target}", SearchOption.TopDirectoryOnly)[0];
                Directory.SetCurrentDirectory(dir);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Impossible to Reach that path");
                Console.WriteLine("Type dir for avaible path");

            }
        }

        public void DeleteSelectedFile(string input)
        {
            string target = input.Split(" ")[1];
            var currDir = Directory.GetCurrentDirectory();
            try
            {


                if (File.Exists(Path.Combine(currDir, target)))
                {

                    Console.Write($"Are you sure about deleting {target}? (Y/N) ");
                    var dec = Console.ReadLine();
                    if (dec == "Y" | dec == "y")
                    {
                        File.Delete(Path.Combine(currDir, target));
                        Console.WriteLine("File deleted");
                        return;
                    }
                    else return;

                }
                else Console.WriteLine("File not found");
            }
            catch (IOException err)
            {
                Console.WriteLine($"Error {err}");
            }



        }
    }
}
  
    

