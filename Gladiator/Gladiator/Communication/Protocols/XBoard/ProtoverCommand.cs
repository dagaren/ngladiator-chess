using Gladiator.Communication.Protocols.XBoard.Output;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.Protocols.XBoard
{
    class ProtoverCommand : ICommand
    {
        private const int FeatureVersionLimit = 2;

        private int version;

        private Action featureCommandAction;

        public ProtoverCommand(int version, Action featureCommandAction)
        {
            Check.ArgumentNotNull(featureCommandAction, "featureCommandAction");

            this.version = version;

            this.featureCommandAction = featureCommandAction;
        }

        public void Execute()
        {
            if(this.version >= FeatureVersionLimit)
            {
                featureCommandAction();
            }
        }
    }
}
