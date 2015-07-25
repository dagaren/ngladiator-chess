using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gladiator.Representation.Notation;

namespace Gladiator.Representation
{
    static class BoardExtensions
    {
        public static string Format(this IBoard originalBoard)
        {
            string[,] board = new string[8, 8];

            IEnumerable<Square> squares = EnumExtensions.GetValues<Square>();

            foreach(Square square in squares)
            {
                if(square == Square.None)
                {
                    continue;
                }

                ColouredPiece piece = originalBoard.GetPiece(square);

                string value = " - ";
                if(piece != ColouredPiece.None)
                {
                    value = string.Format(" {0} ", piece.Format());
                }

                board[square.GetRank().GetValue(), square.GetFile().GetValue()] = value;
            }

            StringBuilder formated = new StringBuilder();
            formated.AppendLine(" --------------------------");
            for (int i = 7; i >= 0; i--)
            {
                formated.Append(i + 1);
                formated.Append("|");

                for (int j = 0; j < 8; j++)
                {
                    formated.Append(board[i, j]);
                }

                formated.AppendLine("|");
            }
            formated.AppendLine(" --------------------------");
            formated.AppendLine("   a  b  c  d  e  f  g  h");

            return formated.ToString();
        }

        public static void WriteConsolePretty(this IBoard originalBoard)
        {
            ConsoleColor borderColor = ConsoleColor.DarkCyan;
            ConsoleColor whitePieceColor = ConsoleColor.Yellow;
            ConsoleColor blackPieceColor = ConsoleColor.DarkRed;
            ConsoleColor coordinatesColor = ConsoleColor.DarkGreen;
            ConsoleColor whiteSquareColor = ConsoleColor.White;
            ConsoleColor blackSquareColor = ConsoleColor.Magenta;

            string[,] board = new string[8, 8];
            ConsoleColor?[,] boardColors = new ConsoleColor?[8, 8];

            IEnumerable<Square> squares = EnumExtensions.GetValues<Square>();

            foreach (Square square in squares)
            {
                if (square == Square.None)
                {
                    continue;
                }

                ColouredPiece piece = originalBoard.GetPiece(square);

                string value = " - ";
                if (piece != ColouredPiece.None)
                {
                    value = string.Format(" {0} ", piece.Format());
                    boardColors[square.GetRank().GetValue(), square.GetFile().GetValue()] = piece.GetColour() == Colour.Black ? blackPieceColor : whitePieceColor;
                }
                else
                {
                    boardColors[square.GetRank().GetValue(), square.GetFile().GetValue()] =
                        ((square.GetRank().GetValue() + square.GetFile().GetValue()) % 2 == 0) ? blackSquareColor : whiteSquareColor;
                }

                board[square.GetRank().GetValue(), square.GetFile().GetValue()] = value;
            }

            ConsoleExtensions.WriteLineColoured(" --------------------------", borderColor);
            for (int i = 7; i >= 0; i--)
            {
                ConsoleExtensions.WriteColoured((i + 1).ToString(), coordinatesColor); 
                ConsoleExtensions.WriteColoured("|", borderColor);

                for (int j = 0; j < 8; j++)
                {
                    if(boardColors[i, j].HasValue)
                    {
                        ConsoleExtensions.WriteColoured(board[i, j], boardColors[i, j].Value);
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }
                }

                ConsoleExtensions.WriteLineColoured("|", borderColor);
            }
            ConsoleExtensions.WriteLineColoured(" --------------------------", borderColor);
            ConsoleExtensions.WriteLineColoured("   a  b  c  d  e  f  g  h", coordinatesColor);
        }
    }
}
