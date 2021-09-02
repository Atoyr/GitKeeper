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

        public static List<CommitInfo> GenerateCommitInfos(IEnumerable<Commit> commits, BranchCollection branches)
        {
            var commitInfos = new List<CommitInfo>();
            var branchList = new List<Branch>();
            foreach(var commit in commits)
            {
                var ci = new CommitInfo(commit);

                foreach(var b in branches)
                {
                    if (branchList.Any(x => x == b)) continue;
                    if (!b.Commits.Any(c => c.Sha == ci.Sha)) continue;

                    if (!b.IsCurrentRepositoryHead)
                    {
                        ci.Branches.Add(b);
                        branchList.Add(b);
                    }
                }
                commitInfos.Add(ci);
            }
            return commitInfos;
        }


        private CommitInfo()
        {
            OnInitialized();
        }

        public CommitInfo(Commit commit)
        {
            OnInitialized();
            Message = commit.Message;
            MessageShort = commit.MessageShort;
            Author = commit.Author.Name;
            Sha = commit.Sha;
            ParentSha = commit.Parents.FirstOrDefault()?.Sha;
            DateTime = commit.Author.When.DateTime;
        }

        protected void OnInitialized()
        {
            Branches = new List<Branch>();
        }

        public bool HasParent()
        {
            return string.IsNullOrEmpty(ParentSha);
        }
    }
}

