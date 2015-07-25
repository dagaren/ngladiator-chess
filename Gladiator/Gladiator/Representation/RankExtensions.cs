using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    static class RankExtensions
    {
        public static int GetValue(this Rank rank)
        {
            return (int)rank;
        }
    }
}
