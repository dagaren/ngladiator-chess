using Gladiator.Core;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.XBoard
{
    public class StCommand : ICommand
    {
        private IEngine engine;

        private int time;

        public StCommand(IEngine engine, int time)
        {
            Check.ArgumentNotNull(engine, "engine");

            this.engine = engine;
            this.time = time;
        }

        public void Execute()
        {
            this.engine.TimeControl = new FixedTimePerMoveTimeControl(TimeSpan.FromSeconds(this.time));
        }
    }
}
