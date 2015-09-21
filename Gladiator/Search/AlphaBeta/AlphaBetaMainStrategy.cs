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

        private readonly IMoveSorter moveSorter;

        public AlphaBetaMainStrategy(IMoveSorter moveSorter)
        {
            Check.ArgumentNotNull(moveSorter, "moveSorter");

            this.moveSorter = moveSorter;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            IEnumerable<Move> moves = searchStatus.Position.GetMoves(MoveSearchType.PseudoLegalMoves);
            moves = this.moveSorter.Sort(moves, searchStatus);
            
            int numValidMoves = 0;

            SearchStatus nextSearchStatus = new SearchStatus();

            searchStatus.Score = searchStatus.Alpha;
            
            foreach (Move move in moves)
            {
                FullMove fullMove = searchStatus.Position.DoMove(move);
                
                if (searchStatus.Position.IsValid())
                {
                    numValidMoves++;
                    
                    nextSearchStatus.Position = searchStatus.Position;
                    nextSearchStatus.Alpha = -searchStatus.Beta;
                    nextSearchStatus.Beta = -searchStatus.Score;
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
                        searchStatus.Score = searchStatus.Beta;

                        return searchStatus.Score;
                    }
                    else if (score > searchStatus.Score)
                    {
                        searchStatus.Score = score;
                        searchStatus.BestMove = move;
                    }
                }

                searchStatus.Position.UndoMove(fullMove);
            }

            if (numValidMoves == 0)
            {
                if (searchStatus.Position.IsInCheck(searchStatus.Position.Turn))
                {
                    searchStatus.Score = AlphaBetaScore.CheckMateScore.Value();
                }
                else
                {
                    searchStatus.Score = AlphaBetaScore.DrawScore.Value();
                }
            }

            return searchStatus.Score;
        }
    }
}
