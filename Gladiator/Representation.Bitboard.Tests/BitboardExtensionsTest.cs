using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Representation.Bitboard.Tests
{
    [TestClass]
    public class BitboardExtensionsTest
    {
        [TestMethod]
        public void Inverse_EmptyBitboard_FullBitboardExpected()
        {
            ulong empty = BitboardExtensions.Empty;
            ulong inverse = empty.Inverse();

            Assert.AreEqual(ulong.MaxValue, inverse);
        }

        [TestMethod]
        public void Inverse_FullBitboard_EmptyBitboardExpected()
        {
            ulong full = ulong.MaxValue;
            ulong inverse = full.Inverse();

            Assert.AreEqual(ulong.MinValue, inverse);
        }

        [TestMethod]
        public void ShiftLeft_OnePosition_Ok()
        {
            ulong bitboard = Square.c1.GetBitboard();
            ulong expectedResult = Square.b1.GetBitboard();

            ulong shifted = bitboard.ShiftLeft(1);
            Assert.AreEqual(expectedResult, shifted);
        }

        [TestMethod]
        public void ShiftLeft_ThreePosition_Ok()
        {
            ulong bitboard = Square.d1.GetBitboard();
            ulong expectedResult = Square.a1.GetBitboard();

            ulong shifted = bitboard.ShiftLeft(3);
            Assert.AreEqual(expectedResult, shifted);
        }

        [TestMethod]
        public void ShifRight_OnePosition_Ok()
        {
            ulong bitboard = Square.b1.GetBitboard();
            ulong expectedResult = Square.c1.GetBitboard();

            ulong shifted = bitboard.ShiftRight(1);
            Assert.AreEqual(expectedResult, shifted);
        }

        [TestMethod]
        public void ShiftRight_ThreePosition_Ok()
        {
            ulong bitboard = Square.a1.GetBitboard();
            ulong expectedResult = Square.d1.GetBitboard();

            ulong shifted = bitboard.ShiftRight(3);
            Assert.AreEqual(expectedResult, shifted);
        }

        [TestMethod]
        public void Or_DifferentBitboards_Ok()
        {
            ulong firstBitboard = Square.a1.GetBitboard();
            ulong secondBitboard = Square.c1.GetBitboard();
            ulong expectedOrResult = Square.c1.GetBitboard() | Square.a1.GetBitboard();

            ulong orResult = firstBitboard.Or(secondBitboard);
            Assert.AreEqual(expectedOrResult, orResult);
        }

        [TestMethod]
        public void Or_SameBitboards_Ok()
        {
            ulong bitboard = Square.c1.GetBitboard();
            ulong expectedOrResult = Square.c1.GetBitboard();

            ulong orResult = bitboard.Or(bitboard);
            Assert.AreEqual(expectedOrResult, orResult);
        }

        [TestMethod]
        public void And_DifferentBitboards_Ok()
        {
            ulong firstBitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            ulong secondBitboard = Square.c1.GetBitboard() | Square.a1.GetBitboard();
            ulong expectedAndResult = Square.c1.GetBitboard();

            ulong andResult = firstBitboard.And(secondBitboard);
            Assert.AreEqual(expectedAndResult, andResult);
        }

        [TestMethod]
        public void And_SameBitboards_Ok()
        {
            ulong bitboard = Square.d1.GetBitboard();
            ulong expectedAndResult = Square.d1.GetBitboard();

            ulong andResult = bitboard.And(bitboard);
            Assert.AreEqual(expectedAndResult, andResult);
        }

        [TestMethod]
        public void Xor_DifferentBitboards_Ok()
        {
            ulong firstBitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            ulong secondBitboard = Square.d1.GetBitboard() | Square.b1.GetBitboard();
            ulong expectedXorResult = Square.b1.GetBitboard() | Square.c1.GetBitboard();

            ulong xorResult = firstBitboard.Xor(secondBitboard);
            Assert.AreEqual(expectedXorResult, xorResult);
        }

        [TestMethod]
        public void Xor_SameBitboards_Ok()
        {
            ulong bitboard = Square.d1.GetBitboard();
            ulong expectedXorResult = BitboardExtensions.Empty;

            ulong xorResult = bitboard.Xor(bitboard);
            Assert.AreEqual(expectedXorResult, xorResult);
        }

        [TestMethod]
        public void Unset_DifferentBitboards_Ok()
        {
            ulong firstBitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            ulong secondBitboard = Square.d1.GetBitboard() | Square.b1.GetBitboard();
            ulong expectedUnsetResult = Square.c1.GetBitboard();

            ulong unsetResult = firstBitboard.Unset(secondBitboard);
            Assert.AreEqual(expectedUnsetResult, unsetResult);
        }

        [TestMethod]
        public void Unset_SameBitboard_Ok()
        {
            ulong bitboard = Square.d1.GetBitboard();
            ulong expectedUnsetResult = BitboardExtensions.Empty;

            ulong unsetResult = bitboard.Unset(bitboard);
            Assert.AreEqual(expectedUnsetResult, unsetResult);
        }

        [TestMethod]
        public void BitCount_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = BitboardExtensions.Empty;
            const int expectedCount = 0;

            int count = bitboard.BitCount();
            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void BitCount_FullBitboard_SixtyFourExpected()
        {
            ulong bitboard = BitboardExtensions.Empty.Inverse();
            const int expectedCount = 64;

            int count = bitboard.BitCount();
            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void FirstBitScan_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = BitboardExtensions.Empty;
            const int expectedPosition = -1;

            int position = bitboard.FirstBitScan();
            Assert.AreEqual(expectedPosition, position);
        }

        [TestMethod]
        public void FirstBitScan_Ok()
        {
            ulong bitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            const int expectedPosition = 2;

            int position = bitboard.FirstBitScan();
            Assert.AreEqual(expectedPosition, position);
        }

        [TestMethod]
        public void FirstSquareScan_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = BitboardExtensions.Empty;
            const Square expectedSquare = Square.None;

            Square square = bitboard.FirstSquareScan();
            Assert.AreEqual(expectedSquare, square);
        }

        [TestMethod]
        public void FirstSquareScan_Ok()
        {
            ulong bitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            const Square expectedSquare = Square.c1;

            Square square = bitboard.FirstSquareScan();
            Assert.AreEqual(expectedSquare, square);
        }

        ////////////////////////////////////////////////////
        [TestMethod]
        public void LastBitScan_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = BitboardExtensions.Empty;
            const int expectedPosition = -1;

            int position = bitboard.LastBitScan();
            Assert.AreEqual(expectedPosition, position);
        }

        [TestMethod]
        public void LastBitScan_Ok()
        {
            ulong bitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            const int expectedPosition = 3;

            int position = bitboard.LastBitScan();
            Assert.AreEqual(expectedPosition, position);
        }

        [TestMethod]
        public void LastSquareScan_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = BitboardExtensions.Empty;
            const Square expectedSquare = Square.None;

            Square square = bitboard.LastSquareScan();
            Assert.AreEqual(expectedSquare, square);
        }

        [TestMethod]
        public void LastSquareScan_Ok()
        {
            ulong bitboard = Square.c1.GetBitboard() | Square.d1.GetBitboard();
            const Square expectedSquare = Square.d1;

            Square square = bitboard.LastSquareScan();
            Assert.AreEqual(expectedSquare, square);
        }

        [TestMethod]
        public void RankBitboard_Ok()
        {
            ulong bitboard = Square.a1.GetBitboard() |
                             Square.b4.GetBitboard() |
                             Square.f4.GetBitboard() |
                             Square.a7.GetBitboard();
            Rank rank = Rank._4;

            ulong expected = Square.b4.GetBitboard() |
                             Square.f4.GetBitboard();

            ulong result = bitboard.RankBitboard(rank);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RankOccupation_Ok()
        {
            ulong bitboard = Square.a1.GetBitboard() |
                             Square.b4.GetBitboard() |
                             Square.f4.GetBitboard() |
                             Square.a7.GetBitboard();
            Rank rank = Rank._4;

            byte expected = 34;

            byte result = bitboard.RankOccupation(rank);

            Assert.AreEqual(result, expected);
        }
    }
}
