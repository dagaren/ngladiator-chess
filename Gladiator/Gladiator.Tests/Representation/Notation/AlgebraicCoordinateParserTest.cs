using Gladiator.Representation;
using Gladiator.Representation.Notation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Tests.Representation.Notation
{
    [TestClass]
    public class AlgebraicCoordinateParserTest
    {
        [TestMethod]
        public void Parse_NullString_ArgumentNullExceptionExpected()
        {
            TestParseInvalid<ArgumentNullException>(null);
        }

        [TestMethod]
        public void Parse_InvalidMove_ArgumentExceptionExpected()
        {
            TestParseInvalid <ArgumentException>("n1m4");
        }

        [TestMethod]
        public void Parse_ValidMove_MoveReturned()
        {
            TestParseValid("a1c1", Square.a1, Square.c1, Piece.None);
        }

        [TestMethod]
        public void Parse_ValidMoveWithPromotion_MoveReturned()
        {
            TestParseValid("b7b8n", Square.b7, Square.b8, Piece.Knight);
        }

        private static void TestParseInvalid<TException>(string moveString) where TException : Exception
        {
            var parser = new AlgebraicCoordinateParser();

            bool exceptionThrown = false;

            try
            {
                parser.Parse(moveString);
            }
            catch (TException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }

        private static void TestParseValid(string moveString, Square expectedSource, Square expectedDestination, Piece expectedPromotion)
        {
            var parser = new AlgebraicCoordinateParser();

            Move move = parser.Parse(moveString);

            Assert.AreEqual(expectedSource, move.Source);
            Assert.AreEqual(expectedDestination, move.Destination);
            Assert.AreEqual(expectedPromotion, move.Promotion);
        }
    }
}
