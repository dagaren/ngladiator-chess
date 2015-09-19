using Gladiator.Communication.Tests;
using Gladiator.Communication.XBoard;
using Gladiator.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.XBoard.Tests
{
    [TestClass]
    public class LevelCommandMatcherTest
    {
        private CommandMatcherTester<LevelCommandMatcher, LevelCommand> tester;

        [TestInitialize]
        public void TestInitialize()
        {
            this.tester = new CommandMatcherTester<LevelCommandMatcher, LevelCommand>(
                    new LevelCommand(
                        Substitute.For<IEngine>(),
                        0,0,0,0
                    ),
                    x => new LevelCommandMatcher(x));
        }

        [TestMethod]
        public void TestNotMatchingCommands()
        {
            this.tester.TestNotMatching(new string[]{
                "level",
                " level",
                "level 1",
                "level 1 2",
                "level 1 as 2",
                string.Empty
            });
        }

        [TestMethod]
        public void TestMatchingCommands()
        {
            this.tester.TestMatching(new CommandMatching[] {
                new CommandMatching { 
                    CommandString = "level 10 5 1", 
                    CommandParameters = new Dictionary<string, string>() {
                       { LevelCommandMatcher.NumMovesName, "10" },
                       { LevelCommandMatcher.MinutesName, "5" },
                       { LevelCommandMatcher.SecondsName, "" },
                       { LevelCommandMatcher.IncrementInSecondsName, "1" },
                    }
                },
                new CommandMatching { 
                    CommandString = "level 10 5:10 1", 
                    CommandParameters = new Dictionary<string, string>() {
                       { LevelCommandMatcher.NumMovesName, "10" },
                       { LevelCommandMatcher.MinutesName, "5" },
                       { LevelCommandMatcher.SecondsName, "10" },
                       { LevelCommandMatcher.IncrementInSecondsName, "1" },
                    }
                }
            });
        }
    }
}
