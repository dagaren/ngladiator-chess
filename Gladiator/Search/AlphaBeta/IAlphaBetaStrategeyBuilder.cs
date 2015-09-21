using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gladiator.Search.AlphaBeta
{
    interface IAlphaBetaStrategeyBuilder
    {
        IAlphaBetaStrategeyBuilder WithNodeCounter(NodeCounter counter);

        IAlphaBetaStrategeyBuilder WithCancellationToken(CancellationToken cancellationToken);

        IAlphaBetaStrategy Build();
    }
}
