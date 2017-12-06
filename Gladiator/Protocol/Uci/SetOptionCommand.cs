namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*setoption\s+name\s+(?<name>\w+)(\s+value\s+(?<value>.*))?\s*$")]
    class SetOptionCommand : ICommand
    {
        private readonly string name;

        private readonly string value;

        public SetOptionCommand(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
