using Gladiator.Representation;
using Gladiator.Representation.Notation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gladiator.Tests.Representation.Notation
{
    [TestClass]
    public class ColouredPieceFormatExtensionsTest
    {
        [TestMethod]
        public void Format_Ok()
        {
            IDictionary<ColouredPiece, string> pieceFormatMappings = new Dictionary<ColouredPiece, string>()
            {
                { ColouredPiece.None, string.Empty },
                { ColouredPiece.BlackPawn, "p" },
                { ColouredPiece.BlackRook, "r" },
                { ColouredPiece.BlackKnight, "n" },
                { ColouredPiece.BlackBishop, "b" },
                { ColouredPiece.BlackQueen, "q" },
                { ColouredPiece.BlackKing, "k" },
                { ColouredPiece.WhitePawn, "P" },
                { ColouredPiece.WhiteRook, "R" },
                { ColouredPiece.WhiteKnight, "N" },
                { ColouredPiece.WhiteBishop, "B" },
                { ColouredPiece.WhiteQueen, "Q" },
                { ColouredPiece.WhiteKing, "K" }
            };

            foreach(KeyValuePair<ColouredPiece, string> keyValuePair in pieceFormatMappings)
            {
                Assert.AreEqual(keyValuePair.Value, keyValuePair.Key.Format());
            }
        }
    }
}
