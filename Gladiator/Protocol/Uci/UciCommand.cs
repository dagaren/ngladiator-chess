namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*uci\s*$")]
    internal class UciCommand : ICommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}