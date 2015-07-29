using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class RankExtensionTest
    {
        [TestMethod]
        public void OccupationBitboard_Ok()
        {
            byte occupation = 0xF;
            Rank rank = Rank._4;

            ulong expectedBitboard = BitboardExtensions.FromSquares(
                                        Square.a4, 
                                        Square.b4, 
                                        Square.c4, 
                                        Square.d4);

            ulong resultBitboard = rank.OccupationBitboard(occupation);

            Assert.AreEqual(expectedBitboard, resultBitboard);
        }
    }
}
