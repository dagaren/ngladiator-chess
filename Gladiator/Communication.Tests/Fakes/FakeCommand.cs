using Gladiator.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Tests.Fakes
{
    class FakeCommand : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
