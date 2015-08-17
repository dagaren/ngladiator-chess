using Gladiator.Representation;
using System;

namespace Gladiator.Search
{
    public interface IPrincipalVariationManager : IPrincipalVariation
    {
        void InitPly(int ply);

        void SaveMoveInPly(Move move, int ply);
    }
}
