namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*stop\s*$")]
    class StopCommand : ICommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
