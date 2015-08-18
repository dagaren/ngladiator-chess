using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Threading;

namespace Gladiator.Search
{
    public abstract class BaseSearcher : ISearcher
    {
        public ISearchExecution InitSearch(IPosition<IBoard> position, SearchOptions searchOptions)
        {
            Check.ArgumentNotNull(position, "position");
            Check.ArgumentNotNull(searchOptions, "searchOptions");

            return new SearchExecution((token) => this.SearchAction(position, searchOptions, token));
        }

        protected abstract Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, CancellationToken cancellationToken);
    }
}
