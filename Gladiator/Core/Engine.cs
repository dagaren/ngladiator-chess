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

        private ITimeControl timeControl;

        private IClock clock;

        public event Action<Move> OnMoveDone;

        public event Action<PrincipalVariationChange> OnPrincipalVariationChange;

        public IGame CurrentGame
        {
            get { return this.currentGame; }
        }

        public Colour ThinkingTurn 
        { 
            get { return this.thinkingTurn; }
            set 
            { 
                this.thinkingTurn = value;

                Think();
            }
        }

        public int MaxSearchDepth 
        {
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

        public ITimeControl TimeControl
        {
            get { return this.timeControl; }
            set 
            { 
                this.timeControl = value;
                this.clock = new Clock(this.timeControl);
                this.clock.Start();
            }
        }

        public bool PrincipalVariationEnabled { get; set; }

        public Engine(ISearcher searcher)
        {
            Check.ArgumentNotNull(searcher, "searcher");

            this.searcher = searcher;
            this.MaxSearchDepth = 100;
            this.PrincipalVariationEnabled = false;
            this.TimeControl = new FixedTimePerMoveTimeControl(TimeSpan.FromSeconds(30));
        }

        public void NewGame(IPosition<Representation.IBoard> initialPosition)
        {
            this.currentGame = new Game(initialPosition);
        }

        public void DoMove(Move move)
        {
            this.currentGame.DoMove(move);
            this.clock.Change();
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
                    SearchDepth = this.MaxSearchDepth,
                    SearchTime = this.CalculateSearchTime()
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
                this.clock.Change();
                this.OnMoveDone(move);
            }
        }

        private TimeSpan CalculateSearchTime()
        {
            long remainingTime = (long)(this.clock.GetRemainingTime(this.thinkingTurn).TotalMilliseconds);
            int remainingMoves = this.clock.GetMovesToNextTimeControl(this.thinkingTurn);
            long increment = (long)this.clock.IncrementPerMove(this.thinkingTurn).TotalMilliseconds;

            if(remainingMoves < 0)
            {
                remainingMoves = 20;
            }

            long searchTime = (long)((remainingTime / remainingMoves) + (increment * 0.95));
            searchTime = searchTime > 300 ? searchTime - 200 : searchTime;
            Console.WriteLine("# Remaining Time: {0} milliseconds, Remaining moves: {1} Search time: {2} milliseconds", remainingTime, remainingMoves, searchTime);
            return TimeSpan.FromMilliseconds(searchTime);
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
