using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaTranspositionTableStrategy : IAlphaBetaStrategy
    {
        private readonly TranspositionTable transpositionTable;

        private readonly IAlphaBetaStrategy nextStrategy;

        private readonly ZobristKeyGenerator zobristKeyGenerator;

        public AlphaBetaTranspositionTableStrategy(
            TranspositionTable transpositionTable,
            IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(transpositionTable, "transpositionTable");
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.transpositionTable = transpositionTable;
            this.nextStrategy = nextStrategy;
            this.zobristKeyGenerator = new ZobristKeyGenerator();
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            ulong positionHash = this.zobristKeyGenerator.GenerateZobrist(searchStatus.Position);

            TranspositionEntry entry = this.transpositionTable.GetEntry(positionHash);

            if(entry != null)
            {
                if (entry.Depth >= searchStatus.RemainingPlies)
                {
                    if (entry.EntryType == TranspositionEntryType.Exact)
                    {
                        searchStatus.Score = entry.Score;
                        searchStatus.BestMove = entry.BestMove;

                        return searchStatus.Score;
                    }
                    else if (entry.EntryType == TranspositionEntryType.FailHigh && entry.Score >= searchStatus.Beta)
                    {
                        searchStatus.Score = searchStatus.Beta;

                        return searchStatus.Score;
                    }
                    else if(entry.EntryType == TranspositionEntryType.FailLow && entry.Score <= searchStatus.Alpha)
                    {
                        searchStatus.Score = searchStatus.Alpha;

                        return searchStatus.Score;
                    }
                }
                else
                {
                    if(entry.BestMove != null)
                    {
                        searchStatus.BestMove = entry.BestMove;
                    }
                }
            }

            int score = this.nextStrategy.AlphaBeta(searchStatus);

            //if(entry == null || searchStatus.RemainingPlies > entry.Depth)
            //{
            //if (entry == null || searchStatus.RemainingPlies < 2 || searchStatus.RemainingPlies > entry.Depth)
            //{
                TranspositionEntryType transpositionEntryType = TranspositionEntryType.Exact;
                if(searchStatus.Score >= searchStatus.Beta)
                {
                    transpositionEntryType = TranspositionEntryType.FailHigh;
                }
                else if(searchStatus.Score <= searchStatus.Alpha)
                {
                    transpositionEntryType = TranspositionEntryType.FailLow;
                }
                transpositionTable.SaveEntry(positionHash, searchStatus.RemainingPlies, searchStatus.Score, transpositionEntryType, searchStatus.BestMove);
            //}
                //}

            return score;
        }
    }
}
