using System;

namespace Gladiator.Communication.Protocols.XBoard
{
    class XBoardCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("XBoard command received");
        }
    }
}
