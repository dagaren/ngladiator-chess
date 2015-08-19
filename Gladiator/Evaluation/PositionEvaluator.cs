using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Evaluation
{
    public class PositionEvaluator : IEvaluator
    {
        private static readonly int[][] PieceSquareTable = new int[6][];

        public static readonly int[] pawnPieceSquare = {  
         0,   0,   0,   0,   0,   0,   0,   0,
         10,  10,  10, -20, -20,  10,  10,  10,
         5,  -5, -10,   0,   0, -10,  -5,   5,
         0,   0,   0,  20,  20,   0,   0,   0,
         5,   5,  10,  25,  25,  10,   5,   5,
        10,  10,  20,  30,  30,  20,  10,  10,
        50,  50,  50,  50,  50,  50,  50,  50,
         0,   0,   0,   0,   0,   0,   0,   0
                                        };
   
        public static readonly int[] knightPieceSquare = {  
       -50, -40, -30, -30, -30, -30, -40, -50,
       -40, -20,   0,   0,   0,   0, -20, -40,
       -30,   0,  10,  15,  15,  10,   0, -30,
       -30,   5,  15,  20,  20,  15,   5, -30,
       -30,   5,  15,  20,  20,  15,   5, -30,
       -30,   0,  10,  15,  15,  10,   0, -30,
       -40, -20,   0,   0,   0,   0, -20, -40,
       -50, -40, -30, -30, -30, -30, -40, -50
                                        };
   
        public static readonly int[] bishopPieceSquare = {  
       -20, -10, -10, -10, -10, -10, -10, -20,
       -10,   5,   0,   0,   0,   0,   5, -10,
       -10,  10,  10,  10,  10,  10,  10, -10,
       -10,   0,  10,  10,  10,  10,   0, -10,
       -10,   5,   5,  10,  10,   5,   5, -10,
       -10,   0,   5,  10,  10,   5,   0, -10,
       -10,   0,   0,   0,   0,   0,   0, -10,
       -20, -10, -10, -10, -10, -10, -10, -20
                                        };
   
        public static readonly int[] rookPieceSquare = {  
         0,   0,   0,   5,   5,   0,   0,   0,
        -5,   0,   0,   0,   0,   0,   0,  -5,
        -5,   0,   0,   0,   0,   0,   0,  -5,
        -5,   0,   0,   0,   0,   0,   0,  -5,
        -5,   0,   0,   0,   0,   0,   0,  -5,
        -5,   0,   0,   0,   0,   0,   0,  -5,
         5,  10,  10,  10,  10,  10,  10,   5,
         0,   0,   0,   0,   0,   0,   0,   0
                                          };
   
        public static readonly int[] queenPieceSquare = {  
       -20, -10, -10,  -5,  -5, -10, -10, -20,
       -10,   0,   0,   0,   0,   0,   0, -10,
       -10,   5,   5,   5,   5,   5,   5, -10,
        -5,   0,   5,   5,   5,   5,   0,  -5,
        -5,   0,   5,   5,   5,   5,   0,  -5,
       -10,   0,   5,   5,   5,   5,   0, -10,
       -10,   0,   0,   0,   0,   0,   0, -10,
       -20, -10, -10,  -5,  -5, -10, -10, -20
                                          };
   
        public static readonly int[] kingPieceSquare = {
          20,  30,  10,   0,   0,  10,  30,  20,
          20,  20,   0,   0,   0,   0,  20,  20,
         -10, -20, -20, -20, -20, -20, -20, -10,
         -20, -30, -30, -40, -40, -30, -30, -20,
         -30, -40, -40, -50, -50, -40, -40, -30,
         -30, -40, -40, -50, -50, -40, -40, -30,
         -30, -40, -40, -50, -50, -40, -40, -30,
         -30, -40, -40, -50, -50, -40, -40, -30,
                                            };
   
        public static readonly int[] endKingPieceSquare = {  
         -50, -30, -30, -30, -30, -30, -30, -50,
         -30, -30,   0,   0,   0,   0, -30, -30,
         -30, -10,  20,  30,  30,  20, -10, -30,
         -30, -10,  30,  40,  40,  30, -10, -30,
         -30, -10,  30,  40,  40,  30, -10, -30,
         -30, -10,  20,  30,  30,  20, -10, -30,
         -30, -20, -10,   0,   0, -10, -20, -30,
         -50, -40, -30, -20, -20, -30, -40, -50
                                            };

        static PositionEvaluator()
        {
            PieceSquareTable[Piece.Pawn.GetValue()] = pawnPieceSquare;
            PieceSquareTable[Piece.Rook.GetValue()] = rookPieceSquare;
            PieceSquareTable[Piece.Knight.GetValue()] = knightPieceSquare;
            PieceSquareTable[Piece.Bishop.GetValue()] = bishopPieceSquare;
            PieceSquareTable[Piece.Queen.GetValue()] = queenPieceSquare;
            PieceSquareTable[Piece.King.GetValue()] = kingPieceSquare;
        }

        public int Evaluate(IPosition<IBoard> position)
        {
            int score = 0;

            foreach (ColouredPiece piece in ColouredPieceExtensions.AllPieces())
            {
                foreach(Square square in position.Board.GetSquaresWithPiece(piece))
                {
                    if(piece.GetColour() == Colour.White)
                    {
                        score += PieceSquareTable[piece.GetPiece().GetValue()][square.GetValue()];
                    }
                    else
                    {
                        score -= PieceSquareTable[piece.GetPiece().GetValue()][square.Mirror().GetValue()];
                    }
                }
            }

            return score;
        }
    }
}
