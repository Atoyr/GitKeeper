using System;
using System.Collections.Generic;
using GitKeeper.Data;

namespace GitKeeper.Utilities
{
    public class ClassBuilder
    {
        private List<string> classList { get; set; }

        private ClassBuilder()
        {
            classList = new List<string>();
        }

        public ClassBuilder(string className)
        {
            classList = new List<string>();
            Add(className);
        }

        public static ClassBuilder Empty()
        {
            var cb = new ClassBuilder();
            return cb;
        }

        public static ClassBuilder Default(string className)
        {
            var cb = new ClassBuilder();
            return cb.Add(className);
        }

        public ClassBuilder Add(string className) => Add(className, !string.IsNullOrWhiteSpace(className));

        public ClassBuilder Add(string className, Func<bool> when) => Add(className, when());

        public ClassBuilder Add(string className, bool when)
        {
            if(when)
            {
              classList.Add(className);
            }
            return this;
        }

        public ClassBuilder Add(Color color)
        {
            Add(color?.Background);
            Add(color?.Foreground);
            return this;
        }

        public string Build() => string.Join(' ', classList);
    }
}

