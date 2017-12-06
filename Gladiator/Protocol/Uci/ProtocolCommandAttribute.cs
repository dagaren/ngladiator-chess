namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    internal class ProtocolCommandAttribute : Attribute
    {
        public string Protocol { get; set; }

        public string Regex { get; set; }

        public ProtocolCommandAttribute(string Protocol, string Regex)
        {
            this.Protocol = Protocol;
            this.Regex = Regex;
        }
    }
}