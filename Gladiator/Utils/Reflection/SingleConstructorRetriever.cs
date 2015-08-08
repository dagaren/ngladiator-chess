using System;
using System.Linq;
using System.Reflection;

namespace Gladiator.Utils.Reflection
{
    public class SingleConstructorRetriever : IConstructorRetriever
    {
        public ConstructorInfo GetConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            if (constructors.Length != 1)
            {
                throw new ArgumentException(
                    string.Format(
                        "The type <{0}> should have just one constructor, but it has <{1}>.",
                        type.Name,
                        constructors.Length));
            }

            return constructors.First();
        }
    }
}
