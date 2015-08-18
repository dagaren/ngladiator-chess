using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaStaticEvaluationStrategy : IAlphaBetaStrategy
    {
        private IEvaluator staticEvaluator;

        private IAlphaBetaStrategy nextStrategy;

        public AlphaBetaStaticEvaluationStrategy(
            IEvaluator staticEvaluator,
            IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(staticEvaluator, "staticEvaluator");
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.staticEvaluator = staticEvaluator;
            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            if(searchStatus.RemainingPlies == 0)
            {
                int score = this.staticEvaluator.Evaluate(searchStatus.Position);
                
                return searchStatus.Position.Turn == Colour.White ? score : -score;
            }
            else
            {
                return this.nextStrategy.AlphaBeta(searchStatus);
            }
        }
    }
}
