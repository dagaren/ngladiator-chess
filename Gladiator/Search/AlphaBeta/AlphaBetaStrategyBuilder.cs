using Gladiator.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaStrategyBuilder
    {
        private INodeCounter nodeCounter;
        private CancellationToken cancellationToken;
        private TranspositionTable transpositionTable;
        private IPrincipalVariationManager principalVariationManager;
        private Action<PrincipalVariationChange> principalVariationChangeAction;
        private bool withAspirationWindow = false;
        private bool withIterativeDeepening = false;
        private bool withQuiescenceSearch = false;
        private IEvaluator staticEvaluator;

        public IAlphaBetaStrategy Build(NodeCounter nodeCounter, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public AlphaBetaStrategyBuilder WithPrincipalVariationManager(
            IPrincipalVariationManager principalVariationManager,
            Action<PrincipalVariationChange> principalVariationChangeAction
            )
        {
            this.principalVariationManager = principalVariationManager;
            this.principalVariationChangeAction = principalVariationChangeAction;
            return this;
        }

        public AlphaBetaStrategyBuilder WithAspirationWindow()
        {
            this.withAspirationWindow = true;
            return this;
        }

        public AlphaBetaStrategyBuilder WithIterativeDeepening()
        {
            this.withIterativeDeepening = true;
            return this;
        }

        public AlphaBetaStrategyBuilder WithQuiescenceSearch()
        {
            this.withQuiescenceSearch = true;
            return this;
        }

        public AlphaBetaStrategyBuilder WithTransposicionTable(TranspositionTable transpositionTable)
        {
            this.transpositionTable = transpositionTable;
            return this;
        }

        public AlphaBetaStrategyBuilder WithNodeCounter(INodeCounter counter)
        {
            this.nodeCounter = counter;
            return this;
        }

        public AlphaBetaStrategyBuilder WithCancellationToken(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
            return this;
        }

        public AlphaBetaStrategyBuilder WithStaticEvaluator(IEvaluator staticEvaluator)
        {
            this.staticEvaluator = staticEvaluator;
            return this;
        }

        public IAlphaBetaStrategy Build()
        {
            IMoveSorter moveSorter = new BasicMoveSorter();
            IMoveSorter mvvLvaSorter = new MvvLvaMoveSorter();

            ////////
            var mainStrategy = new AlphaBetaMainStrategy(moveSorter);

            IAlphaBetaStrategy mainStrategyBranch = mainStrategy;

            if(this.transpositionTable != null)
            {
                mainStrategyBranch = new AlphaBetaTranspositionTableStrategy(this.transpositionTable, mainStrategyBranch);
            }

            if(this.principalVariationManager != null)
            {
                mainStrategyBranch = new PrincipalVariationAlphaBetaStrategy(this.principalVariationManager, mainStrategyBranch);
            }

            if(this.cancellationToken != null)
            {
                mainStrategyBranch = new AlphaBetaCancellation(this.cancellationToken, mainStrategyBranch);
            }

            if(this.nodeCounter != null)
            {
                mainStrategyBranch = new AlphaBetaCounterStrategy(mainStrategyBranch, this.nodeCounter);
            }
            /////////

            /////////
            IAlphaBetaStrategy finalStrategyBranch = new AlphaBetaStaticEvaluationStrategy(this.staticEvaluator);

            AlphaBetaQuiescenceStrategy quiescenceStrategy = null;
            if(this.withQuiescenceSearch)
            {
                quiescenceStrategy = new AlphaBetaQuiescenceStrategy(finalStrategyBranch, mvvLvaSorter);
                finalStrategyBranch = quiescenceStrategy;
            }

            if(this.principalVariationManager != null)
            {
                finalStrategyBranch = new PrincipalVariationAlphaBetaStrategy(this.principalVariationManager, finalStrategyBranch);
            }

            if(this.cancellationToken != null)
            {
                finalStrategyBranch = new AlphaBetaCancellation(this.cancellationToken, finalStrategyBranch);
            }

            if(this.nodeCounter != null)
            {
                finalStrategyBranch = new AlphaBetaCounterStrategy(finalStrategyBranch, this.nodeCounter);
            }

            if(quiescenceStrategy != null)
            {
                quiescenceStrategy.RecursiveStrategy = finalStrategyBranch;
            }
            /////////

            var finalPlyStrategy = new AlphaBetaFinalPlyStrategy(finalStrategyBranch, mainStrategyBranch);
            mainStrategy.RecursiveStrategy = finalPlyStrategy;

            IAlphaBetaStrategy strategy = finalPlyStrategy;

            if(this.withAspirationWindow)
            {
                strategy = new AlphaBetaAspirationWindowStrategy(strategy);
            }

            if(this.withIterativeDeepening)
            {
                strategy = new AlphaBetaIterativeDeepeningStrategy(strategy);
            }

            if(this.nodeCounter != null && this.principalVariationManager != null)
            {
                strategy = new AlphaBetaEntryStrategy(
                                        strategy,
                                        this.principalVariationManager,
                                        this.nodeCounter,
                                        this.principalVariationChangeAction);
            }
            
            return strategy;
        }
    }
}
