using System;
using NUnit.Framework;
using BussineTateti.Models;

namespace TatetiApiTest
{
    class RulesTestus
    {

        

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ValidateTatetiPlayWinner()
        {
            var models = new Rules();
            string winner = "";
            
            // no se puede repetir el jugador
            // sacar el player 
            // enum 
            // realizar 1 caso camino feliz, y despues por los 5 validaciones

            winner = models.PlayGame(1, 1);

            if (winner != "")
                winner =  models.PlayGame(2, 2);

            if (winner != "")
                winner =  models.PlayGame(3, 1);

            if (winner != "")
                winner = models.PlayGame(3, 1);

            if (winner != "")
                winner = models.PlayGame(1, 2);

            if (winner != "")
                winner = models.PlayGame(1, 2);

            Assert.IsTrue(winner == "");
        }
    }
}
