using Gladiator.Core;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class LevelCommand : ICommand
    {
        private IEngine engine;

        private int numMoves;

        private int minutes;

        private int seconds;

        private int incrementInSeconds;

        public LevelCommand(
            IEngine engine,
            int numMoves, 
            int minutes, 
            [CommmandParameter(parserType: typeof(DefaultParser<int>))]int seconds, 
            int incrementInSeconds)
        {
            this.numMoves = numMoves;
            this.minutes = minutes;
            this.seconds = seconds;
            this.incrementInSeconds = incrementInSeconds;
            this.engine = engine;
        }

        public void Execute()
        {
            TimeControl timeControl = new TimeControl(
                this.numMoves, 
                TimeSpan.FromMinutes(this.minutes).Add(TimeSpan.FromSeconds(this.seconds)), 
                TimeSpan.FromSeconds(this.incrementInSeconds));

            this.engine.TimeControl = timeControl;
        }
    }
}
