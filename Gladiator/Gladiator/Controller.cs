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

        public Controller(ICommandReader commandReader, ICommandWriter commandWriter)
        {
            if(commandReader ==  null)
            {
                throw new ArgumentNullException("commandReader");
            }

            if (commandWriter == null)
            {
                throw new ArgumentNullException("commandWriter");
            }

            this.commandReader = commandReader;
            this.commandWriter = commandWriter;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                string command = this.commandReader.Read();

                switch (command)
                {
                    case "xboard":
                        this.commandWriter.Write(XboardReceivedCommand);
                        break;
                    case "quit":
                        this.commandWriter.Write(QuitReceivedCommand);
                        exit = true;
                        break;
                }
            }
        }
    }
}
