using System;

namespace Gladiator.Tests.Utils.Reflection.Fakes
{
    class SingleConstructorMultiArgumentsFake
    {
        public int NumericArgument { get; private set; }

        public string StringArgument { get; private set; }

        public SingleConstructorMultiArgumentsFake(int numericArgument, string stringArgument)
        {
            this.NumericArgument = numericArgument;
            this.StringArgument = stringArgument;
        }
    }
}
