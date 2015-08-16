using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Utils
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var random = new Random();
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.ElementAt(random.Next(0, list.Count()));
        }
    }
}
