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

        protected LibGit2Sharp.Repository Repository { get; set; }

        protected List<CommitInfo> Commits { get; set; }

        protected override void OnInitialized()
        {
            var repositoryInfo = Repositories.GetRepository(ID);
            this.Repository = new LibGit2Sharp.Repository(repositoryInfo.Path);

            Commits = new List<CommitInfo>();
            foreach( var commit in this.Repository.Head.Commits)
            {
                Commits.Add(new CommitInfo(commit,this.Repository.Branches));
            }
        }


    }
}

