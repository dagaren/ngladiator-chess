namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*ucinewgame\s*$")]
    class UciNewGameCommand : ICommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
