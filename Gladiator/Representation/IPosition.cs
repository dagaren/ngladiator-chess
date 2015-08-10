using System;

namespace Gladiator.Representation
{
    public interface IPosition<out IBoard>
    {
        IBoard Board { get; }

        Colour Turn { get; set; }

        void SetCastlingRight(CastlingType type, Colour color, bool enabled);

        bool GetCastlingRight(CastlingType type, Colour color);

        void DoMove(Move move);
    }
}
