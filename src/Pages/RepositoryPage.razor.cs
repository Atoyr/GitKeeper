using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using GitKeeper;
using GitKeeper.Data;
using LibGit2Sharp;


namespace GitKeeper.Pages
{
    public partial class RepositoryPage : ComponentBase
    {
        [Parameter]
        public string ID { get; set; }

        [Inject]
        public RepositoryService Repositories { set; get; }

        [Inject]
        public WindowManagerService windowManagerService { set; get; }

        protected LibGit2Sharp.Repository Repository { get; set; }

        protected List<CommitInfo> Commits { get; set; } = new List<CommitInfo>();

        protected override async Task OnInitializedAsync()
        {
            windowManagerService.IsLoading = true;
            var repositoryInfo = Repositories.GetRepository(ID);
            this.Repository = new LibGit2Sharp.Repository(repositoryInfo.Path);

            Commits = await GenerateCommitInfosAsync(this.Repository.Head.Commits, this.Repository.Branches);

            // foreach( var commit in this.Repository.Head.Commits)
            // {
            //     Commits.Add(new CommitInfo(commit,this.Repository.Branches));
            // }

            windowManagerService.IsLoading = false;
        }

        protected Task<List<CommitInfo>> GenerateCommitInfosAsync(IEnumerable<Commit> commits, BranchCollection branches)
        {
            return Task.Run(() => CommitInfo.GenerateCommitInfos(commits, branches));
        }
    }
}

