using Gladiator.Core;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class MoveNowCommand : ICommand
    {
        private IEngine engine;

        public MoveNowCommand(IEngine engine)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.CancelThink();
        }
    }
}
