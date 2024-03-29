﻿using Gladiator.Representation;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Evaluation;

namespace Gladiator.Search.AlphaBeta
{
    public class MvvLvaMoveSorter : IMoveSorter
    {
        public IEnumerable<Move> Sort(IEnumerable<Move> moves, SearchStatus searchStatus)
        {
            return moves.OrderByDescending(m => GetMvvLvaValue(m, searchStatus.Position));
        }

        private int GetMvvLvaValue(Move move, IPosition<IBoard> position)
        {
            return MaterialEvaluator.PieceValues[position.Board.GetPiece(move.Destination).GetPiece().GetValue()] -
                   MaterialEvaluator.PieceValues[position.Board.GetPiece(move.Source).GetPiece().GetValue()];
        }
    }
}
