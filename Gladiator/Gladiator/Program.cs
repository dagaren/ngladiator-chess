using Gladiator.Communication;
using Gladiator.Communication.Protocols;
using Gladiator.Communication.Protocols.XBoard;
using System;
using System.Collections.Generic;

namespace Gladiator
{
    class Program
    {
        static void Main(string[] args)
        {
            IController controller = GetController();

            controller.Run();
        }

        private static IController GetController()
        {
            IDictionary<string, object> container = new Dictionary<string, object>();
            ICommandFactory commandFactory = new CommandFactory(container);
            ICommandReader commandReader = new ConsoleCommandReader();
            ICommandWriter commandWriter = new ConsoleCommandWriter();
            IProtocol protocol = new XBoardProtocol(commandFactory);
            return new Controller(commandReader, commandWriter, protocol);
        }
    }
}
