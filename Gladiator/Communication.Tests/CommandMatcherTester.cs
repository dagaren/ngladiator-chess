using Gladiator.Communication;
using Gladiator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace Gladiator.Communication.Tests
{
    public class CommandMatcherTester<TCommandMatcher, TCommand> 
        where TCommandMatcher : ICommandMatcher<TCommand>
        where TCommand : ICommand
    {
        private TCommand commandInstance;

        private TCommandMatcher commandMatcherInstance;

        private ICommandFactory commandFactory;

        public CommandMatcherTester(TCommand commandInstance, Func<ICommandFactory, TCommandMatcher> commandMatcherRetriever)
        {
            Check.ArgumentNotNull(commandInstance, "commandInstance");
            Check.ArgumentNotNull(commandMatcherRetriever, "commandMatcherRetriever");

            this.commandInstance = commandInstance;
            this.commandFactory = Substitute.For<ICommandFactory>();
            this.commandMatcherInstance = commandMatcherRetriever(this.commandFactory);

            this.commandFactory.Construct<TCommand>(null).ReturnsForAnyArgs(this.commandInstance);
        }

        public void TestNotMatching(IEnumerable<string> notMatchingCommandStrings)
        {
            foreach(string notMatchingCommandString in notMatchingCommandStrings)
            {
                this.commandFactory.ClearReceivedCalls();
                TCommand matchedCommand = this.commandMatcherInstance.Match(notMatchingCommandString);

                Assert.IsNull(matchedCommand);
                this.commandFactory.DidNotReceiveWithAnyArgs().Construct<TCommand>(null);
            }
        }

        public void TestMatching(IEnumerable<CommandMatching> matchingEntities)
        {
            foreach(CommandMatching matchingEntity in matchingEntities)
            {
                this.commandFactory.ClearReceivedCalls();

                TCommand matchedCommand = this.commandMatcherInstance.Match(matchingEntity.CommandString);
                
                Assert.IsNotNull(matchedCommand);
                this.commandFactory.Received().Construct<TCommand>(Arg.Is<IDictionary<string, string>>(args => args.DictionaryEquals(matchingEntity.CommandParameters)));
            }
        }
    }
}
