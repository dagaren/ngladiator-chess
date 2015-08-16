using Gladiator.Core;
using Gladiator.Utils;
using Gladiator.Representation;
using System;

namespace Gladiator.Communication.XBoard
{
    public class PlayOtherCommand : ICommand
    {
        private IEngine engine;

        public PlayOtherCommand(IEngine engine)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.ThinkingTurn = this.engine.CurrentGame.Turn.Opponent();
        }
    }
}
