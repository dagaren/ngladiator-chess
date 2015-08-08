using Gladiator.Utils;

namespace Gladiator.Communication.XBoard.Output
{
    public abstract class OutputCommand
    {
        protected ICommandWriter commandWriter;

        public OutputCommand(ICommandWriter commandWriter)
        {
            Check.ArgumentNotNull(commandWriter, "commandWriter");

            this.commandWriter = commandWriter;
        }
    }
}
