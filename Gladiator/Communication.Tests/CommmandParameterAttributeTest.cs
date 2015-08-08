using Gladiator.Communication;
using Gladiator.Communication.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gladiator.Tests.Communication
{
    [TestClass]
    public class CommmandParameterAttributeTest
    {
        [TestMethod]
        public void Constructor_TypeArgumentImplementingParser_Ok()
        {
            var attribute = new CommmandParameterAttribute(typeof(FakeIntParser));
        }

        [TestMethod]
        public void Constructor_TypeArgumentNotImplementingParser_ArgumentExceptionExpected()
        {
            bool exceptionThrown = false;

            try
            {
                var attribute = new CommmandParameterAttribute(typeof(string));
            }
            catch(ArgumentException)
            {
                exceptionThrown = true;
            }

            Assert.AreEqual(true, exceptionThrown);
        }
    }
}
