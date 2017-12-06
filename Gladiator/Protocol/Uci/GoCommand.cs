
namespace Dagaren.Gladiator.Protocol.Uci
{
    [ProtocolCommand("Uci", @"^\s*" +
                            @"go" +
                            @"(\s+searchmoves (\s+(?<moves>[a-h][1-8][a-h][1-8](q|r|b|k)?))*)?" +
                            @"(\s+ponder)?" +
                            @"(\s+wtime\s+(?<wtime>\d+))?" +
                            @"(\s+btime\s+(?<btime>\d+))?" +
                            @"(\s+winc\s+(?<winc>\d+))?" +
                            @"(\s+binc\s+(?<binc>\d+))?" +
                            @"(\s+movestogo\s+(?<movestogo>\d+))?" +
                            @"(\s+depth\s+(?<depth>\d+))?" +
                            @"(\s+nodes\s+(?<nodes>\d+))?" +
                            @"(\s+(?<moves>[a-h][1-8][a-h][1-8](q|r|b|k)?))*" + 
                            @"\s*$")]
    class GoCommand : ICommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
