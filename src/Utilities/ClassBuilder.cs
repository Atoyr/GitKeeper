using System;
using System.Linq;
using System.Collections.Generic;
using GitKeeper.Themes;

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

        public static ClassBuilder Clone(ClassBuilder classBuilder)
        {
            var cb = new ClassBuilder();
            cb.classList = classBuilder.classList.ToList();
            return cb;
        }

        public ClassBuilder Add(string className) => Add(className, !string.IsNullOrWhiteSpace(className));

        public ClassBuilder Add(string className, string joinClassName) => Add(className + joinClassName, !string.IsNullOrWhiteSpace(className + joinClassName));

        public ClassBuilder Add(string className, Func<bool> when) => Add(className, when());

        public ClassBuilder Add(string className, string joinClassName, Func<bool> when) => Add(className + joinClassName, when());

        public ClassBuilder Add(string className, bool when)
        {
            if(when)
            {
              classList.Add(className);
            }
            return this;
        }

        public ClassBuilder Add(string className, string joinClassName, bool when) => Add(className + joinClassName, when);

        public ClassBuilder Add(Color color)
        {
            Add(color?.Background);
            Add(color?.Foreground);
            Add(color?.OnBackground);
            Add(color?.OnForeground);
            return this;
        }

        public string Build() => string.Join(' ', classList);
    }
}

