﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Tests
{
    public class CommandMatching
    {
        public string CommandString { get; set; }

        public IDictionary<string, string> CommandParameters { get; set; }
    }
}
