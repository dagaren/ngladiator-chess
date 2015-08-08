using Gladiator.Utils;
using System.IO;
using System;

namespace Gladiator.Communication
{
    public class LoggedCommandReader : ICommandReader
    {
        private string logPath;

        private ICommandReader innerCommandReader;

        public LoggedCommandReader(string logPath, ICommandReader innerCommandReader)
        {
            Check.ArgumentNotNull(innerCommandReader, "innerCommandReader");

            this.logPath = logPath;
            this.innerCommandReader = innerCommandReader;
        }

        public string Read()
        {
            var command = this.innerCommandReader.Read();

            File.AppendAllText(this.logPath, command + Environment.NewLine);

            return command;
        }
    }
}
