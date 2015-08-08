using Gladiator.Communication.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Communication.XBoard.Tests
{
    [TestClass]
    public class ProtoverCommandTest
    {
        [TestMethod]
        public void Execute_ProtocolGreaterThan1_FeatureCommandExpected()
        {
            TestProtover(protocolVersion: 2, actionExecutionExpected: true);
        }

        [TestMethod]
        public void Execute_ProtocolGreaterLessThan2_NoFeatureCommand()
        {
            TestProtover(protocolVersion: 1, actionExecutionExpected: false);
        }

        private void TestProtover(int protocolVersion, bool actionExecutionExpected)
        {
            bool actionExecuted = false;
            var protoverCommand = new ProtoverCommand(protocolVersion, () => { actionExecuted = true; });
            protoverCommand.Execute();

            Assert.AreEqual(actionExecutionExpected, actionExecuted);
        }
    }
}
