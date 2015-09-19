using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core
{
    public class FixedTimePerMoveTimeControl : ITimeControl
    {
        private TimeSpan timePerMove;

        public FixedTimePerMoveTimeControl(TimeSpan timePerMove)
        {
            this.timePerMove = timePerMove;
        }

        public TimeSpan GetIncrement(int numMove)
        {
            return TimeSpan.FromSeconds(0);
        }

        public int GetMovesToNextControl(int numMove)
        {
            return 1;
        }

        public TimeSpan PreMoveTime(int numMove, TimeSpan previousTime)
        {
            return this.timePerMove;
        }

        public TimeSpan PostMoveTime(int numMove, TimeSpan previousTime)
        {
            return previousTime;
        }
    }
}
