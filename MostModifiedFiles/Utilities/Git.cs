using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LibGit2Sharp;

namespace MostModifiedFiles.Utilities
{
    public class Git : IVcs
    {
        private readonly string path;
        private readonly string login;
        private readonly string pass;
        private readonly string url;
        public Git(string path, string login, string pass, string url)
        {
            this.path = path;
            this.login = login;
            this.pass = pass;
            this.url = url;
        }

        public void Clone()
        {
            try
            {
                var co = new CloneOptions
                {
                    CredentialsProvider = (url1, user, cred) => new UsernamePasswordCredentials
                    {
                        Username = login, Password = pass,
                    },
                };
                Console.WriteLine("Cloning...");
                Repository.Clone(url, path, co);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        
        public List<string> Log()
        {
            var files = new List<string>();
            try
            {
                using var repo = new Repository(path);
                foreach (var commit in repo.Commits)
                {
                    foreach (var parent in commit.Parents)
                    {
                        files.AddRange(repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree).Select(change => change.Path));
                    }

                    if (files.Count == 0)
                    {
                        files.AddRange(commit.Tree.Select(file => file.Path));
                    }
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

            return files;
        }
    }
}