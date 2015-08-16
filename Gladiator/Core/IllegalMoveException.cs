using System;

namespace Gladiator.Core
{
    public class IllegalMoveException : ArgumentException
    {
        public IllegalMoveException()
        {
        }

        public IllegalMoveException(string message)
                : base(message)
        {
        }

        public IllegalMoveException(string message, Exception inner)
                : base(message, inner)
        {
        }
    }
}
