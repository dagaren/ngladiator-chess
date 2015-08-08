using System;
using Gladiator.Communication;

namespace Gladiator.Communication.Tests.Fakes
{
    class FakeCommandConstructorWithCommandParameterAttribute : ICommand
    {
        public int Value { private set; get; }

        public FakeCommandConstructorWithCommandParameterAttribute(
            [CommmandParameter(parserType: typeof(FakeIntParser))]int value)
        {
            this.Value = value;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
