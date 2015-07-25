using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gladiator.Tests.Utils.Reflection.Fakes;
using Gladiator.Utils.Reflection;
using NSubstitute;

namespace Gladiator.Tests.Utils.Reflection
{
    [TestClass]
    public class ConstructorInvokerTest
    {
        [TestMethod]
        public void Invoke_ConstructorWithoutArguments_Ok()
        {
            ConstructorInfo constructor = typeof(SingleConstructorFake).GetConstructors().First();
            IParameterFactory parameterFactory = Substitute.For<IParameterFactory>();

            var constructorInvoker = new ConstructorInvoker();

            object instance = constructorInvoker.Invoke(constructor, parameterFactory);

            Assert.IsNotNull(instance);
            Assert.AreEqual(typeof(SingleConstructorFake), instance.GetType());
        }

        [TestMethod]
        public void Invoke_ConstructorWithManyArguments_Ok()
        {
            ConstructorInfo constructor = typeof(SingleConstructorMultiArgumentsFake).GetConstructors().First();
            IParameterFactory parameterFactory = Substitute.For<IParameterFactory>();

            int numericArgumentValue = 10;
            string stringArgumentValue = "value";
            parameterFactory.Generate(Arg.Is<ParameterInfo>(x => x.Name == "numericArgument")).Returns(numericArgumentValue);
            parameterFactory.Generate(Arg.Is<ParameterInfo>(x => x.Name == "stringArgument")).Returns(stringArgumentValue);

            var constructorInvoker = new ConstructorInvoker();

            var instance = constructorInvoker.Invoke(constructor, parameterFactory) as SingleConstructorMultiArgumentsFake;

            Assert.IsNotNull(instance);
            Assert.AreEqual(numericArgumentValue, instance.NumericArgument);
            Assert.AreEqual(stringArgumentValue, instance.StringArgument);
        }

        [TestMethod]
        public void Invoke_ConstructorWithArgumentsParameterMissing_ArgumentExceptionExpected()
        {
            ConstructorInfo constructor = typeof(SingleConstructorMultiArgumentsFake).GetConstructors().First();
            IParameterFactory parameterFactory = Substitute.For<IParameterFactory>();

            int numericArgumentValue = 10;
            parameterFactory.Generate(Arg.Is<ParameterInfo>(x => x.Name == "numericArgument")).Returns(numericArgumentValue);
            parameterFactory.Generate(Arg.Is<ParameterInfo>(x => x.Name == "stringArgument")).Returns(x => { throw new ArgumentException(); });
            
            var constructorInvoker = new ConstructorInvoker();

            bool exceptionThrown = false;

            try
            {
                var instance = constructorInvoker.Invoke(constructor, parameterFactory) as SingleConstructorMultiArgumentsFake;
            }
            catch(ArgumentException ex)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }
    }
}
