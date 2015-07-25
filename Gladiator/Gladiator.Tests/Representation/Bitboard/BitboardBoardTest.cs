using Gladiator.Representation;
using Gladiator.Representation.Bitboard;
using Gladiator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Representation.Bitboard
{
    [TestClass]
    public class BitboardBoardTest
    {
        [TestMethod]
        public void PutPiece_Ok()
        {
            foreach(ColouredPiece piece in EnumExtensions.GetValues<ColouredPiece>())
            {
                if (piece == ColouredPiece.None)
                {
                    continue;
                }

                TestPutPiece(piece);
            }
        }

        [TestMethod]
        public void RemovePiece_Ok()
        {
            foreach (ColouredPiece piece in EnumExtensions.GetValues<ColouredPiece>())
            {
                if (piece == ColouredPiece.None)
                {
                    continue;
                }

                TestRemovePiece(piece);
            }
        }

        [TestMethod]
        public void GetPiece_Ok()
        {
            foreach (ColouredPiece piece in EnumExtensions.GetValues<ColouredPiece>())
            {
                if (piece == ColouredPiece.None)
                {
                    continue;
                }

                TestGetPiece(piece);
            }
        }

        private static void TestRemovePiece(ColouredPiece piece)
        {
            BitboardBoard board = new BitboardBoard();

            board.PutPiece(piece, Square.d1);
            board.RemovePiece(Square.d1);

            Assert.AreEqual(ColouredPiece.None, board.piecesInSquare[Square.d1.GetValue()]);
            Assert.AreEqual(BitboardExtensions.Empty, board.colourOccupation[piece.GetColour().GetValue()]);
            Assert.AreEqual(BitboardExtensions.Empty, board.occupation);
            Assert.AreEqual(BitboardExtensions.Empty, board.pieceOccupation[piece.GetValue()]);
        }

        private static void TestPutPiece(ColouredPiece piece)
        {
            BitboardBoard board = new BitboardBoard();

            board.PutPiece(piece, Square.d1);

            Assert.AreEqual(piece, board.piecesInSquare[Square.d1.GetValue()]);
            Assert.AreEqual(Square.d1.GetBitboard(), board.colourOccupation[piece.GetColour().GetValue()]);
            Assert.AreEqual(Square.d1.GetBitboard(), board.occupation);
            Assert.AreEqual(Square.d1.GetBitboard(), board.pieceOccupation[piece.GetValue()]);
        }

        private static void TestGetPiece(ColouredPiece piece)
        {
            BitboardBoard board = new BitboardBoard();

            board.PutPiece(piece, Square.d1);
            ColouredPiece currentPiece = board.GetPiece(Square.d1);

            Assert.AreEqual(piece, currentPiece);
        }
    }
}
