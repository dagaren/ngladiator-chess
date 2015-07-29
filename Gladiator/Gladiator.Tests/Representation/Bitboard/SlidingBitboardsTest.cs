using System;
using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class SlidingBitboardsTest
    {
        [TestMethod]
        public void GetRankAttack_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                    Square.b4, 
                                    Square.g4,
                                    Square.d4,
                                    Square.a1,
                                    Square.h8
                                );
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                    Square.c4,
                                    Square.b4,
                                    Square.e4,
                                    Square.f4,
                                    Square.g4
                                );

            ulong resultBitboard = SlidingBitboards.GetRankAttack(square, bitboard);

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }

        [TestMethod]
        public void GetFileAttack_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                    Square.d7,
                                    Square.g4,
                                    Square.d4,
                                    Square.a3,
                                    Square.d1
                                );
            Square square = Square.d4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                    Square.d5,
                                    Square.d6,
                                    Square.d7,
                                    Square.d3,
                                    Square.d2,
                                    Square.d1
                                );

            ulong resultBitboard = SlidingBitboards.GetFileAttack(square, bitboard);

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }
    }
}
