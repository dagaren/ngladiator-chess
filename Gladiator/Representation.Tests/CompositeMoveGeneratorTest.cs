using Gladiator.Representation;
using Gladiator.Representation.Tests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Tests
{
    [TestClass]
    public class CompositeMoveGeneratorTest
    {
        [TestMethod]
        public void GetMoves_WithTwoInnerMoveGenerators_Ok()
        {
            var firstMoveGenerator = Substitute.For<IMoveGenerator<IPosition<IBoard>, IBoard>>();
            var secondMoveGenerator = Substitute.For<IMoveGenerator<IPosition<IBoard>, IBoard>>();

            var moveGeneratorList = new List<IMoveGenerator<IPosition<IBoard>, IBoard>>() {
                firstMoveGenerator,
                secondMoveGenerator
            };

            List<Move> firstMoves = new MoveListBuilder().AddMove(Square.a1, Square.b1);
            firstMoveGenerator.GetMoves(null).ReturnsForAnyArgs(firstMoves);

            List<Move> secondMoves = new MoveListBuilder()
                .AddMove(Square.h1, Square.g8)
                .AddMove(Square.g8, Square.h8);
            secondMoveGenerator.GetMoves(null).ReturnsForAnyArgs(secondMoves);

            var compositeMoveGenerator = new CompositeMoveGenerator<IPosition<IBoard>, IBoard>(moveGeneratorList);

            IList<Move> generatedMoves = compositeMoveGenerator.GetMoves(null);

            List<Move> expectedMoves = new MoveListBuilder()
                .AddMoves(firstMoves)
                .AddMoves(secondMoves);

            Assert.AreEqual(expectedMoves.Count, generatedMoves.Count);
            expectedMoves.ForEach(expectedMove => Assert.IsTrue(generatedMoves.Contains(expectedMove)));
        }
    }
}
