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
        public void ExecuteOk()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                XBoardCommand command = new XBoardCommand();
                command.Execute();

                string expected = "XBoard command received" + System.Environment.NewLine;
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            StreamWriter standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }
    }
}
