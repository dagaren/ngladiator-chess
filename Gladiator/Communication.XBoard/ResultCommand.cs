using Gladiator.Core;
using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class ResultCommand : ICommand
    {
        private IEngine engine;
        private string result;
        private string comment;

        public ResultCommand(
            IEngine engine,
            string result, 
            string comment)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
            this.result = result;
            this.comment = comment;
        }

        public void Execute()
        {
            this.engine.ThinkingTurn = Colour.None;
        }
    }
}
