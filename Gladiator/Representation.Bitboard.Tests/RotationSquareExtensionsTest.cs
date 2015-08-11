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

        [TestMethod]
        public void RotatedDiagonal45DegreesLeft_Ok()
        {
            Square square = Square.d1;
            Square expected = Square.d4;

            Square rotated = square.DiagonalRotated45DegreesLeft();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void RotatedDiagonal45DegreesRight_Ok()
        {
            Square square = Square.d4;
            Square expected = Square.d1;

            Square rotated = square.DiagonalRotated45DegreesRight();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void RotatedAntidiagonal45DegreesRight_Ok()
        {
            Square square = Square.d1;
            Square expected = Square.d5;

            Square rotated = square.AntidiagonalRotated45DegreesRight();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void RotatedAntidiagonal45DegreesLeft_Ok()
        {
            Square square = Square.d5;
            Square expected = Square.d1;

            Square rotated = square.AntidiagonalRotated45DegreesLeft();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void DiagonalRotatedMask_Ok()
        {
            Square square = Square.d1;

            ulong expected = BitboardExtensions.FromSquares(
                                Square.a1,
                                Square.b1,
                                Square.c1,
                                Square.d1,
                                Square.e1,
                                Square.f1,
                                Square.g1,
                                Square.h1
                             );

            ulong mask = square.DiagonalRotatedMask();

            Assert.AreEqual(expected, mask);
        }

        [TestMethod]
        public void AntidiagonalRotatedMask_Ok()
        {
            Square square = Square.d1;

            ulong expected = BitboardExtensions.FromSquares(
                                Square.a1,
                                Square.b1,
                                Square.c1,
                                Square.d1,
                                Square.e1,
                                Square.f1,
                                Square.g1,
                                Square.h1
                             );

            ulong mask = square.AntidiagonalRotatedMask();

            Assert.AreEqual(expected, mask);
        }
    }
}
