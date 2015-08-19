using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Evaluation
{
    public class CompositeEvaluator : IEvaluator
    {
        private readonly IEnumerable<IEvaluator> evaluators;

        public CompositeEvaluator(params IEvaluator[] evaluators)
        {
            this.evaluators = evaluators;
        }

        public int Evaluate(IPosition<IBoard> position)
        {
            int score = 0;

            foreach(IEvaluator evaluator in evaluators)
            {
                score += evaluator.Evaluate(position);
            }

            return score;
        }
    }
}
