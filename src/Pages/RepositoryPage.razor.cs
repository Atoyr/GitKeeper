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
using Microsoft.AspNetCore.Components.Web.Virtualization;
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

        protected IEnumerable<CommitInfo> Commits { get; set; }

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

        // protected async ValueTask<ItemsProviderResult<CommitInfo>> GenerateCommitInfosProvider(ItemsProviderRequest request)
        // {
        //     Console.WriteLine($"StartIndex: {request.StartIndex}, Count: {request.Count}");
        //     // このメソッドで読み込む必要のあるデータ件数

        //     // データを読み込んで返す
        //     var data = await GenerateCommitInfosAsync(this.Repository.Head.Commits, this.Repository.Branches);
        //     // var data = CommitInfo.GenerateCommitInfos(this.Repository.Head.Commits, this.Repository.Branches, request.StartIndex, numCommits);

        //     return new ItemsProviderResult<CommitInfo>(data.Skip(request.StartIndex).Take(request.Count), data.Count());
        // }

        protected Task<IEnumerable<CommitInfo>> GenerateCommitInfosAsync(IEnumerable<Commit> commits, BranchCollection branches)
        {
            return Task.Run(() => CommitInfo.GenerateCommitInfos(commits, branches));
        }
    }
}

