using System;

namespace Gladiator.Representation
{
    public class Move
    {
        public Square Source { get; set; }

        public Square Destination { get; set; }

        public Piece Promotion { get; set; }

        public Move() : this(Square.None, Square.None, Piece.None)
        {
        }

        public Move(Square source, Square destination) : this(source, destination, Piece.None)
        {
        }

        public Move(Square source, Square destination, Piece promotion)
        {
            this.Source = source;
            this.Destination = destination;
            this.Promotion = promotion;
        }
        
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Move move = obj as Move;
            if((object)move == null)
            {
                return false;
            }

            return (move.Source == this.Source) &&
                   (move.Destination == this.Destination) &&
                   (move.Promotion == this.Promotion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.Source.GetValue() 
                ^ this.Destination.GetValue() ^ 
                this.Promotion.GetValue();
        }

        public static bool operator ==(Move a, Move b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Move a, Move b)
        {
            return !(a == b);
        }
    }
}
