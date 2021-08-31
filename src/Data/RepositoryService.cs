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

    public RepositoryInfo AddRepository(string path)
    {
        var repositoryInfo = new RepositoryInfo(path);
        repositories.Add(repositoryInfo);
        OnAddedRepository?.Invoke();
        return repositoryInfo;
    }

    public RepositoryInfo GetRepository(string id)
    {
        if ( repositories.Any(x => x.ID == id))
        {
            var repository = repositories.First(x => x.ID == id);
            return repository;
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
