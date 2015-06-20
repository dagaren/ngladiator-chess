using Gladiator.Communication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Communication
{
    [TestClass]
    public class ConsoseCommandReaderTest
    {
        [TestMethod]
        public void Read_Ok()
        {
            string expectedCommand = "command";
            string command = expectedCommand + System.Environment.NewLine;

            using (StringReader reader = new StringReader(expectedCommand))
            {
                Console.SetIn(reader);

                var commandReader = new ConsoleCommandReader();
                
                string commandReceived = commandReader.Read();

                Assert.AreEqual<string>(expectedCommand, commandReceived);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            StreamReader standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardIn);
        }
    }
}
