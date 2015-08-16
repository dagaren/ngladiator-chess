using Gladiator.Core;
using Gladiator.Representation;
using Gladiator.Representation.Notation;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Communication.XBoard
{
    public class UserMoveCommand : ICommand 
    {
        private IEngine engine;

        private Move move;

        private Action<Move, string> illegalMoveAction;

        public UserMoveCommand(
            IEngine engine,
            [CommmandParameter(typeof(AlgebraicCoordinateParser))]Move move,
            Action<Move, string> illegalMoveAction
            )
        {
            Check.ArgumentNotNull(engine, "engine");
            Check.ArgumentNotNull(move, "move");
            Check.ArgumentNotNull(illegalMoveAction, "illegalMoveAction");

            this.engine = engine;
            this.move = move;
            this.illegalMoveAction = illegalMoveAction;
        }

        public void Execute()
        {
            try
            {
                this.engine.DoMove(this.move);
            }
            catch(IllegalMoveException)
            {
                this.illegalMoveAction(this.move, string.Empty);
            }
        }
    }
}
