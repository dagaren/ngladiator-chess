using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Core
{
    public class Engine : IEngine
    {
        private IGame currentGame;
        private Colour thinkingTurn;

        public event Action<Move> OnMoveDone;

        public IGame CurrentGame
        {
            get { return this.currentGame; }
        }

        public Colour ThinkingTurn { 
            get { return this.thinkingTurn; }
            set 
            { 
                this.thinkingTurn = value;

                TryThink();
            }
        }

        public Engine()
        {
        }

        public void NewGame(IPosition<Representation.IBoard> initialPosition)
        {
            this.currentGame = new Game(initialPosition);
        }

        public void DoMove(Move move)
        {
            this.currentGame.DoMove(move);

            TryThink();
        }

        private void TryThink()
        {
            if (this.ThinkingTurn == this.CurrentGame.Turn)
            {
                IEnumerable<Move> moves = this.CurrentGame.GetMoves();
                Move selectedMove = moves.Random();
                this.CurrentGame.DoMove(selectedMove);
                this.OnMoveDone(selectedMove);
            }
        }
    }
}
