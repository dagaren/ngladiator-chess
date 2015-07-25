using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    static class FileExtensions
    {
        public static int GetValue(this File file)
        {
            return (int)file;
        }
    }
}
