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
            var kingMoveGenerator = new BitboardKingMoveGenerator<Position<BitboardBoard>>();
            var knightMoveGenerator = new BitboardKnightMoveGenerator<Position<BitboardBoard>>();
            var rookMoveGenerator = new BitboardRookMoveGenerator<Position<BitboardBoard>>();
            var bishopMoveGenerator = new BitboardBishopMoveGenerator<Position<BitboardBoard>>();
            var queenMoveGenerator = new BitboardQueenMoveGenerator<Position<BitboardBoard>>();
            IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] moveGenerators = new IMoveGenerator<Position<BitboardBoard>, BitboardBoard>[] {
                kingMoveGenerator,
                knightMoveGenerator,
                rookMoveGenerator,
                bishopMoveGenerator,
                queenMoveGenerator
            };
            var compositeMoveGenerator = new CompositeMoveGenerator<Position<BitboardBoard>, BitboardBoard>(moveGenerators);
            BitboardBoard board = new BitboardBoard();
            var position = new Position<BitboardBoard>(board, compositeMoveGenerator);
            position.Board.PutPiece(ColouredPiece.WhiteKing, Square.e1);
            position.Board.PutPiece(ColouredPiece.BlackKing, Square.e8);
            position.Board.PutPiece(ColouredPiece.WhiteKnight, Square.b1);
            position.Board.PutPiece(ColouredPiece.WhiteKnight, Square.g1);
            position.Board.PutPiece(ColouredPiece.BlackKnight, Square.b8);
            position.Board.PutPiece(ColouredPiece.BlackKnight, Square.g8);
            position.Board.PutPiece(ColouredPiece.WhiteRook, Square.a1);
            position.Board.PutPiece(ColouredPiece.WhiteRook, Square.h1);
            position.Board.PutPiece(ColouredPiece.BlackRook, Square.a8);
            position.Board.PutPiece(ColouredPiece.BlackRook, Square.h8);
            position.Board.PutPiece(ColouredPiece.WhiteBishop, Square.c1);
            position.Board.PutPiece(ColouredPiece.WhiteBishop, Square.f1);
            position.Board.PutPiece(ColouredPiece.BlackBishop, Square.c8);
            position.Board.PutPiece(ColouredPiece.BlackBishop, Square.f8);
            position.Board.PutPiece(ColouredPiece.WhiteQueen, Square.d1);
            position.Board.PutPiece(ColouredPiece.BlackQueen, Square.d8);

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
