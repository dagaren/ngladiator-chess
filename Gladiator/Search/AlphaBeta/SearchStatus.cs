using Gladiator.Representation;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class SearchStatus
    {
        public event Action<Move, int> BestMoveChanged;

        private Move move;

        public IPosition<IBoard> Position { get; set; }
        public int Alpha { get; set; }
        public int Beta { get; set; }
        public int Score { get; set; }
        public int CurrentPly { get; set; }
        public int RemainingPlies { get; set; }
        public Move SuggestedMove { get; set; }
        public Move BestMove {
            get { return this.move; }
            set 
            {
                this.move = value;
                if(this.move != null && BestMoveChanged != null)
                {
                    this.BestMoveChanged(this.move, this.CurrentPly);
                }
            }
        }
    }
}
