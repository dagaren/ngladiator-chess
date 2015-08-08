using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    public static class FileExtensions
    {
        public readonly static ulong[] Files = new ulong[8];

        static FileExtensions()
        {
            ulong fileBitboard = 0x0101010101010101UL;
            foreach (File file in EnumExtensions.GetValues<File>())
            {
                if (file == File.None)
                {
                    continue;
                }

                Files[file.GetValue()] = fileBitboard;
                fileBitboard = fileBitboard.ShiftRight(1);
            }
        }

        public static ulong GetBitboard(this File file)
        {
            return Files[(int)file];
        }
    }
}
