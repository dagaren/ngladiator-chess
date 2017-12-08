namespace Dagaren.Gladiator.Protocol.Uci
{
    using System;
    using System.Text.RegularExpressions;

    class PositionCommandDescriptor : ICommandDescriptor
    {
        public Regex CommandRegex => new Regex(@"^\s*" +
                            @"position" + @"\s+" +
                            @"(startpos|fen (?<fen>([prnbqkPRNBQK12345678]+/){7}[prnbqkPRNBQK12345678]+\s+[wb]\s+(-|[KQkq]+)\s+([a-h][1-8]|-)\s+(\d+)\s+(\d+)))" + @"\s+" +
                            @"moves" +
                            @"(\s+(?<moves>[a-h][1-8][a-h][1-8](q|r|b|k)?))*" + @"\s*$");

        public Type CommandType => typeof(PositionCommand);
    }
}
