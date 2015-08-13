using System;

namespace Gladiator.Communication.XBoard
{
    public class LevelCommand : ICommand
    {
        private int numMoves;

        private string controlBase;

        private int incrementInSeconds;

        public LevelCommand(int numMoves, string controlBase, int incrementInSeconds)
        {
            this.numMoves = numMoves;
            this.controlBase = controlBase;
            this.incrementInSeconds = incrementInSeconds;
        }

        public void Execute()
        {
            //TODO: Set up time control
        }
    }
}
