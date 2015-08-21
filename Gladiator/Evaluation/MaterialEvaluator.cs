using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Evaluation
{
    public class MaterialEvaluator : IEvaluator
    {
        public const int PAWN_SCORE = 100;
        public const int KNIGHT_SCORE = 300;
        public const int BISHOP_SCORE = 310;
        public const int ROOK_SCORE = 500;
        public const int QUEEN_SCORE = 900;
        public const int KING_SCORE = 0;

        public readonly static int[] PieceValues;

        static MaterialEvaluator()
        {
            PieceValues = new int[12];

            PieceValues[ColouredPiece.WhitePawn.GetValue()] = PAWN_SCORE;
            PieceValues[ColouredPiece.WhiteRook.GetValue()] = ROOK_SCORE;
            PieceValues[ColouredPiece.WhiteKnight.GetValue()] = KNIGHT_SCORE;
            PieceValues[ColouredPiece.WhiteBishop.GetValue()] = BISHOP_SCORE;
            PieceValues[ColouredPiece.WhiteQueen.GetValue()] = QUEEN_SCORE;
            PieceValues[ColouredPiece.WhiteKing.GetValue()] = KING_SCORE;

            PieceValues[ColouredPiece.BlackPawn.GetValue()] = -PAWN_SCORE;
            PieceValues[ColouredPiece.BlackRook.GetValue()] = -ROOK_SCORE;
            PieceValues[ColouredPiece.BlackKnight.GetValue()] = -KNIGHT_SCORE;
            PieceValues[ColouredPiece.BlackBishop.GetValue()] = -BISHOP_SCORE;
            PieceValues[ColouredPiece.BlackQueen.GetValue()] = -QUEEN_SCORE;
            PieceValues[ColouredPiece.BlackKing.GetValue()] = -KING_SCORE;
        }

        public int Evaluate(IPosition<IBoard> position)
        {
            int score = 0;

            foreach (ColouredPiece piece in ColouredPieceExtensions.AllPieces())
            {
                score += PieceValues[piece.GetValue()] * position.Board.GetNumPieces(piece);
            }

            return score;
        }
    }
}
