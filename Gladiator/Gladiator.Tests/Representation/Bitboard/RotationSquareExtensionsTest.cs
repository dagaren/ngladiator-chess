using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class RotationSquareExtensionsTest
    {
        [TestMethod]
        public void Rotated90DegreesRight_Ok()
        {
            Square square = Square.a1;
            Square expected = Square.a8;

            Square rotated = square.Rotated90DegreesRight();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void Rotated90DegreesRight_SquareNone_SquareNoneExpected()
        {
            Square square = Square.None;
            Square expected = Square.None;

            Square rotated = square.Rotated90DegreesRight();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void Rotated90DegreesLeft_Ok()
        {
            Square square = Square.a1;
            Square expected = Square.h1;

            Square rotated = square.Rotated90DegreesLeft();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void Rotated90DegreesLeft_SquareNone_SquareNoneExpected()
        {
            Square square = Square.None;
            Square expected = Square.None;

            Square rotated = square.Rotated90DegreesLeft();

            Assert.AreEqual(expected, rotated);
        }
    }
}
