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
    public class ConsoleCommandWriterTest
    {
        [TestMethod]
        public void Write_Ok()
        {
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);

                var commandWriter = new ConsoleCommandWriter();
                string command = "command";
                string expectedCommand = command + System.Environment.NewLine;

                commandWriter.Write(command);

                string commandWritten = writer.ToString();

                Assert.AreEqual<string>(expectedCommand, commandWritten);
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
