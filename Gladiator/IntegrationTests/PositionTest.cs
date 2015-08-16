using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gladiator.Representation.Bitboard;
using Gladiator.Representation;
using Gladiator.Representation.Tests.Builders;
using System.Collections.Generic;

namespace IntegrationTests
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        [Ignore]
        public void TestMoveUndoMove()
        {
            var kingMoveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            var knightMoveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            var rookMoveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();
            var bishopMoveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            var queenMoveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();
            var pawnMoveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] moveGenerators = new IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] {
                kingMoveGenerator,
                knightMoveGenerator,
                rookMoveGenerator,
                bishopMoveGenerator,
                queenMoveGenerator,
                pawnMoveGenerator
            };
            IPositionValidator<Position<BitboardBoard>, BitboardBoard> positionValidator = new InCheckPositionValidator<Position<BitboardBoard>>();
            var compositeMoveGenerator = new CompositeMoveGenerator<Position<BitboardBoard>, BitboardBoard>(moveGenerators);
            BitboardBoard board = new BitboardBoard();

            var positionBuilder = new InitialChessPositionBuilder<BitboardBoard>(compositeMoveGenerator, positionValidator);
            var position = positionBuilder.Build();


            TestDoUndoMove(position, 6);
        }

        private void TestDoUndoMove(Position<BitboardBoard> position, int remainingPlies)
        {
            if(remainingPlies == 0)
            {
                return;
            }

            Position<BitboardBoard> copy = position.GetCopy();
            var moves = position.GetMoves(MoveSearchType.LegalMoves);

            foreach(Move move in moves)
            {
                var full = position.DoMove(move);
                
                TestDoUndoMove(position, remainingPlies - 1);

                position.UndoMove(full);

                bool areEqual = copy.Equals(position);
                if(!areEqual)
                {
                    Console.WriteLine("Before doing "  + move.Format());
                    copy.Board.WriteConsolePretty();
                    Console.WriteLine("After");
                    position.Board.WriteConsolePretty();
                }

                Assert.IsTrue(areEqual);
            }
        }

        [TestMethod]
        public void TestPosition1()
        {
            var kingMoveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            var knightMoveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            var rookMoveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();
            var bishopMoveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            var queenMoveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();
            var pawnMoveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] moveGenerators = new IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] {
                kingMoveGenerator,
                knightMoveGenerator,
                rookMoveGenerator,
                bishopMoveGenerator,
                queenMoveGenerator,
                pawnMoveGenerator
            };
            IPositionValidator<Position<BitboardBoard>, BitboardBoard> positionValidator = new InCheckPositionValidator<Position<BitboardBoard>>();
            var compositeMoveGenerator = new CompositeMoveGenerator<Position<BitboardBoard>, BitboardBoard>(moveGenerators);
            BitboardBoard board = new BitboardBoard();

            var positionBuilder = new Gladiator.Representation.PositionBuilder<BitboardBoard>(compositeMoveGenerator, positionValidator);

            positionBuilder.PutPiece(ColouredPiece.WhitePawn, Square.a2, Square.b2, Square.c2, Square.e2,
                                                              Square.f2, Square.g4, Square.h2)
                           .PutPiece(ColouredPiece.BlackPawn, Square.a7, Square.b7, Square.d7, Square.d4,
                                                              Square.e6, Square.f7, Square.g7, Square.h7)
                           .PutPiece(ColouredPiece.WhiteRook, Square.a1, Square.h1)
                           .PutPiece(ColouredPiece.BlackRook, Square.a8, Square.h8)
                           .PutPiece(ColouredPiece.WhiteKnight, Square.b1, Square.g1)
                           .PutPiece(ColouredPiece.BlackKnight, Square.b8, Square.f6)
                           .PutPiece(ColouredPiece.WhiteBishop, Square.d2, Square.h3)
                           .PutPiece(ColouredPiece.BlackBishop, Square.c8, Square.f8)
                           .PutPiece(ColouredPiece.WhiteQueen, Square.f5)
                           .PutPiece(ColouredPiece.BlackQueen, Square.a5)
                           .PutPiece(ColouredPiece.WhiteKing, Square.e1)
                           .PutPiece(ColouredPiece.BlackKing, Square.e8)
                           .SetEnPassantSquare(Square.None)
                           .SetCastlingRight(CastlingType.Long, Colour.White, false)
                           .SetCastlingRight(CastlingType.Long, Colour.Black, false)
                           .SetCastlingRight(CastlingType.Short, Colour.White, false)
                           .SetCastlingRight(CastlingType.Short, Colour.Black, false)
                           .SetTurn(Colour.Black);

            var position = positionBuilder.Build();

            List<Move> expectedMovesFromE6 = new MoveListBuilder().AddMove(Square.e6, Square.e5)
                                                                             .AddMove(Square.e6, Square.f5);
            var movesFromE6 = position.GetMoves(MoveSearchType.LegalMoves).Where(m => m.Source == Square.e6).ToArray();

            Assert.AreEqual(expectedMovesFromE6.Count(), movesFromE6.Count());
            expectedMovesFromE6.ForEach(expectedMove => CollectionAssert.Contains(movesFromE6, expectedMove));
        }
    }
}
