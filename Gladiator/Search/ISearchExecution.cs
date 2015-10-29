using Gladiator.Representation;
using System;

namespace Gladiator.Search
{
    public interface ISearchExecution
    {
        event Action<Move> OnSearchFinished;

        event Action<PrincipalVariationChange> OnPrincipalVariationChanged;

        void Init();

        void Wait();

        void Cancel();
    }
}
