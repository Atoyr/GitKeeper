using System;
using System.IO;
using System.Collections.Generic;
using LibGit2Sharp;

namespace GitKeeper.Data
{
  public class RepositoryService
  {
    private Dictionary<string, IRepository> repositories { set; get; }

    public RepositoryService()
    {
      repositories = new Dictionary<string, IRepository>();
    }

    public IRepository this[string path]
    {
      set
      {
        repositories[path] = value;
      }

      get
      {
        if (repositories.ContainsKey(path))
        {
          return repositories[path];
        }
        else
        {
          return null;
        }
      }
    }

    public int Count()
    {
      return repositories.Count;
    }
  }
}
