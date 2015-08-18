using System;

namespace Gladiator.Search.AlphaBeta
{
    public interface IAlphaBetaStrategy
    {
        int AlphaBeta(SearchStatus searchStatus);
    }
}
