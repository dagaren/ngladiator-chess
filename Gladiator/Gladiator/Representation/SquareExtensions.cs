using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    static class SquareExtensions
    {
        public static File GetFile(this Square square)
        {
            if(square == Square.None)
            {
                return File.None;
            }

            return (File)((int)square & 7);
        }

        public static Rank GetRank(this Square square)
        {
            if(square == Square.None)
            {
                return Rank.None;
            }

            return (Rank)((int)square >> 3);
        }

        public static int GetValue(this Square square)
        {
            return (int)square;
        }
    }
}
