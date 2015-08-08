using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    public static class ColourExtensions
    {
        private static Colour[] opponents = new Colour[3];

        static ColourExtensions()
        {
            opponents[Colour.White.GetValue()] = Colour.Black;
            opponents[Colour.Black.GetValue()] = Colour.White;
        }

        public static int GetValue(this Colour colour)
        {
            return (int)colour;
        }

        public static Colour GetOpponent(this Colour colour)
        {
            if(colour == Colour.None)
            {
                return Colour.None;
            }

            return opponents[colour.GetValue()];
        }
    }
}
