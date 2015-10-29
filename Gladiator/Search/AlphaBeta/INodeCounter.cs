using System;

namespace Gladiator.Search.AlphaBeta
{
    public interface INodeCounter
    {
        void Increment();

        long GetValue();
    }
}
