using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class KnightBitboardsTests
    {
        [TestMethod]
        public void AttackBitboards_CornerA1_Ok()
        {
            Square square = Square.a1;
            ulong expectedBitboard = Square.c2.GetBitboard() |
                                     Square.b3.GetBitboard();

            Assert.AreEqual(expectedBitboard, KnightBitboards.AttackBitboards[square.GetValue()]);
        }

        [TestMethod]
        public void AttackBitboards_CenterSquareD4_Ok()
        {
            Square square = Square.d4;
            ulong expectedBitboard = Square.e2.GetBitboard() |
                                     Square.f3.GetBitboard() |
                                     Square.f5.GetBitboard() |
                                     Square.e6.GetBitboard() |
                                     Square.c6.GetBitboard() |
                                     Square.b5.GetBitboard() |
                                     Square.b3.GetBitboard() |
                                     Square.c2.GetBitboard();

            Assert.AreEqual(expectedBitboard, KnightBitboards.AttackBitboards[square.GetValue()]);
        }

        [TestMethod]
        public void AttackBitboards_LateralSquareH5_Ok()
        {
            Square square = Square.h5;
            ulong expectedBitboard = Square.g7.GetBitboard() |
                                     Square.f6.GetBitboard() |
                                     Square.f4.GetBitboard() |
                                     Square.g3.GetBitboard();

            Assert.AreEqual(expectedBitboard, KnightBitboards.AttackBitboards[square.GetValue()]);
        }

        [TestMethod]
        public void AttackBitboards_SquareG7_Ok()
        {
            Square square = Square.g7;
            ulong expectedBitboard = Square.h5.GetBitboard() |
                                     Square.f5.GetBitboard() |
                                     Square.e6.GetBitboard() |
                                     Square.e8.GetBitboard();

            Assert.AreEqual(expectedBitboard, KnightBitboards.AttackBitboards[square.GetValue()]);
        }
    }
}
