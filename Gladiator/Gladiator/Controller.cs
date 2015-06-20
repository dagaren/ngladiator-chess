using Gladiator.Communication;
using Gladiator.Communication.Protocols;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    internal class Controller : IController
    {
        private ICommandReader commandReader;

        private ICommandWriter commandWriter;

        private IProtocol protocol;

        private bool exit;

        public Controller(ICommandReader commandReader, ICommandWriter commandWriter, IProtocol protocol)
        {
            Check.ArgumentNotNull(commandReader, "commandReader");
            Check.ArgumentNotNull(commandWriter, "commandWriter");
            Check.ArgumentNotNull(protocol, "protocol");

            this.commandReader = commandReader;
            this.commandWriter = commandWriter;
            this.protocol = protocol;
        }

        public void Run()
        {
            exit = false;

            while (!exit)
            {
                try
                {
                    string command = this.commandReader.Read();

                    if(command == "quit")
                    {
                        exit = true;
                    }

                    this.protocol.ProcessCommand(command);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(string.Format("Exception catched processing command: {0}", ex.Message));
                }
            }
        }

        public void Finish()
        {
            exit = true;
        }
    }
}
