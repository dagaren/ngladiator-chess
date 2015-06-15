using Gladiator.Communication.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    internal class Controller : IController
    {
        internal const string XboardReceivedCommand = "> xboard received";

        internal const string QuitReceivedCommand = "> quit received";

        private ICommandReader commandReader;

        private ICommandWriter commandWriter;

        private IProtocol protocol;

        public Controller(ICommandReader commandReader, ICommandWriter commandWriter, IProtocol protocol)
        {
            if (commandReader ==  null)
            {
                throw new ArgumentNullException("commandReader");
            }

            if (commandWriter == null)
            {
                throw new ArgumentNullException("commandWriter");
            }

            if (protocol == null)
            {
                throw new ArgumentNullException("protocol");
            }

            this.commandReader = commandReader;
            this.commandWriter = commandWriter;
            this.protocol = protocol;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                try
                {
                    string command = this.commandReader.Read();

                    this.protocol.ProcessCommand(command);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(string.Format("Exception catched: {0}", ex.Message));
                }
            }
        }
    }
}
