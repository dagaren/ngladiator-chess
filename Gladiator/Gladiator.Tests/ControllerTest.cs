using Gladiator.Communication;
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
            IProtocol protocolMock = Substitute.For<IProtocol>();

            commandReaderMock.Read().Returns("xboard", "quit");
            Controller controller = new Controller(commandReaderMock, protocolMock);
            protocolMock.When(x => x.ProcessCommand("quit")).Do(x => controller.Finish());

            controller.Run();

            protocolMock.Received().ProcessCommand("xboard");
            protocolMock.Received().ProcessCommand("quit");
        }
    }
}
