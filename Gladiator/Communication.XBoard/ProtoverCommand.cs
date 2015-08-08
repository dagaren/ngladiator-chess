using Gladiator.Communication.XBoard.Output;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.XBoard
{
    public class ProtoverCommand : ICommand
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
