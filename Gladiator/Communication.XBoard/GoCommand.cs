using Gladiator.Core;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class GoCommand : ICommand
    {
        private IEngine engine;

        public GoCommand(IEngine engine)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.ThinkingTurn = this.engine.CurrentGame.Turn;
        }
    }
}
