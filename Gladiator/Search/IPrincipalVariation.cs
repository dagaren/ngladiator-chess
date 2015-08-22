using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Search
{
    public interface IPrincipalVariation
    {
        event Action OnChanged;

        IEnumerable<Move> Moves { get; }
    }
}
