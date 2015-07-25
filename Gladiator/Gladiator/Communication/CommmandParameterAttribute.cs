using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gladiator.Utils;

namespace Gladiator.Communication
{
    [AttributeUsage(AttributeTargets.Parameter)]
    class CommmandParameterAttribute : Attribute
    {
        public Type ParserType { get; private set; }

        public CommmandParameterAttribute(Type parserType)
        {
            bool isParser = parserType.GetInterfaces().Any(
                x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IParser<>));
            if(!isParser)
            {
                throw new ArgumentException("El tipo no implementa la interfaz IParser");
            }

            this.ParserType = parserType;
        }
    }
}
