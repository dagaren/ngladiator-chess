﻿using System;
using System.Text.RegularExpressions;

namespace Gladiator.Communication.Protocols.XBoard
{
    class XBoardCommandMatcher : CommandMatcher<XBoardCommand>
    {
        public XBoardCommandMatcher(ICommandFactory commandFactory)
            : base(
                new Regex(@"^xboard\s*$"),
                commandFactory)
        {
        }
    }
}
