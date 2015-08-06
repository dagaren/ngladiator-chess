using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.Protocols.XBoard.Output
{
    class FeatureContainer
    {
        private IDictionary<string, object> features = new Dictionary<string, object>();

        public FeatureContainer Add(string name, bool value)
        {
            this.features[name] = value;

            return this;
        }

        public FeatureContainer Add(string name, string value)
        {
            this.features[name] = value;

            return this;
        }

        public FeatureContainer Add(string name, int value)
        {
            this.features[name] = value;

            return this;
        }

        public IEnumerable<KeyValuePair<string, object>> GetFeatures()
        {
            return this.features;
        }
    }
}
