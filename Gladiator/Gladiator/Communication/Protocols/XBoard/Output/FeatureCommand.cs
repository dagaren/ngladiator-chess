using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Communication.Protocols.XBoard.Output
{
    class FeatureCommand : OutputCommand
    {
        public FeatureCommand(ICommandWriter commandWriter) :
            base(commandWriter)
        {
        }

        public void Execute()
        {
            var featuresContainer = new FeatureContainer()
                                        .Add(FeatureNames.Ping, false)
                                        .Add(FeatureNames.Setboard, true)
                                        .Add(FeatureNames.Playother, false)
                                        .Add(FeatureNames.San, false)
                                        .Add(FeatureNames.Usermove, true)
                                        .Add(FeatureNames.Time, false)
                                        .Add(FeatureNames.Draw, true)
                                        .Add(FeatureNames.Sigint, false)
                                        .Add(FeatureNames.Sigterm, false)
                                        .Add(FeatureNames.Reuse, true)
                                        .Add(FeatureNames.Analyze, false)
                                        .Add(FeatureNames.Myname, "Gladiator")
                                        .Add(FeatureNames.Variants, "normal")
                                        .Add(FeatureNames.Colors, false)
                                        .Add(FeatureNames.Ics, false)
                                        .Add(FeatureNames.Name, false)
                                        .Add(FeatureNames.Pause, false)
                                        .Add(FeatureNames.Nps, false)
                                        .Add(FeatureNames.Debug, false)
                                        .Add(FeatureNames.Memory, false)
                                        .Add(FeatureNames.Smp, false)
                                        .Add(FeatureNames.Egt, string.Empty)
                                        .Add(FeatureNames.Option, string.Empty)
                                        .Add(FeatureNames.Exclude, false)
                                        .Add(FeatureNames.Setscore, false)
                                        .Add(FeatureNames.Done, 1);

            var serialized = string.Join(" ", featuresContainer.GetFeatures().Select(x => SerializeEntry(x)));

            this.commandWriter.Write(string.Format("feature {0}", serialized));
        }

        private string SerializeEntry(KeyValuePair<string, object> keyValuePair)
        {
            return string.Join("=", keyValuePair.Key, this.SerializeFeature((dynamic)(keyValuePair.Value)));
        }

        private string SerializeFeature(bool booleanFeature)
        {
            return booleanFeature == true ? "1" : "0";
        }

        private string SerializeFeature(string stringFeature)
        {
            return string.Format("\"{0}\"", stringFeature);
        }

        private string SerializeFeature(int integerFeature)
        {
            return integerFeature.ToString();
        }
    }
}
