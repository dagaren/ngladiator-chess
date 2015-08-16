using Gladiator.Communication;
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
        public event Action<Exception> OnException;

        private ICommandReader commandReader;

        private IProtocol protocol;

        private bool exit;

        public Controller(
            ICommandReader commandReader,  
            IProtocol protocol)
        {
            Check.ArgumentNotNull(commandReader, "commandReader");
            Check.ArgumentNotNull(protocol, "protocol");

            this.commandReader = commandReader;
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

                    this.protocol.ProcessCommand(command);
                }
                catch(Exception ex)
                {
                    OnException(ex);
                }
            }
        }

        public void Finish()
        {
            exit = true;
        }
    }
}
