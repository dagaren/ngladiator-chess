﻿using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Utils;
using System.Collections.Generic;

namespace Gladiator.Evaluation.Bitboard
{
    public class MaterialEvaluator<TPosition> : BitboardPositionEvaluator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        public const int PAWN_SCORE = 100;
        public const int KNIGHT_SCORE = 300;
        public const int BISHOP_SCORE = 310;
        public const int ROOK_SCORE = 500;
        public const int QUEEN_SCORE = 900;
        public const int KING_SCORE = 0;

        private readonly static int[] pieceValues;

        static MaterialEvaluator()
        {
            pieceValues = new int[12];

            pieceValues[ColouredPiece.WhitePawn.GetValue()] = PAWN_SCORE;
            pieceValues[ColouredPiece.WhiteRook.GetValue()] = ROOK_SCORE;
            pieceValues[ColouredPiece.WhiteKnight.GetValue()] = KNIGHT_SCORE;
            pieceValues[ColouredPiece.WhiteBishop.GetValue()] = BISHOP_SCORE;
            pieceValues[ColouredPiece.WhiteQueen.GetValue()] = QUEEN_SCORE;
            pieceValues[ColouredPiece.WhiteKing.GetValue()] = KING_SCORE;

            pieceValues[ColouredPiece.BlackPawn.GetValue()] = -PAWN_SCORE;
            pieceValues[ColouredPiece.BlackRook.GetValue()] = -ROOK_SCORE;
            pieceValues[ColouredPiece.BlackKnight.GetValue()] = -KNIGHT_SCORE;
            pieceValues[ColouredPiece.BlackBishop.GetValue()] = -BISHOP_SCORE;
            pieceValues[ColouredPiece.BlackQueen.GetValue()] = -QUEEN_SCORE;
            pieceValues[ColouredPiece.BlackKing.GetValue()] = -KING_SCORE;
        }

        public override int Evaluate(TPosition position)
        {
            int score = 0;

            foreach(ColouredPiece piece in EnumExtensions.GetValues<ColouredPiece>())
            {
                if(piece == ColouredPiece.None)
                {
                    continue;
                }

                score += pieceValues[piece.GetValue()] * position.Board.pieceOccupation[piece.GetValue()].BitCount();
            }

            return score;
        }
    }
}
