using Gladiator.Representation;
using System;

namespace Gladiator.Search
{
    public class TranspositionEntry
    {
        public TranspositionEntryType EntryType { get; set; }

        public int Depth { get; set; }

        public int Score { get; set; }

        public int Age { get; set; }

        public ulong PositionHash { get; set; }

        public Move BestMove { get; set; }

        public TranspositionEntry()
        {
            this.Depth = 0;
        }

        public void Init(ulong positionHash,
                              int depth,
                              int score,
                              TranspositionEntryType entryType,
                              Move bestMove)
        {
            this.PositionHash = positionHash;
            this.Depth = depth;
            this.Score = score;
            this.EntryType = entryType;
            this.BestMove = bestMove;
        }
    }
}
