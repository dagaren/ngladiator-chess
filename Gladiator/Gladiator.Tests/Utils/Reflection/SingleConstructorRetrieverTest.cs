using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gladiator.Utils.Reflection;
using Gladiator.Tests.Utils.Reflection.Fakes;

namespace Gladiator.Tests.Utils.Reflection
{
    [TestClass]
    public class SingleConstructorRetrieverTest
    {
        [TestMethod]
        public void GetConstructor_ClassWithOneConstructor_Ok()
        {
            var constructorRetriever = new SingleConstructorRetriever();

            ConstructorInfo constructor = constructorRetriever.GetConstructor(typeof(SingleConstructorFake));

            Assert.IsNotNull(constructor);
        }

        [TestMethod]
        public void GetConstructor_ClassWithManyConstructors_ArgumentExceptionExpected()
        {
            var constructorRetriever = new SingleConstructorRetriever();

            bool exceptionThrown = false;

            try
            {
                ConstructorInfo constructor = constructorRetriever.GetConstructor(typeof(MultiConstructorFake));
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
        }
    }
}
