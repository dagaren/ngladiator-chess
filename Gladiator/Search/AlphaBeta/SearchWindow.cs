using System;

namespace Gladiator.Search.AlphaBeta
{
    class SearchWindow
    {
        private int alpha;

        private int beta;

        public int Alpha { get { return this.alpha; } }

        public int Beta { get { return this.beta; } }

        public SearchWindow(int alpha, int beta)
        {
            this.alpha = alpha;
            this.beta = beta;
        }

        public void SetInterval(int alpha, int beta)
        {
            if(alpha > beta)
            {
                throw new ArgumentException(string.Format("Alpha {0} cannot be greater than beta {1}", alpha, beta));
            }

            this.alpha = alpha;
            this.beta = beta;
        }

        public bool IsFail(int score)
        {
            return this.IsFailLow(score) || this.IsFailHigh(score);
        }

        public bool IsFailHigh(int score)
        {
            return score >= this.beta;
        }

        public bool IsFailLow(int score)
        {
            return score <= this.alpha;
        }
    }
}
