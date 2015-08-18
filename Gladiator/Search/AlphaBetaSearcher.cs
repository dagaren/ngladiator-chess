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

        public AlphaBetaSearcher(Action<string> commentWrite)
        {
            Check.ArgumentNotNull(commentWrite, "commentWrite");

            this.commentWrite = commentWrite;
        }

        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, CancellationToken cancellationToken)
        {
            IPrincipalVariationManager principalVariationManager = new PrincipalVariation();
            IEvaluator staticEvaluator = new MaterialEvaluator();

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

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler((a, b) =>
            {
                int nodesPerSecond = (int)(counterStrategy.PositionsVisited / stopwatch.Elapsed.TotalSeconds);
                commentWrite(string.Format("# Nodes per second: {0}", nodesPerSecond));
            });

            try
            {
                timer.Enabled = true;
                int score = cancellationStrategy.AlphaBeta(initialStatus);

                commentWrite("# Result Score: " + score);
            }
            catch(Exception ex)
            {
                commentWrite("# Exception " + ex.Message);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                timer.Enabled = false;
            }

            return initialStatus.BestMove;
        }
    }
}
