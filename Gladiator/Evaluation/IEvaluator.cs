using Gladiator.Representation;
using System;

namespace Gladiator.Evaluation
{
    public interface IEvaluator<in TPosition, out TBoard> where TPosition : IPosition<TBoard>
    {
        int Evaluate(TPosition position);
    }
}
