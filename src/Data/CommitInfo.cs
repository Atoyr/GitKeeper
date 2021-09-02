using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace GitKeeper.Data
{
    public class CommitInfo
    {
        public string Message { get; private set; }
        public string MessageShort { get; private set; }
        public string Author { get; private set; }
        public string Sha { get; private set; }
        public string ShaShort { get => Sha.Substring(0,6); }
        public string ParentSha { get; private set; }
        public DateTime DateTime { get; private set; }
        public List<Branch> Branches { get; set; }
        public bool BranchHead { get; set; }


        private CommitInfo()
        {
            OnInitialized();
        }

        public CommitInfo(Commit commit, BranchCollection branches)
        {
            OnInitialized();
            Message = commit.Message;
            MessageShort = commit.MessageShort;
            Author = commit.Author.Name;
            Sha = commit.Sha;
            ParentSha = commit.Parents.FirstOrDefault()?.Sha;
            DateTime = commit.Author.When.DateTime;
            Branches = new List<Branch>();

            foreach(var b in branches)
            {
                if (!b.Commits.Any(c => c.Sha == this.Sha))
                {
                    continue;
                }
                Branches.Add(b);


                // if (!commits.Any())
                // {
                //     continue;
                // }
            }
        }

        protected void OnInitialized()
        {
        }

        public bool HasParent()
        {
            return string.IsNullOrEmpty(ParentSha);
        }
    }
}

