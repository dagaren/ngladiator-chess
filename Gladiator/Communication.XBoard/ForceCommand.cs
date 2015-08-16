using Gladiator.Core;
using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class ForceCommand : ICommand
    {
        private IEngine engine;

        public ForceCommand(IEngine engine)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.ThinkingTurn = Colour.None;
        }
    }
}
