using Gladiator.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core
{
    interface IClock
    {
        void Start();

        void Change();

        TimeSpan GetRemainingTime(Colour colour);

        int GetMovesToNextTimeControl(Colour colour);

        TimeSpan IncrementPerMove(Colour colour);

        void Pause();

        void Resume();
    }
}
