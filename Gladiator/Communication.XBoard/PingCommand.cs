using System;

namespace Gladiator.Communication.XBoard
{
    public class PingCommand : ICommand
    {
        private int number;

        public PingCommand(int number)
        {
            this.number = number;
        }

        public void Execute()
        {
            Console.WriteLine(string.Format("pong {0}", this.number));
        }
    }
}
