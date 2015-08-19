using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Search.AlphaBeta;
using Gladiator.Utils;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Gladiator.Search
{
    public class AlphaBetaSearcher : BaseSearcher
    {
        private Action<string> commentWrite;

        private IEvaluator staticEvaluator;

        public AlphaBetaSearcher(IEvaluator staticEvaluator, Action<string> commentWrite)
        {
            Check.ArgumentNotNull(staticEvaluator, "staticEvaluator");
            Check.ArgumentNotNull(commentWrite, "commentWrite");

            this.staticEvaluator = staticEvaluator;
            this.commentWrite = commentWrite;
        }

        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, CancellationToken cancellationToken)
        {
            IPrincipalVariationManager principalVariationManager = new PrincipalVariation();

            var mainStrategy = new AlphaBetaMainStrategy(this.commentWrite);
            var staticEvaluationStrategy = new AlphaBetaStaticEvaluationStrategy(staticEvaluator, mainStrategy);
            var principalVariationStrategy = new PrincipalVariationAlphaBetaStrategy(principalVariationManager, staticEvaluationStrategy);
            var cancellationStrategy = new AlphaBetaCancellation(cancellationToken, principalVariationStrategy);
            var counterStrategy = new AlphaBetaCounterStrategy(cancellationStrategy);

            mainStrategy.RecursiveStrategy = counterStrategy;

            SearchStatus initialStatus = new SearchStatus()
            {
                Position = position,
                Alpha = AlphaBetaScore.InitialAlpha.Value(),
                Beta = AlphaBetaScore.InitialBeta.Value(),
                CurrentPly = 0,
                RemainingPlies = 6
            };

            var stopwatch = Stopwatch.StartNew();
            try
            {
                int score = cancellationStrategy.AlphaBeta(initialStatus);
                int nodesPerSecond = (int)(counterStrategy.PositionsVisited / stopwatch.Elapsed.TotalSeconds);

                commentWrite(string.Format("# Search time: {0:#.##} seconds", stopwatch.Elapsed.TotalSeconds));
                commentWrite(string.Format("# Nodes per second: {0}", nodesPerSecond));
                commentWrite(string.Format("# Result Score: {0}", score));
                commentWrite(string.Format("# Nodes visited: {0}", counterStrategy.PositionsVisited));
            }
            catch(OperationCanceledException)
            {
                Move move = principalVariationManager.GetMoves().FirstOrDefault();
                if(move == null)
                {
                    move = position.GetMoves(MoveSearchType.LegalMoves).Random();
                }

                return move;
            }
            finally
            {
                stopwatch.Stop();
            }

            return initialStatus.BestMove;
        }
    }
}
