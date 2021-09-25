using System;
using System.Text;
using System.Collections.Generic;

namespace GitKeeper.Utilities
{
    public class StyleBuilder
    {
        private StringBuilder stringBuilder { get; set; } = new StringBuilder();

        public static StyleBuilder Default(string prop, string value) => new StyleBuilder(prop, value);
        public static StyleBuilder Empty() => new StyleBuilder();

        private StyleBuilder() {}

        public StyleBuilder(string prop, string value)
        {
            stringBuilder.Append($"{prop}: {value}; ");
        }

        private StyleBuilder add(string style)
        {
            stringBuilder.Append(style);
            return this;
        }

        public StyleBuilder AddStyle(string style) => add(style);
        public StyleBuilder AddStyle(string prop, string value) => add($"{prop}: {value}; ");
        public StyleBuilder AddStyle(string prop, string value, bool when = true) => when ? AddStyle(prop, value) : this;
        public StyleBuilder AddStyle(string prop, Func<string> value, bool when = true) => when ? AddStyle(prop, value()) : this;
        public StyleBuilder AddStyle(string prop, string value, Func<bool> when = null) => AddStyle(prop, value, when is not null && when());
        public StyleBuilder AddStyle(string prop, Func<string> value, Func<bool> when = null) => AddStyle(prop, value(), when is not nul;l && when());

        public string Build() => stringBuilder.ToString().Trim();
        public override string ToString() => Build();
    }
}