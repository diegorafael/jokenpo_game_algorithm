using RpsCore.Erros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RpsCore
{
    public class GameManager
    {
        private const int PlayersByTurn = 2;

        public GameEntry GetWinner(string[,] gameEntry)
        {
            Validate(gameEntry);

            var winnerGameEntry = GetWinner(GameEntryAdapter.GetGameEntries(gameEntry));

            return winnerGameEntry;
        }

        public GameEntry GetWinner(IList<string[,]> tournament)
        {
            IList<string[,]> winners = new List<string[,]>();
            string[,] buffer = null;

            for (int i = 0; i < tournament.Count ; i++)
            {
                var game = tournament[i];

                var currentWinner = GameEntryAdapter.GetStringArrayGameEntry(GetWinner(game));
                if (buffer == null)
                    buffer = currentWinner;
                else
                {
                    buffer = MountGame(buffer, currentWinner);
                    winners.Add(buffer);
                    buffer = null;
                }
            }

            if (winners.Count > 1)
                return GetWinner(winners);
            else
                return GetWinner(winners.First());
        }

        private string[,] MountGame(string[,] playerOne, string[,] playerTwo)
        {
            return new[,] { { playerOne[0, 0], playerOne[0, 1] }, { playerTwo[0, 0], playerTwo[0, 1] } };
        }

        private GameEntry GetWinner(IEnumerable<GameEntry> gameEntry)
        {
            return ComputeWinner(gameEntry.First(), gameEntry.Last()); ;
        }

        private GameEntry ComputeWinner(GameEntry firstPlayer, GameEntry secondPlayer)
        {
            // ToDo: Transformar em Evento
            RegisterGame(firstPlayer, secondPlayer);

            GameEntry result;

            if (firstPlayer.PlayerMove.Beat(secondPlayer.PlayerMove) || firstPlayer.PlayerMove.Equals(secondPlayer.PlayerMove))
                result = firstPlayer;
            else
                result = secondPlayer;

            // ToDo: Transformar em Evento
            NotifyWinner(result);

            return result;
        }
        private void RegisterGame(GameEntry firstPlayer, GameEntry secondPlayer)
        {
            Console.WriteLine($"{firstPlayer.PlayerName} vs {secondPlayer.PlayerName}...");
            Console.WriteLine($"{firstPlayer.PlayerName} played '{firstPlayer.PlayerMove.Simbol}' and {secondPlayer.PlayerName} played '{secondPlayer.PlayerMove.Simbol}'");

        }

        private void NotifyWinner(GameEntry winner)
        {
            Console.WriteLine($"{winner.PlayerName} won!");
            Console.WriteLine();
        }

        private void Validate(string[,] gameEntry)
        {
            ValidateNumberOfPlays(gameEntry.Length / gameEntry.Rank);
        }

        private void Validate(IEnumerable<GameEntry> gameEntry)
        {
            ValidateNumberOfPlays(gameEntry.Count());
        }

        private void ValidateNumberOfPlays(int number)
        {
            if (number != PlayersByTurn)
                throw new WrongNumberOfPlayersError();
        }
    }
}
