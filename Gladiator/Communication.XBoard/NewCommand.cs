using System;
using Gladiator.Core;
using Gladiator.Utils;
using Gladiator.Representation;

namespace Gladiator.Communication.XBoard
{
    public class NewCommand : ICommand
    {
        private IEngine engine;

        private IBuilder<IPosition<IBoard>> initialPositionBuilder;

        public NewCommand(IEngine engine, IBuilder<IPosition<IBoard>> initialPositionBuilder)
        {
            Check.ArgumentNotNull(engine, "engine");
            Check.ArgumentNotNull(initialPositionBuilder, "builder");

            this.engine = engine;
            this.initialPositionBuilder = initialPositionBuilder;
        }

        public void Execute()
        {
            IPosition<IBoard> position = this.initialPositionBuilder.Build();
            this.engine.NewGame(position);
            this.engine.ThinkingTurn = Colour.Black;
        }
    }
}
