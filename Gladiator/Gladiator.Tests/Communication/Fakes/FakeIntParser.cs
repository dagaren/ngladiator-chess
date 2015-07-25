using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Fakes
{
    public class FakeIntParser : IParser<int>
    {
        public const int ExpectedValue = int.MaxValue;

        public int Parse(string text)
        {
            return ExpectedValue;
        }
    }
}
