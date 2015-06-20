using Gladiator.Communication.Protocols.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Protocols.XBoard
{
    [TestClass]
    public class QuitCommandTest
    {
        [TestMethod]
        public void Execute_Ok()
        {
            bool actionExecuted = false;

            var command = new QuitCommand(() => actionExecuted = true);
            command.Execute();

            Assert.IsTrue(actionExecuted);
        }
    }
}
