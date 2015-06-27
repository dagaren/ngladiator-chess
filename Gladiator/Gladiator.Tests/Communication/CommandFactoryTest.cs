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
            IDictionary<string, object> container = new Dictionary<string, object>();
            var commandFactory = new CommandFactory(container);

            ICommand command = commandFactory.Construct<FakeCommand>(null);

            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(FakeCommand));
        }

        [TestMethod]
        public void Construct_CommandWithManyConstructors_ArgumentExceptionThrown()
        {
            IDictionary<string, object> container = new Dictionary<string, object>();
            var commandFactory = new CommandFactory(container);

            bool exceptionThrown = false;

            try
            {
                ICommand command = commandFactory.Construct<FakeCommandWithMultipleConstructors>(null);
            }
            catch(ArgumentException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void Construct_CommandWithParameterizedConstructor_Ok()
        {
            int expectedValue = 10;
            IDictionary<string, object> container = new Dictionary<string, object>();
            container["value"] = expectedValue;
            var commandFactory = new CommandFactory(container);

            var command = commandFactory.Construct<FakeCommandWithParameterizedConstructor>(null);

            Assert.IsNotNull(command);
            Assert.AreEqual<int>(expectedValue, command.Value);
            Assert.IsInstanceOfType(command, typeof(FakeCommandWithParameterizedConstructor));
        }
    }
}
