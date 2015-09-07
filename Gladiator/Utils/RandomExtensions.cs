using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    public static class RandomExtensions
    {
        public static ulong NextULong(this Random random)
        {
            byte[] bytes = new byte[8];
            random.NextBytes(bytes);

            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}
