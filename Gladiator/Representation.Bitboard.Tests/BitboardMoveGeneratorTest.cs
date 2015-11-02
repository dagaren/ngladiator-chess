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
            Console.WriteLine("Generated moves:");
            foreach(Move move in moves)
            {
                Console.Write(move.Format() + " ");
            }
            Assert.AreEqual(expectedMoves.Count(), moves.Count());
            expectedMoves.ForEach(expectedMove => CollectionAssert.Contains(moves, expectedMove));
        }
    }
}
