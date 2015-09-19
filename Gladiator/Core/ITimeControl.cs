using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Core
{
    public interface ITimeControl
    {
        TimeSpan GetIncrement(int numMove);

        int GetMovesToNextControl(int numMove);

        TimeSpan PreMoveTime(int numMove, TimeSpan previousTime);

        TimeSpan PostMoveTime(int numMove, TimeSpan previousTime);
    }
}
