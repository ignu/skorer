using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using ScoreKeeper.Core;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestGetScores()
        {
            Assert.Greater(MatchEventDao.GetScores(11).Count,0);
        }

        [Test]
        public void Test()
        {
           ScoreKeeperDataContext db = new ScoreKeeperDataContext();            
           Game game = new Game(){Name = "Soccer", Title="Match"};
           
            GameEvent gameEvent = new GameEvent(){ 
               Game = game, 
               Name="Goal", 
               Score = 1, 
               ScoreInterval = 1, 
               ScoreMax = 1};

           db.Games.InsertOnSubmit(game);
           db.SubmitChanges();                                  
        }

        public void CreateCarcassonne()
        {
            ScoreKeeperDataContext db = new ScoreKeeperDataContext();

            Game carcasonne = new Game() { Name = "Carcassonne", Title = "Game" };

           new GameEvent()
            {
                Game = carcasonne,
                Name = "City",
                Score = 1,
                ScoreInterval = 1,
                ScoreMax = 200
            };

            new GameEvent()
            {
                Game = carcasonne,
                Name = "Road",
                Score = 1,
                ScoreInterval = 1,
                ScoreMax = 90
            };


            new GameEvent()
            {
                Game = carcasonne,
                Name = "Farmed City",
                Score = 4,
                ScoreInterval = 4,
                ScoreMax = 100
            };

            new GameEvent()
            {
                Game = carcasonne,
                Name = "Pig Farmed City",
                Score = 5,
                ScoreInterval = 5,
                ScoreMax = 100
            };

            new GameEvent()
            {
                Game = carcasonne,
                Name = "Resource Owner",
                Score = 10,
                ScoreInterval = 10,
                ScoreMax = 30
            };

            new GameEvent()
            {
                Game = carcasonne,
                Name = "King",
                Score = 1,
                ScoreInterval = 1,
                ScoreMax = 200
            };

            new GameEvent()
            {
                Game = carcasonne,
                Name = "Baron",
                Score = 1,
                ScoreInterval = 1,
                ScoreMax = 200
            };

            db.Games.InsertOnSubmit(carcasonne);
            db.SubmitChanges();   
        }

        [Test]
        public void ChangeName()
        {
            ScoreKeeperDataContext db = new ScoreKeeperDataContext();
            Game gameToSave = GameDao.FindByName("Soccer");
            gameToSave.Name = "Baseball";
            GameDao.Save(gameToSave);
                
        }


        [Test]
        public void AddPlayers()
        {
            ScoreKeeperDataContext db = new ScoreKeeperDataContext();

            //Game carcasonne = GameDao.FindByName("Carcasonne");

           db.Players.InsertOnSubmit(new Player()
               {
               FirstName = "Len",
               LastName = "Smith",
               NickName = "Ignu"
               });

           db.Players.InsertOnSubmit(new Player()
           {
               FirstName = "Jacob",
               LastName = "Johnson",
               NickName = "Jake"
           });

           db.Players.InsertOnSubmit(new Player()
               {
                   FirstName = "Matt",
                   LastName = "Flores",
                   NickName = "Flores"
               });
            
            db.SubmitChanges();
        }
    }
}
