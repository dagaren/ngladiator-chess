using Gladiator.Representation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Search
{
    public class PrincipalVariation : IPrincipalVariationManager
    {
        private readonly Move[][] movesMatrix;
        private readonly int[] numMovesInDepth;
        private const int size = 30;

        public PrincipalVariation()
        {
            this.movesMatrix = new Move[size + 1][];
            this.numMovesInDepth = new int[size + 1];
            for (int i = 0; i < size + 1; i++ )
            {
                this.movesMatrix[i] = new Move[size + 1];
                this.numMovesInDepth[i] = 0;
            }
        }

        public void InitPly(int ply)
        {
            this.numMovesInDepth[ply] = 0;
            this.numMovesInDepth[ply + 1] = 0;
        }

        public void SaveMoveInPly(Representation.Move move, int ply)
        {
            if(this.numMovesInDepth[ply + 1] > 0)
            {
                Move[] temp = this.movesMatrix[ply + 1];
                this.movesMatrix[ply + 1] = this.movesMatrix[ply];
                this.movesMatrix[ply] = temp;
            }

            this.numMovesInDepth[ply] = this.numMovesInDepth[ply + 1] + 1;
            this.movesMatrix[ply][ply] = move;

            if(ply == 0)
            {
                //TODO: Launch event
            }
        }

        public IEnumerable<Move> GetMoves()
        {
            if(this.numMovesInDepth[0] > 0)
            {
                return this.movesMatrix[0].Take(this.numMovesInDepth[0]);
            }
            else
            {
                return Enumerable.Empty<Move>();
            }
        }
    }
}
