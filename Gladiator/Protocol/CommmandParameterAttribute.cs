namespace Dagaren.Gladiator.Protocol
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Parameter)]
    internal class CommmandParameterAttribute : Attribute
    {
        public Type ParserType { get; private set; }

        public CommmandParameterAttribute(Type parserType)
        {
            bool isParser = parserType.GetInterfaces().Any(
                x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IParser<>));
            if (!isParser)
            {
                throw new ArgumentException("Type does not implement IParser interface");
            }

            this.ParserType = parserType;
        }
    }
}