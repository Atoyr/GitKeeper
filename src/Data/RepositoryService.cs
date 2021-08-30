using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using LibGit2Sharp;

namespace GitKeeper.Data
{
  public class RepositoryService
  {
    private List<RepositoryInfo> repositories { set; get; }

    public RepositoryService()
    {
      repositories = new List<RepositoryInfo>();
    }

    public event Action OnAddedRepository;

    public int Count()
    {
      return repositories.Count;
    }

    public void AddRepository(string path)
    {


        OnAddedRepository?.Invoke();
    }

    public IRepository GetRepository(string path)
    {
        if ( repositories.Any(x => x.Path == path))
        {
            var repo = repositories.First(x => x.Path == path);
            return null;

        }
        else
        {
            throw new Exception();
        }
    }

    public IList<RepositoryInfo> GetRepositories()
    {
        return repositories.ToList();
    }

    public IList<RepositoryInfo> GetRepositories(Func<RepositoryInfo, bool> whereFunc)
    {
        return repositories.Where(whereFunc).ToList();
    }
  }
}
