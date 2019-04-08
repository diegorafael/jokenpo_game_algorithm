using RpsCore;
using System;
using System.Collections.Generic;

namespace RPS
{
    class Program
    {
        static GameManager gameManager = new GameManager();
        static string[,] ArnaldoVsDaveGame;
        static List<string[,]> RpsTournament;

        static void Main(string[] args)
        {
            ArnaldoVsDaveGame = new[,] {
                {"Armando","P" },
                {"Dave","S" },
            };

            rps_game_winner(ArnaldoVsDaveGame);
            Console.ReadLine();

            RpsTournament = new List<string[,]>(new[] {
                ArnaldoVsDaveGame,
                new [,] {
                    {"Richard","R" },
                    {"Michael","S" }
                },
                new [,] {
                    {"Allen","S" },
                    {"Omer","P" }
                },
                new [,] {
                    {"David E.","R" },
                    {"Richard X.","P" }
                },
            });

            rps_tournament_winner(RpsTournament);

            Console.ReadLine();
        }

        static void rps_game_winner(string[,] game)
        {
            var winner = gameManager.GetWinner(game);
        }

        static void rps_tournament_winner(IList<string[,]> tournament)
        {
            var winner = gameManager.GetWinner(tournament);

            Console.Write($"{winner.PlayerName} is the tournament winner");
        }
    }
}
