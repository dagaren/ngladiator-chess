using Gladiator.Representation;
using Gladiator.Search.AlphaBeta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Representation.Tests.Builders;

namespace Gladiator.Search.Tests
{
    [TestClass]
    public class MvvLvaMoveSorterTest
    {
        [TestMethod]
        public void Sort_Ok()
        {
            SearchStatus searchStatus = new SearchStatus();
            IPosition<IBoard> position = Substitute.For<IPosition<IBoard>>();
            IBoard board = Substitute.For<IBoard>();
            position.Board.Returns(board);
            board.GetPiece(Square.a1).Returns(ColouredPiece.WhitePawn);
            board.GetPiece(Square.h1).Returns(ColouredPiece.BlackQueen);
            board.GetPiece(Square.a8).Returns(ColouredPiece.WhiteQueen);
            board.GetPiece(Square.h8).Returns(ColouredPiece.BlackQueen);
            board.GetPiece(Square.a4).Returns(ColouredPiece.WhiteQueen);
            board.GetPiece(Square.h4).Returns(ColouredPiece.WhitePawn);
            searchStatus.Position = position;
            
            IEnumerable<Move> moves = new MoveListBuilder()
                                        .AddMove(Square.a8, Square.h8)
                                        .AddMove(Square.a4, Square.h4)
                                        .AddMove(Square.a1, Square.h1)
                                        .Build();

            var moveSorter = new MvvLvaMoveSorter();

            IEnumerable<Move> sortedMoves = moveSorter.Sort(moves, searchStatus);


            IEnumerable<Move> expectedMoves = new MoveListBuilder()
                                        .AddMove(Square.a1, Square.h1)
                                        .AddMove(Square.a8, Square.h8)
                                        .AddMove(Square.a4, Square.h4)
                                        .Build();

            CollectionAssert.AreEqual(expectedMoves.ToList(), sortedMoves.ToList());
        }
    }
}
