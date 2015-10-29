using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Representation.Notation;
using Gladiator.Search;
using Gladiator.Search.AlphaBeta;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTester
{
    class Program
    {
        private static string[] middleGamePositions = {
            "rn1qkb1r/pp2pppp/5n2/3p1b2/3P4/2N1P3/PP3PPP/R1BQKBNR w KQkq - 0 1"
        };

        private static string[] endGamePositions = {
            "8/1ppr1kp1/p1p4p/8/8/5P2/PPP1RKPP/8 w - - 0 1"
        };

        static void Main(string[] args)
        {
            ConsoleExtensions.WriteLineColoured("Performance testing", ConsoleColor.Green);

            var fenParser = new FenParser<BitboardBoard>(GetPositionBuilder());
            Position<BitboardBoard> position = fenParser.Parse(middleGamePositions[0]);

            Console.WriteLine(position.Board.Format());
            Console.WriteLine("Turn: " + position.Turn);
            
            IEvaluator materialEvaluator = new MaterialEvaluator();
            IEvaluator positionEvaluator = new PositionEvaluator();
            IEvaluator staticEvaluator = new CompositeEvaluator(materialEvaluator, positionEvaluator);
            INodeCounter nodeCounter = new NodeCounter();
            //var positionBuilder = GetInitialPositionBuilder();

            /////////////////////////////////////////////
            int depth = 5;
            var strategyBuilder = new AlphaBetaStrategyBuilder()
                                .WithIterativeDeepening()
                                .WithQuiescenceSearch()
                                .WithNodeCounter(nodeCounter)
                                .WithStaticEvaluator(staticEvaluator);
            ConsoleExtensions.WriteLineColoured("Testing normal", ConsoleColor.Yellow);
            //TestPerformance(position, strategyBuilder, nodeCounter, depth);

            nodeCounter = new NodeCounter();
            strategyBuilder = new AlphaBetaStrategyBuilder()
                                .WithAspirationWindow()
                                .WithIterativeDeepening()
                                .WithQuiescenceSearch()
                                .WithNodeCounter(nodeCounter)
                                .WithStaticEvaluator(staticEvaluator);

            ConsoleExtensions.WriteLineColoured("Testing with aspiration windows", ConsoleColor.Yellow);
            //TestPerformance(position, strategyBuilder, nodeCounter, depth);

            nodeCounter = new NodeCounter();
            strategyBuilder = new AlphaBetaStrategyBuilder()
                                .WithAspirationWindow()
                                .WithIterativeDeepening()
                                .WithQuiescenceSearch()
                                .WithNodeCounter(nodeCounter)
                                .WithTransposicionTable(new TranspositionTable(500000))
                                .WithStaticEvaluator(staticEvaluator);

            ConsoleExtensions.WriteLineColoured("Testing with aspiration windows, and transposition table", ConsoleColor.Yellow);
            TestPerformance(position, strategyBuilder, nodeCounter, depth);
            /////////////////////////////////////////////

            ConsoleExtensions.WriteLineColoured("- Normal termination of the program -", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void TestPerformance(IPosition<IBoard> position, AlphaBetaStrategyBuilder strategyBuilder, INodeCounter nodeCounter,  int depth)
        {
            var searchOptions = new SearchOptions();
            searchOptions.SearchDepth = depth;
            ISearcher searcher = new AlphaBetaSearcher(strategyBuilder);

            var stopwatch = Stopwatch.StartNew();
            ISearchExecution searchExecution = searcher.InitSearch(position, searchOptions);
            searchExecution.Init();
            searchExecution.Wait();

            TimeSpan searchTime = stopwatch.Elapsed;
            stopwatch.Stop();
            double speed = nodeCounter.GetValue() / (searchTime.TotalSeconds * 1000);

            Console.WriteLine("# Nodes searched: {0}", nodeCounter.GetValue());
            Console.WriteLine("# Search time: {0} segundos", (int)searchTime.TotalSeconds);
            Console.WriteLine("# Speed: {0:0.##} kN/s", speed);
        }

        public static InitialChessPositionBuilder<BitboardBoard> GetInitialPositionBuilder()
        {
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
            return new InitialChessPositionBuilder<BitboardBoard>(compositeMoveGenerator, positionValidator);
        }

        public static PositionBuilder<BitboardBoard> GetPositionBuilder()
        {
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
            return new PositionBuilder<BitboardBoard>(compositeMoveGenerator, positionValidator);
        }
    }
}
