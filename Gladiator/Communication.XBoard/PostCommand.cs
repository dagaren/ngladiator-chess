using Gladiator.Core;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class PostCommand : ICommand
    {
        private IEngine engine;

        public PostCommand(IEngine engine)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.PrincipalVariationEnabled = true;
        }
    }
}
