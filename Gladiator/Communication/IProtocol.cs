using System;

namespace Gladiator.Communication
{
    public interface IProtocol
    {
        void ProcessCommand(string commandString);
    }
}
