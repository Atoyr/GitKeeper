using System;
using System.IO;
using GitKeeper.Utilities;

namespace GitKeeper.Data
{
    public class RepositoryInfo
    {
        public string ID { get; private set;}
        public string Path { get; set; }
        public string Name { get; set; }


        public RepositoryInfo()
        {
            OnInitialized();
        }

        public RepositoryInfo(string path)
        {
            OnInitialized();
            var p = Repository.RepositoryPath(path);
            if (string.IsNullOrEmpty(p)) throw new Exception();
            Path = p;
            Name = System.IO.Path.GetFileName(p);
        }

        protected void OnInitialized()
        {
            ID = Guid.NewGuid().ToString();
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(Path);
        }
    }
}
