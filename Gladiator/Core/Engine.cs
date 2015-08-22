using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Search;

namespace Gladiator.Core
{
    public class Engine : IEngine
    {
        private IGame currentGame;

        private Colour thinkingTurn;
        
        private ISearchExecution currentSearchExecution;

        private readonly ISearcher searcher;

        private int maxSearchDepth;

        public event Action<Move> OnMoveDone;

        public event Action<PrincipalVariationChange> OnPrincipalVariationChange;

        public IGame CurrentGame
        {
            get { return this.currentGame; }
        }

        public Colour ThinkingTurn { 
            get { return this.thinkingTurn; }
            set 
            { 
                this.thinkingTurn = value;

                Think();
            }
        }

        public int MaxSearchDepth {
            get { return this.maxSearchDepth; }
            set 
            { 
                if(value < 1)
                {
                    throw new ArgumentException();
                }
                this.maxSearchDepth = value; 
            }
        }

        public bool PrincipalVariationEnabled { get; set; }

        public Engine(ISearcher searcher)
        {
            Check.ArgumentNotNull(searcher, "searcher");

            this.searcher = searcher;
            this.MaxSearchDepth = 4;
            this.PrincipalVariationEnabled = false;
        }

        public void NewGame(IPosition<Representation.IBoard> initialPosition)
        {
            this.currentGame = new Game(initialPosition);
        }

        public void DoMove(Move move)
        {
            this.currentGame.DoMove(move);

            this.Think();
        }

        public void CancelThink()
        {
            if (this.currentSearchExecution != null)
            {
                this.currentSearchExecution.Cancel();
                this.currentSearchExecution.OnSearchFinished -= this.OnMoveDone;
                this.currentSearchExecution.OnPrincipalVariationChanged -= this.SearchFoundPrincipalVariationChange;
                this.currentSearchExecution = null;
            }
        }

        private void Think()
        {
            this.CancelThink();

            if (this.ThinkingTurn == this.CurrentGame.Turn)
            {
                this.currentSearchExecution = this.searcher.InitSearch(this.CurrentGame.Position, new SearchOptions() { 
                    SearchDepth = this.MaxSearchDepth
                });
                this.currentSearchExecution.OnSearchFinished += this.MoveFound;
                this.currentSearchExecution.OnPrincipalVariationChanged += this.SearchFoundPrincipalVariationChange;
                this.currentSearchExecution.Init();
            }
        }

        private void MoveFound(Move move)
        {
            if(this.ThinkingTurn == this.currentGame.Turn)
            {
                this.currentGame.DoMove(move);
                this.OnMoveDone(move);
            }
        }

        private void SearchFoundPrincipalVariationChange(Search.PrincipalVariationChange principalVariationChange)
        {
            var change = new PrincipalVariationChange(
                                principalVariationChange.Ply, 
                                principalVariationChange.Score, 
                                principalVariationChange.SearchTime, 
                                principalVariationChange.Nodes, 
                                principalVariationChange.Moves);

            if(this.PrincipalVariationEnabled)
            {
                this.OnPrincipalVariationChange(change);
            }
        }
    }
}
