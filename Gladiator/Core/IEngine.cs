using Gladiator.Representation;
using System;

namespace Gladiator.Core
{
    public interface IEngine
    {
        IGame CurrentGame { get; }

        Colour ThinkingTurn { get; set; }

        int MaxSearchDepth { get; set; }

        ITimeControl TimeControl { get; set; }

        bool PrincipalVariationEnabled { get; set; }

        event Action<Move> OnMoveDone;

        event Action<PrincipalVariationChange> OnPrincipalVariationChange;

        void NewGame(IPosition<IBoard> initialPosition);

        void DoMove(Move move);

        void CancelThink();
    }
}
