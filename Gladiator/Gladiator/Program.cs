using Gladiator.Communication;
using Gladiator.Communication.Protocols;
using Gladiator.Communication.Protocols.XBoard;
using System;
using System.Diagnostics;

namespace Gladiator
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();

            IController controller = GetController();

            controller.Run();
        }

        private static IController GetController()
        {
            ICommandReader commandReader = new ConsoleCommandReader();
            ICommandWriter commandWriter = new ConsoleCommandWriter();
            ICommandFactory commandFactory = new CommandFactory();
            IProtocol protocol = new XBoardProtocol(commandFactory);
            return new Controller(commandReader, commandWriter, protocol);
        }

        private static void Initialize()
        {
            TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(writer);
        }
    }
}
