using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Representation.Bitboard.Tests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Gladiator.Evaluation.Bitboard.Tests
{
    [TestClass]
    public class MaterialEvaluatorTest
    {
        [TestMethod]
        public void Evaluate_EmptyPosition_ZeroScoreExpected()
        {
            int expectedScore = 0;

            TestMaterial(expectedScore);
        }

        [TestMethod]
        public void Evaluate_PositionWithPawns_Ok()
        {
            int expectedScore = 100 - 100 + 100;

            TestMaterial(expectedScore,
                        ColouredPiece.WhitePawn,
                        ColouredPiece.WhitePawn,
                        ColouredPiece.BlackPawn);
        }

        [TestMethod]
        public void Evaluate_PositionWithRooks_Ok()
        {
            int expectedScore = 500 - 500 + 500;

            TestMaterial(expectedScore,
                        ColouredPiece.WhiteRook,
                        ColouredPiece.WhiteRook,
                        ColouredPiece.BlackRook);
        }

        [TestMethod]
        public void Evaluate_PositionWithKnights_Ok()
        {
            int expectedScore = 300 - 300 + 300;

            TestMaterial(expectedScore,
                        ColouredPiece.WhiteKnight,
                        ColouredPiece.WhiteKnight,
                        ColouredPiece.BlackKnight);
        }

        [TestMethod]
        public void Evaluate_PositionWithBishops_Ok()
        {
            int expectedScore = 310 - 310 + 310;

            TestMaterial(expectedScore,
                        ColouredPiece.WhiteBishop,
                        ColouredPiece.WhiteBishop,
                        ColouredPiece.BlackBishop);
        }

        [TestMethod]
        public void Evaluate_PositionWithQueens_Ok()
        {
            int expectedScore = 900 - 900 + 900;

            TestMaterial(expectedScore,
                        ColouredPiece.WhiteQueen,
                        ColouredPiece.WhiteQueen,
                        ColouredPiece.BlackQueen);
        }

        [TestMethod]
        public void Evaluate_PositionWithKings_Ok()
        {
            int expectedScore = 0;

            TestMaterial(expectedScore,
                        ColouredPiece.WhiteKing,
                        ColouredPiece.WhiteKing,
                        ColouredPiece.BlackKing);
        }

        [TestMethod]
        public void Evaluate_PositionWithMultiplePieces_Ok()
        {
            int expectedScore = 100 + 100 - 100
                              + 500 - 500 - 500
                              + 300 + 300 - 300
                              + 310 - 310 - 310
                              + 900 + 900 - 900
                              + 0;

            TestMaterial(expectedScore,
                        ColouredPiece.WhitePawn,
                        ColouredPiece.WhitePawn,
                        ColouredPiece.BlackPawn,
                        ColouredPiece.WhiteRook,
                        ColouredPiece.BlackRook,
                        ColouredPiece.BlackRook,
                        ColouredPiece.WhiteKnight,
                        ColouredPiece.WhiteKnight,
                        ColouredPiece.BlackKnight,
                        ColouredPiece.WhiteBishop,
                        ColouredPiece.BlackBishop,
                        ColouredPiece.BlackBishop,
                        ColouredPiece.WhiteQueen,
                        ColouredPiece.WhiteQueen,
                        ColouredPiece.BlackQueen,
                        ColouredPiece.WhiteKing,
                        ColouredPiece.BlackKing,
                        ColouredPiece.BlackKing
                        );
        }

        private static void TestMaterial(int expectedScore, params ColouredPiece[] pieces)
        {
            var moveGenerator = Substitute.For<IMoveGenerator<Position<BitboardBoard>, BitboardBoard>>();
            var positionBuilder = new BitboardPositionBuilder(moveGenerator).SetTurn(Colour.White);

            Square square = Square.a1;
            foreach(ColouredPiece piece in pieces)
            {
                positionBuilder.PutPiece(piece, square);

                square = square.Next();
            }
                                                
            Position<BitboardBoard> position = positionBuilder.Build();

            var materialEvaluator = new MaterialEvaluator<Position<BitboardBoard>>();

            int materialScore = materialEvaluator.Evaluate(position);

            Assert.AreEqual(expectedScore, materialScore);
        }
    }
}
