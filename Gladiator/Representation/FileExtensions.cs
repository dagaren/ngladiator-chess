using System;

namespace Gladiator.Representation
{
    public static class FileExtensions
    {
        public static int GetValue(this File file)
        {
            return (int)file;
        }

        public static File Next(this File file)
        {
            if (file < File.h)
            {
                return file + 1;
            }
            else
            {
                return File.None;
            }
        }

        public static File Previous(this File file)
        {
            if (file > File.a)
            {
                return file - 1;
            }
            else
            {
                return File.None;
            }
        }
    }
}
