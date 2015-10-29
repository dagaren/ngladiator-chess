using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gladiator.Search
{
    public class SearchExecution : ISearchExecution
    {
        public event Action<Move> OnSearchFinished;

        public event Action<PrincipalVariationChange> OnPrincipalVariationChanged;

        private Func<CancellationTokenSource, Action<PrincipalVariationChange>, Move> searchFunction;

        private CancellationTokenSource cancellationTokenSource;

        private Task task;

        public SearchExecution(Func<CancellationTokenSource, Action<PrincipalVariationChange>, Move> searchFunction)
        {
            Check.ArgumentNotNull(searchFunction, "searchFunction");

            this.searchFunction = searchFunction;
        }

        public void Init()
        {
            this.InitSearch();
        }

        public void Cancel()
        {
            this.cancellationTokenSource.Cancel();
            this.task.Wait();
        }

        public void Wait()
        {
            this.task.Wait();
        }

        private void InitSearch()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.task = Task.Factory.StartNew(
                       () =>
                       {
                           try
                           {
                               Move move = this.searchFunction(cancellationTokenSource, this.PrincipalVariationChange);
                               if(this.OnSearchFinished != null)
                               {
                                   this.OnSearchFinished(move);
                               }
                           }
                           catch (OperationCanceledException)
                           {
                           }
                       },
                       TaskCreationOptions.LongRunning);
        }

        private void PrincipalVariationChange(PrincipalVariationChange change)
        {
            if (this.OnPrincipalVariationChanged != null)
            {
                this.OnPrincipalVariationChanged(change);
            }
        }
    }
}
