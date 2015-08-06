using Gladiator.Communication.Protocols.XBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication.Protocols.XBoard
{
    [TestClass]
    public class XBoardCommandTest
    {
        [TestMethod]
        public void Execute_Ok()
        {
            XBoardCommand command = new XBoardCommand();
            command.Execute();
        }
    }
}
