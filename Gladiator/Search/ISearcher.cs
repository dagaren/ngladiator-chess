using Gladiator.Representation;
using System;

namespace Gladiator.Search
{
    public interface ISearcher
    {
        ISearchExecution InitSearch(IPosition<IBoard> position, SearchOptions searchOptions);
    }
}
