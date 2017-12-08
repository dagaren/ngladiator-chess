namespace Dagaren.Gladiator.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class CommandMatcher : ICommandMatcher
    {
        private Regex regex;

        private ICommandFactory commandFactory;

        private readonly IEnumerable<ICommandDescriptor> commandDescriptors;

        public CommandMatcher(Regex regex, ICommandFactory commandFactory)
        {
            this.regex = regex ?? throw new ArgumentNullException(nameof(regex));
            this.commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(regex));
        }

        public ICommand Match(string commandString)
        {
            Match match = this.regex.Match(commandString);

            if(!match.Success)
            {
                return default(TCommand);
            }

            IDictionary<string, string> parameters = this.ParseParameters(match);

            return this.commandFactory.Construct<TCommand>(parameters);
        }

        public TCommand Match<TCommand>(string commandString) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }

        private IDictionary<string, string> ParseParameters(Match match)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            IEnumerable<string> groupNames = this.regex.GetGroupNames();

            foreach (string groupName in groupNames)
            {
                int groupNumber;
                if (int.TryParse(groupName, out groupNumber))
                {
                    continue;
                }

                string groupValue = match.Groups[groupName].Value;

                parameters.Add(groupName, groupValue);
            }

            return parameters;
        }
    }
}
