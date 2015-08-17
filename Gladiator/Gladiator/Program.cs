using Gladiator.Communication;
using Gladiator.Communication.XBoard;
using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Gladiator.Utils.Reflection;
using Gladiator.Communication.XBoard.Output;
using Gladiator.Utils;
using System.IO;
using Gladiator.Core;
using Gladiator.Search;

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
            string commandLogPath = Path.Combine(EnvironmentExtensions.GetExecutablePath(), "CommandLog.txt");

            IDictionary<string, object> container = new Dictionary<string, object>();
            IConstructorRetriever constructorRetriever = new SingleConstructorRetriever();
            IConstructorInvoker constructorInvoker = new ConstructorInvoker();
            ICommandFactory commandFactory = new CommandFactory(container, constructorRetriever, constructorInvoker);
            
            ICommandReader commandReader = new LoggedCommandReader(commandLogPath, new ConsoleCommandReader());
            ICommandWriter commandWriter = new LoggedCommandWriter(commandLogPath, new  ConsoleCommandWriter());
            List<ICommandMatcher<ICommand>> commandMatchers = GetCommandMatcheers(commandFactory);
            IProtocol protocol = new XBoardProtocol(commandMatchers);
            var controller = new Controller(commandReader, protocol);
            controller.OnException += ex =>
            {
                ConsoleExtensions.WriteLineColoured("Exception catched: " + ex.Message, ConsoleColor.Red);
                System.IO.File.AppendAllText(commandLogPath, "=== Exception: " + ex.Message +
                    " " + ex.StackTrace.ToString() + Environment.NewLine);
            };
            var kingMoveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            var knightMoveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            var rookMoveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();
            var bishopMoveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            var queenMoveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();
            var pawnMoveGenerator = new BitboardPawnMoveGenerator<Position<BitboardBoard>>();
            IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] moveGenerators = new IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] {
                kingMoveGenerator,
                knightMoveGenerator,
                rookMoveGenerator,
                bishopMoveGenerator,
                queenMoveGenerator,
                pawnMoveGenerator
            };
            IPositionValidator<Position<BitboardBoard>, BitboardBoard> positionValidator = new InCheckPositionValidator<Position<BitboardBoard>>();
            var compositeMoveGenerator = new CompositeMoveGenerator<Position<BitboardBoard>, BitboardBoard>(moveGenerators);
            BitboardBoard board = new BitboardBoard();
            var initialPositionBuilder = new InitialChessPositionBuilder<BitboardBoard>(compositeMoveGenerator, positionValidator);
            var illegalMoveCommand = new IllegalMoveCommand(commandWriter);
            var featureCommand  = new FeatureCommand(commandWriter);
            var errorCommand = new ErrorCommand(commandWriter);
            var moveCommand = new MoveCommand(commandWriter);

            ISearcher searcher = new RandomSearcher();
            IEngine engine = new Engine(searcher);
            engine.OnMoveDone += moveCommand.Execute;

            container["illegalMoveAction"] = new Action<Move, string>(illegalMoveCommand.Execute);
            container["quitAction"] = new Action(controller.Finish);
            container["initialPositionBuilder"] = initialPositionBuilder;
            container["commandWriter"] = commandWriter;
            container["featureCommandAction"] = new Action(featureCommand.Execute);
            container["errorAction"] = new Action<string, string>(errorCommand.Execute);
            container["engine"] = engine;

            return controller;
        }

        private static List<ICommandMatcher<ICommand>> GetCommandMatcheers(ICommandFactory commandFactory)
        {
            List<ICommandMatcher<ICommand>> commandMatchers = new List<ICommandMatcher<ICommand>>();
            commandMatchers.Add(new XBoardCommandMatcher(commandFactory));
            commandMatchers.Add(new QuitCommandMatcher(commandFactory));
            commandMatchers.Add(new UserMoveCommandMatcher(commandFactory));
            commandMatchers.Add(new LevelCommandMatcher(commandFactory));
            commandMatchers.Add(new MoveNowCommandMatcher(commandFactory));
            commandMatchers.Add(new ForceCommandMatcher(commandFactory));
            commandMatchers.Add(new GoCommandMatcher(commandFactory));
            commandMatchers.Add(new PlayOtherCommandMatcher(commandFactory));
            commandMatchers.Add(new DrawCommandMatcher(commandFactory));
            commandMatchers.Add(new ResultCommandMatcher(commandFactory));
            commandMatchers.Add(new PostCommandMatcher(commandFactory));
            commandMatchers.Add(new NoPostCommandMatcher(commandFactory));
            commandMatchers.Add(new EasyCommandMatcher(commandFactory));
            commandMatchers.Add(new HardCommandMatcher(commandFactory));
            commandMatchers.Add(new ProtoverCommandMatcher(commandFactory));
            commandMatchers.Add(new AcceptedCommandMatcher(commandFactory));
            commandMatchers.Add(new RejectedCommandMatcher(commandFactory));
            commandMatchers.Add(new NewCommandMatcher(commandFactory));
            commandMatchers.Add(new RandomCommandMatcher(commandFactory));
            commandMatchers.Add(new ComputerCommandMatcher(commandFactory));
            commandMatchers.Add(new UnknownCommandCommandMatcher(commandFactory));

            return commandMatchers;
        }

        private static void Initialize()
        {
            TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(writer);
        }
    }
}
