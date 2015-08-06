using Gladiator.Utils;
using System;
using System.IO;

namespace Gladiator.Communication
{
    class LoggedCommandWriter: ICommandWriter
    {
        private string logPath;

        private ICommandWriter innerCommandWriter;

        public LoggedCommandWriter(string logPath, ICommandWriter innerCommandWriter)
        {
            Check.ArgumentNotNull(innerCommandWriter, "innerCommandWriter");

            this.logPath = logPath;
            this.innerCommandWriter = innerCommandWriter;
        }

        public void Write(string command)
        {
            File.AppendAllText(this.logPath, command + Environment.NewLine);

            this.innerCommandWriter.Write(command);
        }
    }
}
