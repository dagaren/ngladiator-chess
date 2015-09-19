using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Utils
{
    public class DefaultParser<T> : IParser<T>
    {

        public T Parse(string input)
        {
            if(input == string.Empty)
            {
                return default(T);
            }
            else
            {
                return (T)Convert.ChangeType(input, typeof(T), CultureInfo.InvariantCulture);
            }
        }
    }
}
