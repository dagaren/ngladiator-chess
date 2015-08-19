using Gladiator.Representation;
using System;

namespace Gladiator.Core
{
    public interface IEngine
    {
        event Action<Move> OnMoveDone;

        IGame CurrentGame { get; }

        Colour ThinkingTurn { get; set; }

        void NewGame(IPosition<IBoard> initialPosition);

        void DoMove(Move move);

        void CancelThink();
    }
}
