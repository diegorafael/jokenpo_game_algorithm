using System.Collections.Generic;

namespace RpsCore
{
    internal class GameEntryAdapter
    {
        internal static IEnumerable<GameEntry> GetGameEntries(string[,] entries)
        {
            var result =new[]
            {
                new GameEntry(entries[0,0], entries[0,1]),
                new GameEntry(entries[1,0], entries[1,1]),
            };

            return result;
        }

        internal static string[,] GetStringArrayGameEntry(GameEntry gameEntry)
        {
            return new[,] { { gameEntry.PlayerName, gameEntry.PlayerMove.Simbol } };
        }
        internal static GameEntry GetGameEntry(string[,] entries)
        {
            return new GameEntry(entries[0, 0], entries[0, 1]);
        }
    }
}
