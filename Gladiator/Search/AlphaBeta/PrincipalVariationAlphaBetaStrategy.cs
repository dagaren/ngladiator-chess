using Gladiator.Utils;
using Gladiator.Representation;
using Gladiator.Representation.Notation;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class PrincipalVariationAlphaBetaStrategy : IAlphaBetaStrategy
    {
        private readonly IPrincipalVariationManager principalVariationManager;

        private readonly IAlphaBetaStrategy nextStrategy;

        public PrincipalVariationAlphaBetaStrategy(IPrincipalVariationManager principalVariationManager, IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(principalVariationManager, "principalVariationManager");
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.principalVariationManager = principalVariationManager;
            this.nextStrategy = nextStrategy;
        }


        public int AlphaBeta(SearchStatus searchStatus)
        {
            this.principalVariationManager.InitPly(searchStatus.CurrentPly + 1);
            
            int initialAlpha = searchStatus.Alpha;

            int score = this.nextStrategy.AlphaBeta(searchStatus);

            if(searchStatus.BestMove != null && searchStatus.Alpha > initialAlpha)
            {
                this.principalVariationManager.SaveMoveInPly(searchStatus.BestMove, searchStatus.CurrentPly);
            }

            return score;
        }
    }
}
