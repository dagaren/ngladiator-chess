using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Bitboard
{
    public static class BitboardFormatExtensions
    {
        public static string Format(this ulong bitboard, string prefix = "")
        {
            ulong position = 1;
            string[,] board = new string[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ulong result = position & bitboard;

                    if (result == 0)
                    {
                        board[i, j] = " - ";
                    }
                    else
                    {
                        board[i, j] = " X ";
                    }

                    position = position << 1;
                }
            }

            StringBuilder formated = new StringBuilder();
            formated.AppendLine(prefix + " --------------------------");
            for (int i = 7; i >= 0; i--)
            {
                formated.Append(prefix + (i + 1));
                formated.Append("|");

                for (int j = 0; j < 8; j++)
                {
                    formated.Append(board[i, j]);
                }

                formated.AppendLine("|");
            }
            formated.AppendLine(prefix + " --------------------------");
            formated.AppendLine(prefix + "   a  b  c  d  e  f  g  h");

            return formated.ToString();
        }
    }
}
