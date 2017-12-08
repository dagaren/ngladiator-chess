namespace Dagaren.Gladiator.Protocol.Uci
{
    using System.Collections.Generic;
    
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
