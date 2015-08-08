using System;

namespace Gladiator.Representation.Bitboard
{
    public static class RotationBitboardExtensions
    {
        public static ulong Rotate90DegreesLeft(this ulong bitboard)
        {
            return bitboard.FlipVertical().FlipDiagonal();
        }

        public static ulong Rotate90DegreesRight(this ulong bitboard)
        {
            return bitboard.FlipDiagonal().FlipVertical();
        }

        public static ulong RotateDiagonal45DegreesRight(this ulong bitboard)
        {
            const ulong k1 = 0xAAAAAAAAAAAAAAAAUL;
            const ulong k2 = 0xCCCCCCCCCCCCCCCCUL;
            const ulong k4 = 0xF0F0F0F0F0F0F0F0UL;
            bitboard ^= k1 & (bitboard ^ bitboard.RotateRight(8));
            bitboard ^= k2 & (bitboard ^ bitboard.RotateRight(16));
            bitboard ^= k4 & (bitboard ^ bitboard.RotateRight(32));

            return bitboard;
        }

        public static ulong RotateDiagonal45DegreesLeft(this ulong bitboard)
        {
            const ulong k1 = 0xAAAAAAAAAAAAAAAAUL;
            const ulong k2 = 0xCCCCCCCCCCCCCCCCUL;
            const ulong k4 = 0xF0F0F0F0F0F0F0F0UL;

            bitboard ^= k4 & (bitboard ^ bitboard.RotateLeft(32));
            bitboard ^= k2 & (bitboard ^ bitboard.RotateLeft(16));
            bitboard ^= k1 & (bitboard ^ bitboard.RotateLeft(8));

            return bitboard;
        }

        public static ulong RotateAntidiagonal45DegreesRight(this ulong bitboard)
        {
            const ulong k1 = 0x5555555555555555UL;
            const ulong k2 = 0x3333333333333333UL;
            const ulong k4 = 0x0F0F0F0F0F0F0F0FUL;

            bitboard ^= k4 & (bitboard ^ bitboard.RotateLeft(32));
            bitboard ^= k2 & (bitboard ^ bitboard.RotateLeft(16));
            bitboard ^= k1 & (bitboard ^ bitboard.RotateLeft(8));
            
            return bitboard;
        }

        public static ulong RotateAntidiagonal45DegreesLeft(this ulong bitboard)
        {
            const ulong k1 = 0x5555555555555555UL;
            const ulong k2 = 0x3333333333333333UL;
            const ulong k4 = 0x0F0F0F0F0F0F0F0FUL;

            bitboard ^= k1 & (bitboard ^ bitboard.RotateRight(8));
            bitboard ^= k2 & (bitboard ^ bitboard.RotateRight(16));
            bitboard ^= k4 & (bitboard ^ bitboard.RotateRight(32));
            
            return bitboard;
        }

        public static ulong RotateRight(this ulong bitboard, int offset)
        {
            return (bitboard >> offset) | (bitboard << (64 - offset));
        }

        public static ulong RotateLeft(this ulong bitboard, int offset)
        {
            return (bitboard << offset) | (bitboard >> (64 - offset));
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
