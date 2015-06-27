using Gladiator.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Fakes
{
    class FakeCommandWithParameterizedConstructor : ICommand
    {
        public int Value { private set; get; }

        public FakeCommandWithParameterizedConstructor(int value)
        {
            this.Value = value;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
