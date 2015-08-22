using Gladiator.Core;
using Gladiator.Representation;
using System;
using System.Linq;

namespace Gladiator.Communication.XBoard.Output
{
    public class PrincipalVariationChangeCommand : OutputCommand
    {
        public PrincipalVariationChangeCommand(ICommandWriter commandWriter) :
            base(commandWriter)
        {
        }

        public void Execute(PrincipalVariationChange principalVariationChange)
        {
            string info = string.Format("{0,3} {1, 6} {2,7} {3,9} {4}",
                principalVariationChange.Ply,
                principalVariationChange.Score,
                (int)(principalVariationChange.SearchTime.TotalMilliseconds / 10),
                principalVariationChange.Nodes,
                string.Join(" ", principalVariationChange.Moves.Select(m => m.Format())));
            this.commandWriter.Write(info);
        }
    }
}
