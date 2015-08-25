using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaAspirationWindowStrategy : IAlphaBetaStrategy
    {
        private IAlphaBetaStrategy nextStrategy;

        private const int WindowSize = 35;

        private static int visits = 0;

        private static int fails = 0;

        private static int instabilityFails = 0;

        public AlphaBetaAspirationWindowStrategy(IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            int initialAlpha = searchStatus.Alpha;
            int initialBeta = searchStatus.Beta;

            int windowAlpha = searchStatus.Score - WindowSize;
            int windowBeta = searchStatus.Score + WindowSize;

            searchStatus.Alpha = windowAlpha;
            searchStatus.Beta = windowBeta;

            visits++;

            //Console.WriteLine("# Aspiration window. Alpha {0}, Beta {1}, score: {2}", searchStatus.Alpha, searchStatus.Beta, searchStatus.Score);
            int score = this.nextStrategy.AlphaBeta(searchStatus);
            //Console.WriteLine("# Score with aspiration: {0}", score);
            if(score <= windowAlpha || score >= windowBeta)
            {
                fails++;
                searchStatus.Alpha = initialAlpha;
                searchStatus.Beta = initialBeta;

                if(score <= windowAlpha)
                {
                    windowAlpha = score - WindowSize;
                    windowBeta = score;
                }
                else if(score >= windowBeta)
                {
                    windowAlpha = score;
                    windowBeta = score + WindowSize;
                }
                searchStatus.Alpha = windowAlpha;
                searchStatus.Beta = windowBeta;
                score = this.nextStrategy.AlphaBeta(searchStatus);
                //Console.WriteLine("# Score second try with aspiration: {0}", score);
                if(score <= windowAlpha || score >= windowBeta)
                {
                    instabilityFails++;

                    searchStatus.Alpha = initialAlpha;
                    searchStatus.Beta = initialBeta;
                    score = this.nextStrategy.AlphaBeta(searchStatus);
                    //Console.WriteLine("# Score with full window: {0}", score);
                }
            }
            //Console.WriteLine("# Final score: {0}", score);
            //Console.WriteLine("# Aspiration window: {0} times called, {1} fails, instability fails {2}", visits, fails, instabilityFails);

            return score;
        }
    }
}
