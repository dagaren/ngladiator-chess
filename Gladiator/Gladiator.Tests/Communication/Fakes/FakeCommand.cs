using Gladiator.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Fakes
{
    class FakeCommand : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
