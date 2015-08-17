using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Search
{
    public interface IPrincipalVariation
    {
        IEnumerable<Move> GetMoves();
    }
}
