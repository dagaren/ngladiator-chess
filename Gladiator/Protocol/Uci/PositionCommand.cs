namespace Dagaren.Gladiator.Protocol.Uci
{
    using System.Collections.Generic;

    [ProtocolCommand("Uci", @"^\s*" +
                            @"position" + @"\s+" +
                            @"(startpos|fen (?<fen>([prnbqkPRNBQK12345678]+/){7}[prnbqkPRNBQK12345678]+\s+[wb]\s+(-|[KQkq]+)\s+([a-h][1-8]|-)\s+(\d+)\s+(\d+)))" + @"\s+" +
                            @"moves" +
                            @"(\s+(?<moves>[a-h][1-8][a-h][1-8](q|r|b|k)?))*" + @"\s*$")]
    class PositionCommand : ICommand
    {
        private readonly string fen;

        private readonly bool startpos;

        private IEnumerable<string> moves;

        public PositionCommand(string fen, bool startpos, IEnumerable<string> moves)
        {
            this.fen = fen;
            this.startpos = startpos;
            this.moves = moves;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
