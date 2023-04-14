using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        [Test]
        public void CreateFootballTeam_ValidParameters()
        {
            FootballTeam team = new FootballTeam("Real Madrid", 21);


            Assert.IsNotNull(team);
            Assert.That(team.Name, Is.EqualTo("Real Madrid"));
            Assert.That(team.Capacity, Is.EqualTo(21));


            Type t = team.Players.GetType();
            Type expectedType = typeof(List<FootballPlayer>);

            Assert.That(expectedType, Is.EqualTo(t));
        }

        [Test]
        public void Name_SetToNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(null, 15));
        }

        [Test]
        public void Name_SetToEmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam(string.Empty, 15));
        }

        [Test]
        public void Capacity_SetToLessThan15_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Team", 10));
        }

        [Test]
        public void AddNewPlayer_AddsPlayerToTeam()
        {
            var team = new FootballTeam("Team", 15);
            var player = new FootballPlayer("Player1", 1, "Midfielder");

            var result = team.AddNewPlayer(player);

            Assert.That(team.Players.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}"));
        }

        [Test]
        public void AddNewPlayer_TeamIsFull_ReturnsNoMorePositionsAvailable()
        {
            var team = new FootballTeam("Team", 15);
            var player1 = new FootballPlayer("Player1", 1, "Midfielder");
            var player2 = new FootballPlayer("Player2", 2, "Midfielder");
            var player3 = new FootballPlayer("Player3", 2, "Midfielder");
            var player4 = new FootballPlayer("Player4", 2, "Midfielder");
            var player5 = new FootballPlayer("Player5", 2, "Midfielder");
            var player6 = new FootballPlayer("Player6", 2, "Midfielder");
            var player7 = new FootballPlayer("Player7", 2, "Midfielder");
            var player8 = new FootballPlayer("Player8", 2, "Midfielder");
            var player9 = new FootballPlayer("Player9", 2, "Midfielder");
            var player10 = new FootballPlayer("Player10", 2, "Midfielder");
            var player11 = new FootballPlayer("Player2", 2, "Midfielder");
            var player12 = new FootballPlayer("Player2", 2, "Midfielder");
            var player13 = new FootballPlayer("Player2", 2, "Midfielder");
            var player14 = new FootballPlayer("Player2", 2, "Midfielder");
            var player15 = new FootballPlayer("Player2", 2, "Midfielder");
            var player16 = new FootballPlayer("Player2", 2, "Midfielder");
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);

            var result = team.AddNewPlayer(player16);

            Assert.That(team.Players.Count, Is.EqualTo(15));
            Assert.That(result, Is.EqualTo("No more positions available!"));
        }

        [Test]
        public void PickPlayer_ReturnsPlayerWithMatchingName()
        {
            var team = new FootballTeam("Team", 15);
            var player1 = new FootballPlayer("Player1", 1, "Midfielder");
            var player2 = new FootballPlayer("Player2", 2, "Midfielder");
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);

            var result = team.PickPlayer("Player1");

            Assert.That(result, Is.EqualTo(player1));
        }

        [Test]
        public void PlayerScore_IncrementsScoredGoalsAndReturnsCorrectString()
        {
            var team = new FootballTeam("Team", 15);
            var player = new FootballPlayer("Player1", 1, "Midfielder");
            team.AddNewPlayer(player);

            var result = team.PlayerScore(1);

            Assert.That(player.ScoredGoals, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"{player.Name} scored and now has {player.ScoredGoals} for this season!"));
        }

        [Test]
        public void PlayerScore_PlayerNumberNotFound_ThrowsNullReferenceException()
        {
            var team = new FootballTeam("Team", 15);

            Assert.Throws<NullReferenceException>(() => team.PlayerScore(1));
        }
    }
}



