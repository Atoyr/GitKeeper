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

        public static IEnumerable<CommitInfo> GenerateCommitInfos(IEnumerable<Commit> commits, BranchCollection branches)
        {
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
                yield return ci;
            }
        }

        public static IEnumerable<CommitInfo> GenerateCommitInfos(IEnumerable<Commit> commits, BranchCollection branches, int skip, int take)
        {
            var start = skip - 1;
            if (start < 0) start = 0;
            var max = Math.Min(skip + take, commits.Count());
            if (max < 0) max = commits.Count();
            for(int i = start; i < max; i++)
            {
                var ci = new CommitInfo(commits.ElementAt(i));
                yield return ci;
            }
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

