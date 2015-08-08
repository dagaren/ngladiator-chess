using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard.Tests
{
    public abstract class BitboardMoveGeneratorTest
    {
        protected static void TestMoveGenerator(
            IMoveGenerator<Position<BitboardBoard>, BitboardBoard> moveGenerator,
            List<Move> expectedMoves,
            Position<BitboardBoard> position)
        {
            Move[] moves = moveGenerator.GetMoves(position).ToArray();

            Assert.AreEqual(expectedMoves.Count(), moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves, expectedMove));
        }
    }
}
