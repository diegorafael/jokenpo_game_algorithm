namespace RpsCore
{
    public class GameEntry
    {
        public string PlayerName { get; set; }
        public IPlayStrategy PlayerMove { get; set; }

        public GameEntry(string playerName, string playerMove)
        {
            PlayerName = playerName;
            PlayerMove = PlayStrategyCreator.CreatePlayStrategy(playerMove);
        }
    }
}
