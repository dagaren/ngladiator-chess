using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Representation.Tests.Builders;
using NSubstitute;
using System;

namespace Gladiator.Representation.Bitboard.Tests.Builders
{
    public class BitboardPositionBuilder : PositionBuilder<BitboardBoard>
    {
        public BitboardPositionBuilder(IMoveGenerator<Position<BitboardBoard>, BitboardBoard> moveGenerator) 
            : base(new BitboardBoard(), moveGenerator)
        {
        }

        public BitboardPositionBuilder()
            : this(Substitute.For<IMoveGenerator<Position<BitboardBoard>, BitboardBoard>>())
        {
        }
    }
}
