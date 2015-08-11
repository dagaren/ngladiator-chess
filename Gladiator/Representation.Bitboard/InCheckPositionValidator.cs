using Gladiator.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Bitboard
{
    public class InCheckPositionValidator<TPosition> : IPositionValidator<TPosition, BitboardBoard> where TPosition : IPosition<BitboardBoard>
    {
        public bool IsValid(TPosition position)
        {
            Colour opponent = position.Turn.Opponent();
            Colour turn = position.Turn;

            Square kingSquare = position.Board.pieceOccupation[Piece.King.GetColoured(opponent).GetValue()]
                                    .FirstSquareScan();

            ulong diagonalAttack = SlidingBitboards.GetDiagonalAttack(kingSquare, position.Board.colourOccupation[turn.Value()] | kingSquare.GetBitboard()) |
                                   SlidingBitboards.GetAntidiagonalAttack(kingSquare, position.Board.colourOccupation[turn.Value()] | kingSquare.GetBitboard());
            ulong linearAttack = SlidingBitboards.GetFileAttack(kingSquare, position.Board.colourOccupation[turn.Value()] | kingSquare.GetBitboard()) |
                                 SlidingBitboards.GetRankAttack(kingSquare, position.Board.colourOccupation[turn.Value()] | kingSquare.GetBitboard());

            if(diagonalAttack != BitboardExtensions.Empty)
            {
                if ((diagonalAttack &
                (position.Board.pieceOccupation[Piece.Queen.GetColoured(turn).GetValue()] |
                position.Board.pieceOccupation[Piece.Bishop.GetColoured(turn).GetValue()])) != BitboardExtensions.Empty)
                {
                    return false;
                }
            }

            if(linearAttack != BitboardExtensions.Empty)
            {
                if ((linearAttack &
                (position.Board.pieceOccupation[Piece.Queen.GetColoured(turn).GetValue()] |
                position.Board.pieceOccupation[Piece.Rook.GetColoured(turn).GetValue()])) != BitboardExtensions.Empty)
                {
                    return false;
                }
            }

            if((KnightBitboards.AttackBitboards[kingSquare.GetValue()] &
                position.Board.pieceOccupation[Piece.Knight.GetColoured(turn).GetValue()]) != BitboardExtensions.Empty)
            {
                return false;
            }

            if((KingBitboards.AttackBitboards[kingSquare.GetValue()] &
                position.Board.pieceOccupation[Piece.King.GetColoured(turn).GetValue()]) != BitboardExtensions.Empty)
            {
                return false;
            }

            if((PawnBitboards.AttackBitboards[opponent.Value(), kingSquare.GetValue()] &
                position.Board.pieceOccupation[Piece.Pawn.GetColoured(turn).GetValue()]) != BitboardExtensions.Empty)
            {
                return false;
            }

            return true;
        }
    }
}
