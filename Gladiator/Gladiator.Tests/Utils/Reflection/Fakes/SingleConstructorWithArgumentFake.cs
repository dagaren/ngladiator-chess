using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Utils.Reflection.Fakes
{
    class SingleConstructorWithArgumentFake
    {
        public int Parameter { get; private set; }

        public SingleConstructorWithArgumentFake(int parameter)
        {
            this.Parameter = parameter;
        }
    }
}
