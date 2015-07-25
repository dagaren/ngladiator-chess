using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation.Bitboard
{
    static class BitboardExtensions
    {
        static int[] index64 = {
                0, 47,  1, 56, 48, 27,  2, 60,
                57, 49, 41, 37, 28, 16,  3, 61,
                54, 58, 35, 52, 50, 42, 21, 44,
                38, 32, 29, 23, 17, 11,  4, 62,
                46, 55, 26, 59, 40, 36, 15, 53,
                34, 51, 20, 43, 31, 22, 10, 45,
                25, 39, 14, 33, 19, 30,  9, 24,
                13, 18,  8, 12,  7,  6,  5, 63
            };

        const ulong debruijn64 = 0x03f79d71b4cb0a89UL;

        public const ulong Empty = 0UL;

        public static ulong Inverse(this ulong bitboard)
        {
            return ~bitboard;
        }

        public static ulong ShiftLeft(this ulong bitboard, int offset)
        {
            return bitboard >> offset;
        }

        public static ulong ShiftRight(this ulong bitboard, int offset)
        {
            return bitboard << offset;
        }

        public static ulong Or(this ulong bitboard, ulong secondBitboard)
        {
            return bitboard | secondBitboard;
        }

        public static ulong And(this ulong bitboard, ulong secondBitboard)
        {
            return bitboard & secondBitboard;
        }

        public static ulong Xor(this ulong bitboard, ulong secondBitboard)
        {
            return bitboard ^ secondBitboard;
        }

        public static ulong Unset(this ulong bitboard, ulong secondBitboard)
        {
            return bitboard & ~secondBitboard;
        }

        public static int BitCount(this ulong bitboard)
        {
            bitboard = bitboard - ((bitboard >> 1) & 0x5555555555555555UL);
            bitboard = (bitboard & 0x3333333333333333UL) + ((bitboard >> 2) & 0x3333333333333333UL);
            bitboard = (bitboard + (bitboard >> 4)) & 0x0f0f0f0f0f0f0f0fUL;
            bitboard = bitboard + (bitboard >> 8);
            bitboard = bitboard + (bitboard >> 16);
            bitboard = bitboard + (bitboard >> 32);
            return (int)bitboard & 0x7f;
        }

        public static int FirstBitScan(this ulong bitboard)
        {
            if(bitboard == 0UL)
            {
                return -1;
            }

            return index64[((bitboard ^ (bitboard - 1)) * debruijn64) >> 58];
        }

        public static Square FirstSquareScan(this ulong bitboard)
        {
            return (Square)FirstBitScan(bitboard);
        }
    }
}
