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
            ulong bitboard = BitboardExtensions.FromSquares(
                                Square.d8,
                                Square.a4,
                                Square.f2
                             );

            ulong expected = BitboardExtensions.FromSquares(
                                Square.a4,
                                Square.e1,
                                Square.g6
                             );

            ulong result = bitboard.Rotate90DegreesLeft();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Rotate90DegreesRight_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                Square.a4,
                                Square.e1,
                                Square.g6
                             );
            ulong expected = BitboardExtensions.FromSquares(
                                Square.d8,
                                Square.a4,
                                Square.f2
                             );

            ulong result = bitboard.Rotate90DegreesRight();
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RotateDiagonal45DegreesRight_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                Square.b2,
                                Square.g3,
                                Square.c7
                             );
                
            ulong expected = BitboardExtensions.FromSquares(
                                Square.b1,
                                Square.g5,
                                Square.c5
                             );

            ulong rotated = bitboard.RotateDiagonal45DegreesRight();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void RotateDiagonal45DegreesLeft_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                Square.b1,
                                Square.g5,
                                Square.c5
                             );

            ulong expected = BitboardExtensions.FromSquares(
                                Square.b2,
                                Square.g3,
                                Square.c7
                             );

            ulong rotated = bitboard.RotateDiagonal45DegreesLeft();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void RotateAntidiagonal45DegreesRight_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                Square.a4,
                                Square.e1,
                                Square.g6
                             );

            ulong expected = BitboardExtensions.FromSquares(
                                Square.a3,
                                Square.e4,
                                Square.g7
                             );

            ulong rotated = bitboard.RotateAntidiagonal45DegreesRight();

            Assert.AreEqual(expected, rotated);
        }

        [TestMethod]
        public void RotateAntidiagonal45DegreesLeft_Ok()
        {
            ulong bitboard = BitboardExtensions.FromSquares(
                                Square.a3,
                                Square.e4,
                                Square.g7
                             );

            ulong expected = BitboardExtensions.FromSquares(
                                Square.a4,
                                Square.e1,
                                Square.g6
                             );

            ulong rotated = bitboard.RotateAntidiagonal45DegreesLeft();

            Assert.AreEqual(expected, rotated);
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
