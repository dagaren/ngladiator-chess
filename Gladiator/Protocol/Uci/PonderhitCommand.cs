namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*ponderhit\s*$")]
    class PonderhitCommand : ICommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
