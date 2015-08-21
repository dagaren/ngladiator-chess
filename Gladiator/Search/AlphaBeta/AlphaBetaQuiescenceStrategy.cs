using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaQuiescenceStrategy : IAlphaBetaStrategy
    {
        public IAlphaBetaStrategy RecursiveStrategy
        {
            get { return this.recursiveStrategy; }
            set { this.recursiveStrategy = value; }
        }

        private IAlphaBetaStrategy recursiveStrategy;

        private readonly IAlphaBetaStrategy staticEvaluationStrategy;

        private readonly IMoveSorter moveSorter;

        private Action<string> commentWrite;

        public AlphaBetaQuiescenceStrategy(
            IAlphaBetaStrategy staticEvaluationStrategy,
            IMoveSorter moveSorter,
            Action<string> commentWrite)
        {
            Check.ArgumentNotNull(staticEvaluationStrategy, "staticEvaluationStrategy");
            Check.ArgumentNotNull(moveSorter, "moveSorter");
            Check.ArgumentNotNull(commentWrite, "commentWrite");

            this.staticEvaluationStrategy = staticEvaluationStrategy;
            this.moveSorter = moveSorter;
            this.commentWrite = commentWrite;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            int staticScore = this.staticEvaluationStrategy.AlphaBeta(searchStatus);
            int score = staticScore;
            if (score >= searchStatus.Beta)
            {
                return searchStatus.Beta;
            }

            if (score < searchStatus.Alpha - 950)
            {
                return searchStatus.Alpha;
            }

            if (score > searchStatus.Alpha)
            {
                searchStatus.Alpha = score;
            }

            IEnumerable<Move> moves = searchStatus.Position.GetMoves(MoveSearchType.PseudoLegalMoves)
                .Where(m => searchStatus.Position.Board.GetPiece(m.Destination) != ColouredPiece.None);

            moves = this.moveSorter.Sort(moves, searchStatus.Position);

            SearchStatus nextSearchStatus = new SearchStatus();

            foreach (Move move in moves)
            {
                FullMove fullMove = searchStatus.Position.DoMove(move);

                if (searchStatus.Position.IsValid())
                {
                    nextSearchStatus.Position = searchStatus.Position;
                    nextSearchStatus.Alpha = -searchStatus.Beta;
                    nextSearchStatus.Beta = -searchStatus.Alpha;
                    nextSearchStatus.CurrentPly = searchStatus.CurrentPly + 1;
                    nextSearchStatus.RemainingPlies = searchStatus.RemainingPlies - 1;
                    nextSearchStatus.BestMove = null;

                    try
                    {
                        score = -this.recursiveStrategy.AlphaBeta(nextSearchStatus);
                    }
                    catch (Exception)
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

            return searchStatus.Alpha;
        }
    }
}
