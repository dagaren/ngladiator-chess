using Gladiator.Utils;
using System;

namespace Gladiator.Representation
{
    public static class IBoardExtensions
    {
        public static bool AreEqual(this IBoard board, IBoard secondBoard)
        {
            foreach(Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                if(board.GetPiece(square) != secondBoard.GetPiece(square))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
