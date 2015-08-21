using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaStaticEvaluationStrategy : IAlphaBetaStrategy
    {
        private IEvaluator staticEvaluator;

        public AlphaBetaStaticEvaluationStrategy(IEvaluator staticEvaluator)
        {
            Check.ArgumentNotNull(staticEvaluator, "staticEvaluator");
            
            this.staticEvaluator = staticEvaluator;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            int score = this.staticEvaluator.Evaluate(searchStatus.Position);

            return searchStatus.Position.Turn == Colour.White ? score : -score;
        }
    }
}
