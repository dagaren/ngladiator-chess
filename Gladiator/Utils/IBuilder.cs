using System;

namespace Gladiator.Utils
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
