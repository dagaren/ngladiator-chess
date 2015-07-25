using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using System;

namespace Gladiator.Tests.Representation.Builders
{
    class BitboardPositionBuilder : PositionBuilder<BitboardBoard>
    {
        public BitboardPositionBuilder(IMoveGenerator<Position<BitboardBoard>, BitboardBoard> moveGenerator) 
            : base(new BitboardBoard(), moveGenerator)
        {
        }
    }
}
