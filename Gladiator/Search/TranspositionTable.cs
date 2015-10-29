using Gladiator.Representation;
using System;

namespace Gladiator.Search
{
    public class TranspositionTable
    {
        private uint size;

        private TranspositionEntry[] entries;

        public TranspositionTable(uint size)
        {
            this.size = size;

            this.entries = new TranspositionEntry[this.size];
            for (int i = 0; i < this.size; i++)
            {
                this.entries[i] = new TranspositionEntry();
            }
        }

        public TranspositionEntry GetEntry(ulong positionHash)
        {
            TranspositionEntry entry = this.entries[positionHash % this.size];

            if(entry.PositionHash == positionHash)
            {
                return entry;
            }
            else
            {
                return null;
            }
        }

        public void SaveEntry(ulong positionHash,
                              int depth,
                              int score,
                              TranspositionEntryType entryType,
                              Move bestMove)
        {
            this.entries[positionHash % this.size].Init(positionHash, depth, score, entryType, bestMove);
        }
    }
}
