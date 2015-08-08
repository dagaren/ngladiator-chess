using Gladiator.Communication;
using Gladiator.Communication.Tests.Builders;
using Gladiator.Communication.Tests.Fakes;
using Gladiator.Utils.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Communication.Tests
{
    [TestClass]
    public class CommandFactoryTest
    {
        private const string ParameterName = "value";

        private const int ParameterValue = 16;

        [TestMethod]
        public void Construct_ParameterFromContainer_Ok()
        {
            var parameters = new Dictionary<string, string>();

            var commandFactory = new CommandFactoryBuilder()
                                    .WithContainerParameter(ParameterName, ParameterValue)
                                    .Build();

            var command = commandFactory.Construct<FakeCommandWithParameterizedConstructor>(parameters) as FakeCommandWithParameterizedConstructor;

            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(FakeCommandWithParameterizedConstructor));
            Assert.AreEqual(ParameterValue, command.Value);
        }

        [TestMethod]
        public void Construct_ParameterFromInputDictionary_Ok()
        {
            var parameters = new Dictionary<string, string>()
                {
                   { ParameterName, ParameterValue.ToString() }
                };

            var commandFactory = new CommandFactoryBuilder().Build();

            var command = commandFactory.Construct<FakeCommandWithParameterizedConstructor>(parameters) as FakeCommandWithParameterizedConstructor;

            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(FakeCommandWithParameterizedConstructor));
            Assert.AreEqual(ParameterValue, command.Value);
        }

        [TestMethod]
        public void Construct_ParameterWithCommandParameterAttribute_Ok()
        {
            var parameters = new Dictionary<string, string>()
                {
                   { ParameterName, ParameterValue.ToString() }
                };

            var commandFactory = new CommandFactoryBuilder().Build();

            var command = commandFactory.Construct<FakeCommandConstructorWithCommandParameterAttribute>(parameters) as FakeCommandConstructorWithCommandParameterAttribute;

            Assert.IsNotNull(command);
            Assert.IsInstanceOfType(command, typeof(FakeCommandConstructorWithCommandParameterAttribute));
            Assert.AreEqual(FakeIntParser.ExpectedValue, command.Value);
        }

        [TestMethod]
        public void Construct_ParameterNotFound_ArgumentExceptionExpected()
        {
            var parameters = new Dictionary<string, string>();

            var commandFactory = new CommandFactoryBuilder().Build();

            bool exceptionThrown = false;

            try
            {
                var command = commandFactory.Construct<FakeCommandWithParameterizedConstructor>(parameters) as FakeCommandWithParameterizedConstructor;
            }
            catch(ArgumentException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }
    }
}
