using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaMainStrategy : IAlphaBetaStrategy
    {
        public IAlphaBetaStrategy RecursiveStrategy
        { 
            get { return this.recursiveStrategy; }
            set { this.recursiveStrategy = value; } 
        }

        private IAlphaBetaStrategy recursiveStrategy;

        private Action<string> commentWrite;

        public AlphaBetaMainStrategy(Action<string> commentWrite)
        {
            Check.ArgumentNotNull(commentWrite, "commentWrite");

            this.commentWrite = commentWrite;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            IEnumerable<Move> moves = searchStatus.Position.GetMoves(MoveSearchType.PseudoLegalMoves)
                .OrderBy(m => m.Destination.ManhattanDistanceToCenter());
            
            int numValidMoves = 0;

            SearchStatus nextSearchStatus = new SearchStatus();
            
            foreach (Move move in moves)
            {
                FullMove fullMove = searchStatus.Position.DoMove(move);
                
                if (searchStatus.Position.IsValid())
                {
                    numValidMoves++;
                    
                    nextSearchStatus.Position = searchStatus.Position;
                    nextSearchStatus.Alpha = -searchStatus.Beta;
                    nextSearchStatus.Beta = -searchStatus.Alpha;
                    nextSearchStatus.CurrentPly = searchStatus.CurrentPly + 1;
                    nextSearchStatus.RemainingPlies = searchStatus.RemainingPlies - 1;
                    nextSearchStatus.BestMove = null;

                    int score;

                    try
                    {
                        score = -this.recursiveStrategy.AlphaBeta(nextSearchStatus);
                    }
                    catch(Exception)
                    {
                        searchStatus.Position.UndoMove(fullMove);
                        throw;
                    }

                    if (score >= searchStatus.Beta)
                    {
                        searchStatus.Position.UndoMove(fullMove);
                        return searchStatus.Beta;
                    }
                    else if (score > searchStatus.Alpha)
                    {
                        searchStatus.Alpha = score;
                        searchStatus.BestMove = move;
                    }
                }

                searchStatus.Position.UndoMove(fullMove);
            }

            if (numValidMoves == 0)
            {
                if (searchStatus.Position.IsInCheck(searchStatus.Position.Turn))
                {
                    return AlphaBetaScore.CheckMateScore.Value();
                }
                else
                {
                    return AlphaBetaScore.DrawScore.Value();
                }
            }

            return searchStatus.Alpha;
        }
    }
}
