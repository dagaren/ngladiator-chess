using Gladiator.Representation;
using System;

namespace Gladiator.Search
{
    public interface ISearchExecution
    {
        event Action<Move> OnSearchFinished;

        void Init();

        void Cancel();
    }
}
