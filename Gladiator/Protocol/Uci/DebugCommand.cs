namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*debug\s+(?<enabled>on|off)\s*$")]
    class DebugCommand : ICommand
    {
        private readonly bool enabled;

        public DebugCommand(bool enabled)
        {
            this.enabled = enabled;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
