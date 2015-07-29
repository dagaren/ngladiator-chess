using System;

namespace Gladiator.Representation.Bitboard
{
    static class RotationBitboardExtensions
    {
        public static ulong Rotate90DegreesLeft(this ulong bitboard)
        {
            return bitboard.FlipVertical().FlipDiagonal();
        }

        public static ulong Rotate90DegreesRight(this ulong bitboard)
        {
            return bitboard.FlipDiagonal().FlipVertical();
        }

        public static ulong FlipDiagonal(this ulong bitboard)
        {
            ulong a;
            const ulong b = 0x5500550055005500UL;
            const ulong c = 0x3333000033330000UL;
            const ulong d = 0x0F0F0F0F00000000UL;

            a = d & (bitboard ^ (bitboard << 28));
            bitboard ^= a ^ (a >> 28);
            a = c & (bitboard ^ (bitboard << 14));
            bitboard ^= a ^ (a >> 14);
            a = b & (bitboard ^ (bitboard << 7));
            bitboard ^= a ^ (a >> 7);

            return bitboard;
        }

        public static ulong FlipVertical(this ulong bitboard)
        {
            return (bitboard & 0x00000000000000FFUL) << 56 | (bitboard & 0x000000000000FF00UL) << 40 |
                   (bitboard & 0x0000000000FF0000UL) << 24 | (bitboard & 0x00000000FF000000UL) << 8  |
                   (bitboard & 0x000000FF00000000UL) >> 8  | (bitboard & 0x0000FF0000000000UL) >> 24 |
                   (bitboard & 0x00FF000000000000UL) >> 40 | (bitboard & 0xFF00000000000000UL) >> 56;
        }
    }
}
