using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using System;

namespace Gladiator.Evaluation.Bitboard
{
    public abstract class BitboardPositionEvaluator<TPosition> : IEvaluator<TPosition, BitboardBoard> where TPosition : IPosition<BitboardBoard>
    {
        public abstract int Evaluate(TPosition position);
    }
}
