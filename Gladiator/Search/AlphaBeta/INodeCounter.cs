using System;

namespace Gladiator.Search.AlphaBeta
{
    interface INodeCounter
    {
        void Increment();

        long GetValue();
    }
}
