using System;

namespace Gladiator.Search.AlphaBeta
{
    public enum AlphaBetaScore
    {
        InitialAlpha = -10000 - 1,
        InitialBeta = 100000 + 1,
        CheckMateScore = -10000,
        DrawScore = 0
    }
}
