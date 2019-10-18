using System;
using LibGit2Sharp;
using MostModifiedFiles.Utilities;

namespace MostModifiedFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            IVcs vcs = null;

            Console.Clear();
            Console.WriteLine("1. Git\n" +
                              "2. SVN");
            switch (Console.ReadLine())
            {
                case "1":
                    vcs = CreateGit();
                    new Printer(new Grouper().GroupList(vcs.Log())).PrintMostModifiedFiles();
                    break;
//                     for SVN
//                    case "2": 
//                        break;
            }
        }

        // Можно было и в конструкторе, не знаю где правильнее.
        private static Git CreateGit()
        {
            Console.Write("Input\n" +
                          "Github login: ");
            var login = Console.ReadLine();
            Console.Write("Github password: ");
            var pass = Console.ReadLine();
            Console.WriteLine("Input repository url \n" +
                              "For example(https://github.com/ILeshkevuch/test.git)");
            var url = Console.ReadLine();
            var path = Environment.CurrentDirectory + "\\Repo";
            var git = new Git(path, login, pass, url);
            git.Clone();
            return git;
        }
    }
}