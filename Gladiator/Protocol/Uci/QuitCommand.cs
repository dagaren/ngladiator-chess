namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*quit\s*$")]
    class QuitCommand : ICommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
