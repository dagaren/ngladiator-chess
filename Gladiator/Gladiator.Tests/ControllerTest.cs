using Gladiator.Communication.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Run_XboardCommandReceived_CommandRecognized()
        {
            ICommandReader commandReaderMock = Substitute.For<ICommandReader>();
            ICommandWriter commandWriterMock = Substitute.For<ICommandWriter>();
            IProtocol protocolMock = Substitute.For<IProtocol>();

            commandReaderMock.Read().Returns("xboard", "quit");

            IController controller = new Controller(commandReaderMock, commandWriterMock, protocolMock);
            controller.Run();

            protocolMock.Received().ProcessCommand("xboard");
        }
    }
}
