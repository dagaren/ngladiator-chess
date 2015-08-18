using Gladiator.Representation;
using Gladiator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;

namespace Gladiator.Evaluation.Tests
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
            var position = Substitute.For<IPosition<IBoard>>();
            var board = Substitute.For<IBoard>();
            position.Board.Returns(board);

            foreach(ColouredPiece piece in EnumExtensions.GetValues<ColouredPiece>())
            {
                if(piece == ColouredPiece.None)
                {
                    continue;
                }

                int numPieces = pieces.Where(p => p == piece).Count();
                board.GetNumPieces(piece).Returns(numPieces);
            }

            var materialEvaluator = new MaterialEvaluator();

            int materialScore = materialEvaluator.Evaluate(position);

            Assert.AreEqual(expectedScore, materialScore);
        }
    }
}
