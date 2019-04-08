using NUnit.Framework;
using RpsCore;
using RpsCore.Erros;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        static string[,] ArnaldoVsDaveGame;
        static List<string[,]> RpsTournament;
        static GameManager GameManager = new GameManager();

        [SetUp]
        public void Setup()
        {
            ArnaldoVsDaveGame = new[,] {
                {"Armando","P" },
                {"Dave","S" },
            };

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
        }

        [Test]
        public void WhenArnaldoPlayPaperAndDavePlayScissors_DaveShouldWins()
        {
            var winner = GameManager.GetWinner(ArnaldoVsDaveGame);
            Assert.That(winner.PlayerName == "Dave");
        }

        [Test]
        public void WhenAnInvalidStrategyIsChosen_NoSuchStrategtyErrorIsExpected()
        {
            Assert.Throws(typeof(NoSuchStrategyError),
                new TestDelegate(() =>
                {
                    var winner = GameManager.GetWinner(new[,] { { "Someone", "P" }, { "Another One", "X" } });
                }));
        }

        [Test]
        public void WhenTheSameMoveIsChosen_FirstPlayerShouldWin()
        {
            var winner = GameManager.GetWinner(new[,] { { "Someone", "P" }, { "Another One", "P" } });

            Assert.That(winner.PlayerName == "Someone");
        }

        [Test]
        public void WhenAnInvalidNumberOfPlayersIsProvided_WrongNumberOfPlayersErrorIsExpected()
        {
            Assert.Throws(typeof(WrongNumberOfPlayersError),
                new TestDelegate(() =>
                {
                    var winner = GameManager.GetWinner(new[,] { { "Someone", "P" }, { "Another One", "S" }, { "One More", "R" } });
                }));
        }

        [Test]
        public void RichardShouldWinTheTournament()
        {
            var winner = GameManager.GetWinner(RpsTournament);

            Assert.That(winner.PlayerName == "Richard");
        }
    }
}