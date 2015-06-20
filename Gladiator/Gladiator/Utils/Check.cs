using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    public static class Check
    {
        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if(argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
