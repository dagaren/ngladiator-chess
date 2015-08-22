using Gladiator.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Representation.Tests.Builders;

namespace Gladiator.Search.Tests
{
    [TestClass]
    public class PrincipalVariationSearchTest
    {
        [TestMethod]
        public void SaveMoveInPly_NoMovesAdded_EmptyCollectionReturned()
        {
            var principalVariation = new PrincipalVariation();

            IEnumerable<Move> moves = principalVariation.Moves;

            Assert.AreEqual(0, moves.Count());
        }

        [TestMethod]
        public void SaveMoveInPly_MoveAddedToFirstPly_CollectionWithOneElementReturned()
        {
            var principalVariation = new PrincipalVariation();

            Move move = new Move(Square.e1, Square.f1);
            List<Move> expectedMoves = new MoveListBuilder().AddMove(move);

            principalVariation.SaveMoveInPly(move, 0);

            IEnumerable<Move> moves = principalVariation.Moves;

            Assert.AreEqual(1, moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves.ToArray(), expectedMove));
        }

        [TestMethod]
        public void SaveMoveInPly_MoveAddedToFirstPlyThenReset_EmptyCollectionReturned()
        {
            var principalVariation = new PrincipalVariation();

            Move move = new Move(Square.e1, Square.f1);
            List<Move> expectedMoves = new MoveListBuilder().AddMove(move);

            principalVariation.SaveMoveInPly(move, 0);
            principalVariation.InitPly(0);

            IEnumerable<Move> moves = principalVariation.Moves;

            Assert.AreEqual(0, moves.Count());
        }

        [TestMethod]
        public void SaveMoveInPly_MovesAddedToThreePlies_MovesReturned()
        {
            var principalVariation = new PrincipalVariation();

            Move move1 = new Move(Square.e1, Square.f1);
            Move move2 = new Move(Square.e1, Square.g1);
            Move move3 = new Move(Square.e1, Square.h1);

            List<Move> expectedMoves = new MoveListBuilder()
                                            .AddMove(move1)
                                            .AddMove(move2)
                                            .AddMove(move3);

            principalVariation.InitPly(0);
            principalVariation.InitPly(1);
            principalVariation.InitPly(2);

            principalVariation.SaveMoveInPly(move3, 2);
            principalVariation.SaveMoveInPly(move2, 1);
            principalVariation.SaveMoveInPly(move1, 0);

            IEnumerable<Move> moves = principalVariation.Moves;

            Assert.AreEqual(3, moves.Count());
            Enumerable.SequenceEqual(expectedMoves, moves);
        }
    }
}
