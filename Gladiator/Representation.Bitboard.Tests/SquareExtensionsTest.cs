using System;
using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class SquareExtensionsTest
    {
        [TestMethod]
        public void RightBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.e4,
                                            Square.f4,
                                            Square.g4,
                                            Square.h4
                                        );

            ulong resultBitboard = square.RightBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void LeftBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.c4,
                                            Square.b4,
                                            Square.a4
                                        );

            ulong resultBitboard = square.LeftBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void TopBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.d5,
                                            Square.d6,
                                            Square.d7,
                                            Square.d8
                                        );

            ulong resultBitboard = square.TopBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void BottomBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.d3,
                                            Square.d2,
                                            Square.d1
                                        );

            ulong resultBitboard = square.BottomBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void TopLeftBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.c5,
                                            Square.b6,
                                            Square.a7
                                        );

            ulong resultBitboard = square.TopLeftBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void TopRightBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.e5,
                                            Square.f6,
                                            Square.g7,
                                            Square.h8
                                        );

            ulong resultBitboard = square.TopRightBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void BottomLeftBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.c3,
                                            Square.b2,
                                            Square.a1
                                        );

            ulong resultBitboard = square.BottomLeftBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void BottomRightBitboard_Ok()
        {
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                            Square.e3,
                                            Square.f2,
                                            Square.g1
                                        );

            ulong resultBitboard = square.BottomRightBitboard();

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }
    }
}
