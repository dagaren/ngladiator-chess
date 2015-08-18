using Gladiator.Representation;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class SearchStatus
    {
        public IPosition<IBoard> Position { get; set; }
        public int Alpha { get; set; }
        public int Beta { get; set; }
        public int Score { get; set; }
        public int CurrentPly { get; set; }
        public int RemainingPlies { get; set; }
        public Move BestMove { get; set; }
    }
}
