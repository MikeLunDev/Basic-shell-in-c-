using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace shell
{
    public class CommandMain
        {

         Dictionary<string, CommandsMethod> myCommands = new Dictionary<string, CommandsMethod>()
        {   //Print current directory
            {"cd", new CommandsMethod{} },
            //Same as cd
            {"pwd", new CommandsMethod{} },
            // Shows all the content of the current working directory
            {"dir", new CommandsMethod{ } },
            //same as dir
            {"ls", new CommandsMethod{ } },
           //goes up in the folder hierarchy
            {"cd ..", new CommandsMethod{ } },
            //goes in the folder name
            {"cd FolderName", new CommandsMethod{ } },
            //delete the file if exist
            {"del Filename", new CommandsMethod{ } },
            //move filename to folder
            {"mv Filename", new CommandsMethod{ } }

        };

        

        public void Run()
            {

            string input;
                Directory.SetCurrentDirectory(@"C:\Users\djmar");
                 while (true)
                {
                string path = Directory.GetCurrentDirectory();
                    Console.Write($"{path}>");
                    input = Console.ReadLine();
                    if (input != "exit" & input != "quit")
                      Execute(input);
                    else break;

                };
            }

            public string Execute(string input)
            {
                if (myCommands.ContainsKey(input) | input.Contains("cd ") | input.Contains("del ") | input.Contains("mv "))
                {

                if (input.Contains("del "))
                    myCommands["del Filename"].DeleteSelectedFile(input);
                else if (input.Contains("mv "))
                    myCommands["mv Filename"].MoveToPath(input);

                else switch (input)
                    {
                        case ("cd"):
                            myCommands[input].GetCd();
                            break;
                        case ("pwd"):
                            myCommands[input].GetCd();
                            break;
                        case ("dir"):
                            myCommands[input].GetDir();
                            break;
                        case ("ls"):
                            myCommands[input].GetDir();
                            break;
                        case ("cd .."):
                            myCommands[input].GetParentDir();
                            break;
                        default:
                            myCommands["cd FolderName"].GoToFolderDirectory(input);
                            break;
                    }

                    return "";


                }
                else
                {
                    Console.WriteLine("command not found");
                    return "";
                }

            }
        }
    
}
