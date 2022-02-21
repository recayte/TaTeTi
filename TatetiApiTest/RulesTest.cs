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
            Status status;

            status = models.PlayGame(1, 1);
            if (status == Status.statusOk)
                status = models.PlayGame(2, 2);
            if (status == Status.statusOk)
                status = models.PlayGame(0, 1);
            if (status == Status.statusOk)
                status = models.PlayGame(0, 2);
            if (status == Status.statusOk)
                status = models.PlayGame(2, 1);
            if (status == Status.statusOk)
                status = models.PlayGame(0, 3);

            Assert.IsTrue(status == Status.winner);
        }

        [Test]
        public void ValidateMovementNotAvailable()
        {
            var models = new Rules();
            Status status;

            status = models.PlayGame(1, 1);
            if (status == Status.statusOk)
                status = models.PlayGame(1, 1);

            Assert.IsTrue(status == Status.wrongPosition);
        }

        [Test]
        public void ValidateFullMatriz()
        {
            var models = new Rules();
            Status status;

            status = models.PlayGame(0, 0);
            status = models.PlayGame(0, 1);
            status = models.PlayGame(0, 2);

            status = models.PlayGame(1, 0);
            status = models.PlayGame(1, 1);
            status = models.PlayGame(2, 0);

            status = models.PlayGame(1, 2);
            status = models.PlayGame(2, 2);
            status = models.PlayGame(2, 1);

            status = models.PlayGame(2, 1);

            Assert.IsTrue(status == Status.fullMatrix);
        }

        [Test]
        public void ValidateIndexOutOfRangeException()
        {
            var models = new Rules();
            Status status;

            status = models.PlayGame(3, 1);

            Assert.IsTrue(status == Status.IndexOutOfRangeException);
        }

        [Test]
        public void RandomPlay()
        {
            var models = new Rules();
            Status status;
            Random FilaRnd = new Random();
            Random ColRnd = new Random();
            do
            {
               status = models.PlayGame(FilaRnd.Next(0,4), ColRnd.Next(0,4));
                if (status == Status.IndexOutOfRangeException || status == Status.wrongPosition)
                    status = Status.statusOk;

            } while (status == Status.statusOk);

            Assert.IsTrue(status == Status.winner || status == Status.fullMatrix);
        }


    }
}
