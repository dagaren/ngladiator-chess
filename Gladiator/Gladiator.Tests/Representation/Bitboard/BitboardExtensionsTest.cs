using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class BitboardExtensionsTest
    {
        [TestMethod]
        public void Inverse_EmptyBitboard_FullBitboardExpected()
        {
            ulong empty = ulong.MinValue;
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
            ulong bitboard = 4;
            ulong shifted = bitboard.ShiftLeft(1);
            Assert.AreEqual(2UL, shifted);
        }

        [TestMethod]
        public void ShiftLeft_ThreePosition_Ok()
        {
            ulong bitboard = 8;
            ulong shifted = bitboard.ShiftLeft(3);
            Assert.AreEqual(1UL, shifted);
        }

        [TestMethod]
        public void ShifRight_OnePosition_Ok()
        {
            ulong bitboard = 2;
            ulong shifted = bitboard.ShiftRight(1);
            Assert.AreEqual(4UL, shifted);
        }

        [TestMethod]
        public void ShiftRight_ThreePosition_Ok()
        {
            ulong bitboard = 1;
            ulong shifted = bitboard.ShiftRight(3);
            Assert.AreEqual(8UL, shifted);
        }

        [TestMethod]
        public void Or_DifferentBitboards_Ok()
        {
            const ulong firstBitboard = 1;
            const ulong secondBitboard = 4;
            const ulong expectedOrResult = 5;

            ulong orResult = firstBitboard.Or(secondBitboard);
            Assert.AreEqual(expectedOrResult, orResult);
        }

        [TestMethod]
        public void Or_SameBitboards_Ok()
        {
            const ulong bitboard = 4;
            const ulong expectedOrResult = 4;

            ulong orResult = bitboard.Or(bitboard);
            Assert.AreEqual(expectedOrResult, orResult);
        }

        [TestMethod]
        public void And_DifferentBitboards_Ok()
        {
            const ulong firstBitboard = 12;
            const ulong secondBitboard = 5;
            const ulong expectedAndResult = 4;

            ulong andResult = firstBitboard.And(secondBitboard);
            Assert.AreEqual(expectedAndResult, andResult);
        }

        [TestMethod]
        public void And_SameBitboards_Ok()
        {
            const ulong bitboard = 4;
            const ulong expectedAndResult = 4;

            ulong andResult = bitboard.And(bitboard);
            Assert.AreEqual(expectedAndResult, andResult);
        }

        [TestMethod]
        public void Xor_DifferentBitboards_Ok()
        {
            const ulong firstBitboard = 12;
            const ulong secondBitboard = 5;
            const ulong expectedXorResult = 9;

            ulong xorResult = firstBitboard.Xor(secondBitboard);
            Assert.AreEqual(expectedXorResult, xorResult);
        }

        [TestMethod]
        public void Xor_SameBitboards_Ok()
        {
            const ulong bitboard = 4;
            const ulong expectedXorResult = 0;

            ulong xorResult = bitboard.Xor(bitboard);
            Assert.AreEqual(expectedXorResult, xorResult);
        }

        [TestMethod]
        public void Unset_DifferentBitboards_Ok()
        {
            const ulong firstBitboard = 12;
            const ulong secondBitboard = 5;
            const ulong expectedUnsetResult = 8;

            ulong unsetResult = firstBitboard.Unset(secondBitboard);
            Assert.AreEqual(expectedUnsetResult, unsetResult);
        }

        [TestMethod]
        public void Unset_SameBitboard_Ok()
        {
            const ulong bitboard = 4;
            const ulong expectedUnsetResult = 0;

            ulong unsetResult = bitboard.Unset(bitboard);
            Assert.AreEqual(expectedUnsetResult, unsetResult);
        }

        [TestMethod]
        public void BitCount_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = 0L;
            const int expectedCount = 0;

            int count = bitboard.BitCount();
            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void BitCount_FullBitboard_SixtyFourExpected()
        {
            const ulong bitboard = ulong.MaxValue;
            const int expectedCount = 64;

            int count = bitboard.BitCount();
            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void FirstBitScan_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = ulong.MinValue;
            const int expectedPosition = -1;

            int position = bitboard.FirstBitScan();
            Assert.AreEqual(expectedPosition, position);
        }

        [TestMethod]
        public void FirstBitScan_Ok()
        {
            const ulong bitboard = 12;
            const int expectedPosition = 2;

            int position = bitboard.FirstBitScan();
            Assert.AreEqual(expectedPosition, position);
        }

        [TestMethod]
        public void FirstSquareScan_EmptyBitboard_ZeroExpected()
        {
            const ulong bitboard = ulong.MinValue;
            const Square expectedSquare = Square.None;

            Square square = bitboard.FirstSquareScan();
            Assert.AreEqual(expectedSquare, square);
        }

        [TestMethod]
        public void FirstSquareScan_Ok()
        {
            const ulong bitboard = 12;
            const Square expectedSquare = Square.c1;

            Square square = bitboard.FirstSquareScan();
            Assert.AreEqual(expectedSquare, square);
        }
    }
}
