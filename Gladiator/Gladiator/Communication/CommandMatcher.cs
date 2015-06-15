using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gladiator.Communication
{
    class CommandMatcher<T> : ICommandMatcher<T> where T : ICommand
    {
        private Regex regex;

        private ICommandFactory commandFactory;

        public CommandMatcher(Regex regex, ICommandFactory commandFactory)
        {
            this.regex = regex;
            this.commandFactory = commandFactory;
        }

        public T Match(string command)
        {
            Match match = this.regex.Match(command);

            if (!match.Success)
            {
                return default(T);
            }

            IDictionary<string, string> parameters = this.ParseParameters(match);

            return this.commandFactory.Construct<T>(parameters);
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
