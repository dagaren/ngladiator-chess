using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Core
{
    public class PrincipalVariationChange
    {
        public PrincipalVariationChange(int ply, int score, TimeSpan searchTime, long nodes, IEnumerable<Move> moves)
        {
            this.Ply = ply;
            this.Score = score;
            this.Nodes = nodes;
            this.SearchTime = searchTime;
            this.Moves = moves;
        }

        public int Ply { get; private set; }

        public int Score { get; private set; }

        public long Nodes { get; private set; }

        public TimeSpan SearchTime { get; private set; }

        public IEnumerable<Move> Moves { get; private set; }
    }
}
