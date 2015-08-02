using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class RotationBitboardExtensionsTest
    {
        [TestMethod]
        public void Rotate90DegreesLeft_Ok()
        {
            ulong bitboard = Square.h8.GetBitboard();
            ulong expected = Square.a8.GetBitboard();

            ulong result = bitboard.Rotate90DegreesLeft();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Rotate90DegreesRight_Ok()
        {
            ulong bitboard = Square.h8.GetBitboard();
            ulong expected = Square.h1.GetBitboard();

            ulong result = bitboard.Rotate90DegreesRight();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FlipDiagonal_Ok()
        {
            ulong bitboard = Square.h1.GetBitboard();
            ulong expected = Square.a8.GetBitboard();

            ulong result = bitboard.FlipDiagonal();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FlipVertical_Ok()
        {
            ulong bitboard = Square.a8.GetBitboard();
            ulong expected = Square.a1.GetBitboard();

            ulong result = bitboard.FlipVertical();

            Assert.AreEqual(expected, result);
        }
    }
}
