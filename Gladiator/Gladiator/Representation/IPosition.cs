using System;

namespace Gladiator.Representation
{
    public interface IPosition<out IBoard>
    {
        IBoard Board { get; }

        Colour Turn { get; set; }

        void DoMove(Move move);
    }
}
