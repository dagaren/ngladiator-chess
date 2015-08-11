using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Representation
{
    public interface IPositionValidator<in TPosition, out TBoard> where TPosition : IPosition<TBoard>
    {
        bool IsValid(TPosition position);
    }
}
