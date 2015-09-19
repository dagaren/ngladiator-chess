using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core
{
    public class TimeControl : ITimeControl
    {
        public int NumMoves { get { return this.numMoves; }  }

        public TimeSpan BaseTime { get { return this.BaseTime; } }

        public TimeSpan Increment { get { return this.increment; } }

        private int numMoves;

        private TimeSpan baseTime;

        private TimeSpan increment;

        public TimeControl(int numMoves, TimeSpan baseTime, TimeSpan increment)
        {
            this.numMoves = numMoves;
            this.baseTime = baseTime;
            this.increment = increment;
        }

        public TimeSpan GetIncrement(int numMove)
        {
            return this.increment;
        }
        public int GetMovesToNextControl(int numMove)
        {
            return this.numMoves == 0 ? -1 : this.numMoves - ((numMove - 1) % this.numMoves);
        }

        public TimeSpan PreMoveTime(int numMove, TimeSpan previousTime)
        {
            if(numMove == 1)
            {
                return this.baseTime;
            }
            else if(this.numMoves > 0 && numMove % this.numMoves == 1)
            {
                return this.baseTime.Add(previousTime);
            }

            return previousTime;
        }

        public TimeSpan PostMoveTime(int numMove, TimeSpan previousTime)
        {
            return previousTime.Add(this.increment);
        }
    }
}
