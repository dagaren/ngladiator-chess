using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaAspirationWindowStrategy : IAlphaBetaStrategy
    {
        private IAlphaBetaStrategy nextStrategy;

        private const int WindowSize = 76;

        private IEnumerable<Func<int, SearchWindow, SearchWindow>> SearchWindowRetrievers;

        public AlphaBetaAspirationWindowStrategy(IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.nextStrategy = nextStrategy;

            this.SearchWindowRetrievers = new Func<int, SearchWindow, SearchWindow>[] 
            {
                this.GetFirstSearchWindow,
                this.GetSecondSearchWindow,
                this.GetThirdSearchWindow,
                this.GetFinalWindow
            };
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            int score = searchStatus.Score;
            SearchWindow searchWindow = null;

            foreach(var windowRetrieverDelegate in this.SearchWindowRetrievers)
            {
                searchWindow = windowRetrieverDelegate(score, searchWindow);

                searchStatus.Alpha = searchWindow.Alpha;
                searchStatus.Beta = searchWindow.Beta;

                score = this.nextStrategy.AlphaBeta(searchStatus);

                if(!searchWindow.IsFail(score))
                {
                    break;
                }
            }
            
            return score;
        }

        private SearchWindow GetFirstSearchWindow(int previousScore, SearchWindow previousSearchWindow)
        {
            return new SearchWindow(previousScore - WindowSize / 2, previousScore + WindowSize / 2);
        }

        private SearchWindow GetSecondSearchWindow(int previousScore, SearchWindow previousSearchWindow)
        {
            if(previousSearchWindow.IsFailLow(previousScore))
            {
                return new SearchWindow(previousScore - WindowSize, previousScore);
            }
            else if(previousSearchWindow.IsFailHigh(previousScore))
            {
                return new SearchWindow(previousScore, previousScore + WindowSize);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private SearchWindow GetThirdSearchWindow(int previousScore, SearchWindow previousSearchWindow)
        {
            if (previousSearchWindow.IsFailLow(previousScore))
            {
                return new SearchWindow(AlphaBetaScore.InitialAlpha.Value(), previousScore);
            }
            else if (previousSearchWindow.IsFailHigh(previousScore))
            {
                return new SearchWindow(previousScore, AlphaBetaScore.InitialBeta.Value());
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private SearchWindow GetFinalWindow(int previousScore, SearchWindow previousSearchWindow)
        {
            return new SearchWindow(AlphaBetaScore.InitialAlpha.Value(), AlphaBetaScore.InitialBeta.Value());
        }
    }
}
