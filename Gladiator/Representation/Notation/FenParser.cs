using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gladiator.Representation.Notation
{
    public class FenParser<TBoard> : IParser<Position<TBoard>> where TBoard: IBoard, new() 
    {
        private readonly Regex fenRegex = new Regex(@"^(?<board>([prnbqkPRNBQK12345678]+/){7}[prnbqkPRNBQK12345678]+)\s+(?<turn>[wb])\s+(?<castlingRights>(-|[KQkq]+))\s+(?<enPassantSquare>([a-h][1-8]|-))\s+(?<fiftyMovesCounter>\d+)\s+(?<moveCounter>\d+)\s*$");

        private readonly PositionBuilder<TBoard> positionBuilder;

        public FenParser(PositionBuilder<TBoard> positionBuilder)
        {
            Check.ArgumentNotNull(positionBuilder, "positionBuilder");

            this.positionBuilder = positionBuilder;
        }

        public Position<TBoard> Parse(string input)
        {
            Match match = this.fenRegex.Match(input);
            if(!match.Success)
            {
                throw new ArgumentException(string.Format("Invalid fen string: {0}", input));
            }

            string board = match.Groups["board"].Value;
            string turn = match.Groups["turn"].Value;
            string castlingRights = match.Groups["castlingRights"].Value;
            string enPassantSquare = match.Groups["enPassantSquare"].Value;
            string fiftyMovesCounter = match.Groups["fiftyMovesCounter"].Value;
            string moveCounter = match.Groups["moveCounter"].Value;

            Position<TBoard> position = this.positionBuilder.Build();

            position.Turn = turn == "w" ? Colour.White : Colour.Black;

            if(castlingRights.Contains("K"))
            {
                position.SetCastlingRight(CastlingType.Short, Colour.White, true);
            }
            if(castlingRights.Contains("k"))
            {
                position.SetCastlingRight(CastlingType.Short, Colour.Black, true);
            }
            if(castlingRights.Contains("Q"))
            {
                position.SetCastlingRight(CastlingType.Long, Colour.White, true);
            }
            if(castlingRights.Contains("q"))
            {
                position.SetCastlingRight(CastlingType.Long, Colour.Black, true);
            }

            position.EnPassantSquare = enPassantSquare != "-" ? StringEnumExtensions.ParseEnum<Square>(enPassantSquare) : Square.None;

            string[] ranks = board.Split(new string[] { "/" }, StringSplitOptions.None);

            for (int i = 0; i < 8; i++)
            {
                string rank = ranks[i];

                int file = 0;
                for(int j = 0; j < rank.Length; j++)
                {
                    if(file > 8)
                    {
                        throw new ArgumentException(string.Format("Invalid fen string: {0}", input));
                    }

                    string character = rank.Substring(j, 1);

                    int emptySquares;
                    if(Int32.TryParse(character, out emptySquares))
                    {
                        if(emptySquares < 1 || emptySquares > 8)
                        {
                            throw new ArgumentException(string.Format("Invalid fen string: {0}", input));
                        }
                        file += emptySquares;
                    }
                    else
                    {
                        ColouredPiece piece = ColouredPieceFormatExtensions.Parse(character);
                        position.Board.PutPiece(piece, SquareExtensions.FromRankAndFile((Rank)(7 - i), (File)file));
                        file++;
                    }
                }
            }

            return position;
        }
    }
}
