using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Representation.Bitboard.Tests
{
    [TestClass]
    public class KingBitboardsTest
    {
        [TestMethod]
        public void AttackBitboards_CornerA1_Ok()
        {
            Square square = Square.a1;
            ulong expectedBitboard = Square.a2.GetBitboard() |
                                     Square.b2.GetBitboard() |
                                     Square.b1.GetBitboard();

            Assert.AreEqual(expectedBitboard, KingBitboards.AttackBitboards[square.GetValue()]);
        }

        [TestMethod]
        public void AttackBitboards_CentralSquareD4_Ok()
        {
            Square square = Square.d4;
            ulong expectedBitboard = Square.d5.GetBitboard() |
                                     Square.e3.GetBitboard() |
                                     Square.e5.GetBitboard() |
                                     Square.e4.GetBitboard() |
                                     Square.d3.GetBitboard() |
                                     Square.c4.GetBitboard() |
                                     Square.c5.GetBitboard() |
                                     Square.c3.GetBitboard();

            Assert.AreEqual(expectedBitboard, KingBitboards.AttackBitboards[square.GetValue()]);
        }

        [TestMethod]
        public void AttackBitboards_LateralSquareE8_Ok()
        {
            Square square = Square.e8;
            ulong expectedBitboard = Square.e7.GetBitboard() |
                                     Square.d8.GetBitboard() |
                                     Square.f8.GetBitboard() |
                                     Square.d7.GetBitboard() |
                                     Square.f7.GetBitboard();

            Assert.AreEqual(expectedBitboard, KingBitboards.AttackBitboards[square.GetValue()]);
        }
    }
}
