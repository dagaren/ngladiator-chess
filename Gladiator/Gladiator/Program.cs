using Gladiator.Communication;
using Gladiator.Communication.Protocols;
using Gladiator.Communication.Protocols.XBoard;
using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Gladiator.Utils.Reflection;

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
            IDictionary<string, object> container = new Dictionary<string, object>();
            IConstructorRetriever constructorRetriever = new SingleConstructorRetriever();
            IConstructorInvoker constructorInvoker = new ConstructorInvoker();
            ICommandFactory commandFactory = new CommandFactory(container, constructorRetriever, constructorInvoker);
            List<ICommandMatcher<ICommand>> commandMatchers = new List<ICommandMatcher<ICommand>>();
            commandMatchers.Add(new XBoardCommandMatcher(commandFactory));
            commandMatchers.Add(new QuitCommandMatcher(commandFactory));
            commandMatchers.Add(new MoveCommandMatcher(commandFactory));
            ICommandReader commandReader = new ConsoleCommandReader();
            ICommandWriter commandWriter = new ConsoleCommandWriter();
            IProtocol protocol = new XBoardProtocol(commandMatchers);
            var controller = new Controller(commandReader, commandWriter, protocol);
            IMoveGenerator<Position<BitboardBoard>, BitboardBoard> moveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            BitboardBoard board = new BitboardBoard();
            var position = new Position<BitboardBoard>(board, moveGenerator);
            position.Board.PutPiece(ColouredPiece.WhiteKing, Square.e1);
            position.Board.PutPiece(ColouredPiece.BlackKing, Square.e8);
            container["quitAction"] = new Action(controller.Finish);
            container["position"] = position;
            container["commandWriter"] = commandWriter;

            position.Board.WriteConsolePretty();

            return controller;
        }

        private static void Initialize()
        {
            TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(writer);
        }
    }
}
