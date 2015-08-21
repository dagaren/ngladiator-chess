using Gladiator.Core;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class SdCommand : ICommand
    {
        private IEngine engine;

        private int depth;

        public SdCommand(IEngine engine, int depth)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
            this.depth = depth;
        }

        public void Execute()
        {
            this.engine.MaxSearchDepth = this.depth;
        }
    }
}
