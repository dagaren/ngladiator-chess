using Gladiator.Communication;
using Gladiator.Communication.Protocols;
using Gladiator.Communication.Protocols.XBoard;
using System;
using System.Collections.Generic;
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
            ICommandFactory commandFactory = new CommandFactory();
            List<ICommandMatcher<ICommand>> commandMatchers = new List<ICommandMatcher<ICommand>>();
            commandMatchers.Add(new XBoardCommandMatcher(commandFactory));
            commandMatchers.Add(new QuitCommandMatcher(commandFactory));
            ICommandReader commandReader = new ConsoleCommandReader();
            ICommandWriter commandWriter = new ConsoleCommandWriter();
            IProtocol protocol = new XBoardProtocol(commandMatchers);
            return new Controller(commandReader, commandWriter, protocol);
        }

        private static void Initialize()
        {
            TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(writer);
        }
    }
}
