using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Gladiator.Search
{
    public class RandomSearcher : ISearcher
    {
        private IPosition<IBoard> position;

        private SearchOptions searchOptions;

        public ISearchExecution InitSearch(IPosition<IBoard> position, SearchOptions searchOptions)
        {
            Check.ArgumentNotNull(position, "position");
            Check.ArgumentNotNull(searchOptions, "searchOptions");

            this.position = position;
            this.searchOptions = searchOptions;

            return new SearchExecution(this.SearchAction);
        }

        private Move SearchAction(CancellationToken cancellationToken)
        {
            IEnumerable<Move> moves = this.position.GetMoves(MoveSearchType.LegalMoves);
            Move selectedMove = moves.Random();
            
            return selectedMove;
        }
    }
}
