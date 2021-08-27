using System;
using System.Collections.Generic;

namespace GitKeeper.Utilities
{
    public class ClassBuilder
    {
        private List<string> classList { get; set; }

        private ClassBuilder()
        {
            classList = new List<string>();
        }

        public static ClassBuilder Default(string className)
        {
            var cb = new ClassBuilder();
            cb.classList.Add(className);
            return cb;
        }

        public ClassBuilder Add(params string[] classNames)
        {
            classList.AddRange(classNames);
            return this;
        }

        public string Build() => string.Join(' ', classList);
    }
}

