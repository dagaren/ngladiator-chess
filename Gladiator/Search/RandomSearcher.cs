using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Gladiator.Search
{
    public class RandomSearcher : BaseSearcher
    {
        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, Action<PrincipalVariationChange> principalVariationChangeAction, CancellationToken cancellationToken)
        {
            IEnumerable<Move> moves = position.GetMoves(MoveSearchType.LegalMoves);
            Move selectedMove = moves.Random();
            
            return selectedMove;
        }
    }
}
