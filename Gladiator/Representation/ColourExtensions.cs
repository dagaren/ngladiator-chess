namespace Gladiator.Representation
{
    using System.Collections.Generic;

    public static class ColourExtensions
    {
        private static Colour[] opponents = new Colour[3];

        private static readonly IEnumerable<Colour> allColours = new Colour[] { Colour.White, Colour.Black };

        static ColourExtensions()
        {
            opponents[Colour.White.Value()] = Colour.Black;
            opponents[Colour.Black.Value()] = Colour.White;
        }

        public static int Value(this Colour colour)
        {
            return (int)colour;
        }

        public static Colour Opponent(this Colour colour)
        {
            if(colour == Colour.None)
            {
                return Colour.None;
            }

            return opponents[colour.Value()];
        }

        public static IEnumerable<Colour> AllColours()
        {
            return allColours;
        }
    }
}
