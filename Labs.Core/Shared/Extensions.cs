using System;
using System.Linq;

namespace Labs.Core.Shared
{
    public static class RandomExtensions
    {
        public static string Text(this Random random, int length)
        {
            const string source = "abcd efgh ijkl mnop qrst uvwxyz";
            var value = Enumerable
                .Repeat(source, length)
                .Select(p => p[random.Next(p.Length)])
                .ToArray();
            return new string(value);
        }
    }
}