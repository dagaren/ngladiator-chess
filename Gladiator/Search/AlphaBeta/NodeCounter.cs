using System;

namespace Gladiator.Search.AlphaBeta
{
    class NodeCounter : INodeCounter
    {
        private long value;

        public NodeCounter()
        {
            this.value = 0;
        }

        public void Increment()
        {
            this.value++;
        }

        public long GetValue()
        {
            return this.value;
        }
    }
}
