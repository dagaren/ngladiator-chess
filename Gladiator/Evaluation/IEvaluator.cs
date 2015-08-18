using Gladiator.Representation;
using System;

namespace Gladiator.Evaluation
{
    public interface IEvaluator
    {
        int Evaluate(IPosition<IBoard> position);
    }
}
