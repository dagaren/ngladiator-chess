using System;
using System.Reflection;

namespace Gladiator.Utils
{
    public static class EnvironmentExtensions
    {
        public static string GetExecutablePath()
        {
            return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }
    }
}
