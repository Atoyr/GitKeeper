using System;
using System.IO;

namespace GitKeeper.Utilities
{
  public static class Repository
  {
    public static string RepositoryPath(string path)
    {
      string p = path;
      while (!Directory.Exists(Path.Combine(p,".git")))
      {
        var di = Directory.GetParent(p);
        if(di == null)
        {
          return string.Empty;
        }

        p = di.FullName;
      }
      return p;
    }
  }
}
