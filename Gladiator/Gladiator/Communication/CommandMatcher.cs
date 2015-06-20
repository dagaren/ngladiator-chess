using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    class CommandMatcher<TCommand> : ICommandMatcher<TCommand> where TCommand : ICommand 
    {
        private Regex regex;

        private ICommandFactory commandFactory;

        public CommandMatcher(Regex regex, ICommandFactory commandFactory)
        {
            Check.ArgumentNotNull(regex, "regex");
            Check.ArgumentNotNull(commandFactory, "commandFactory");

            this.regex = regex;
            this.commandFactory = commandFactory;
        }

        public TCommand Match(string commandString)
        {
            Match match = this.regex.Match(commandString);

            if(!match.Success)
            {
                return default(TCommand);
            }

            IDictionary<string, string> parameters = this.ParseParameters(match);

            return this.commandFactory.Construct<TCommand>(parameters);
        }

        private IDictionary<string, string> ParseParameters(Match match)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            IEnumerable<string> groupNames = this.regex.GetGroupNames();

            foreach (string groupName in groupNames)
            {
                string groupValue = match.Groups[groupName].Value;

                parameters.Add(groupName, groupValue);
            }

            return parameters;
        }
    }
}
