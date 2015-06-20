using Gladiator.Communication;
using Gladiator.Tests.Communication.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication
{
    [TestClass]
    public class CommandFactoryTest
    {
        [TestMethod]
        public void Construct_Ok()
        {
            var commandFactory = new CommandFactory();

            ICommand command = commandFactory.Construct<FakeCommand>(null);

            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(FakeCommand));
        }
    }
}
