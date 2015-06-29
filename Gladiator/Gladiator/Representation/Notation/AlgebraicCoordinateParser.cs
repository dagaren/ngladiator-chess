using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Gladiator.Utils;

namespace Gladiator.Representation.Notation
{
    class AlgebraicCoordinateParser : IMoveParser
    {
        private const string SourceKey = "source";

        private const string DestinationKey = "destination";

        private const string PromotionKey = "promotion";

        private readonly Regex regex = new Regex(string.Format(@"^\s*(?<{0}>[a-h][1-8])(?<{1}>[a-h][1-8])(?<{2}>[qrbn])?\s*$",
            SourceKey,
            DestinationKey,
            PromotionKey));

        private readonly IDictionary<string, Piece> promotionMapping = new Dictionary<string, Piece> {
            { "r", Piece.Rock },
            { "n", Piece.Knight },
            { "q", Piece.Queen },
            { "b", Piece.Bishop }
        };

        public Move Parse(string moveString)
        {
            Check.ArgumentNotNull(moveString, "moveString");

            Match match = this.regex.Match(moveString);

            if(!match.Success)
            {
                throw new ArgumentException(string.Format("The input string '{0}' is an invalid move in algebraic coordinate notation.", moveString));
            }

            Square sourceSquare = match.Groups[SourceKey].Value.ParseEnum<Square>();
            Square destinationSquare = match.Groups[DestinationKey].Value.ParseEnum<Square>();
            Piece promotionPiece = match.Groups[PromotionKey].Success ? 
                this.promotionMapping[match.Groups[PromotionKey].Value] : 
                Piece.None;

            return new Move()
            {
                Source = sourceSquare,
                Destination = destinationSquare,
                Promotion = promotionPiece
            };
        }
    }
}
