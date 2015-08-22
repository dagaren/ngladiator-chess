using Gladiator.Core;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class NoPostCommand : ICommand
    {
        private IEngine engine;

        public NoPostCommand(IEngine engine)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.PrincipalVariationEnabled = false;
        }
    }
}
