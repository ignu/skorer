using System;
using System.Web;
using System.Web.Mvc;
using ScoreKeeper.Core;
using System.Collections.Generic;

namespace ScoreKeeper.Web.Controllers
{
    public class GameController : Controller
    {

        [ControllerAction]
        public void Start()
        {
            SessionData.Match = MatchDao.CreateFromGame(SessionData.SelectedGame);
            MatchDao.AddPlayers(SessionData.Players, SessionData.Match);            
            this.RedirectToAction("AddEvent");            
        }


        [ControllerAction]
        public void AddEvent()
        {

            if (Request.Form["SelectedGameEvent"] != null && Request.Form["SelectedPlayer"] != null)
            {
                Player player = SessionData.Players.Find(item => item.ID == Int32.Parse(Request.Form["SelectedPlayer"]));
                GameEvent gameEvent = SessionData.GameEvents.Find(item => item.ID == Int32.Parse(Request.Form["SelectedGameEvent"]));

                MatchEvent matchEvent = new MatchEvent()
                {
                    GameEventID = gameEvent.ID,
                    MatchID = SessionData.Match.ID,
                    PlayerID = player.ID,
                    Quantity = Int32.Parse(Request.Form["Quantity"]),
                    Score = gameEvent.Score * Int32.Parse(Request.Form["Quantity"])
                };

                MatchEventDao.Save(matchEvent);                
                
            }

            ViewData["PlayerScores"] = MatchEventDao.GetScores(SessionData.Match.ID);
            ViewData["GameEvents"] = SessionData.GameEvents;
            ViewData["Players"] = SessionData.Players;
            RenderView("AddEvent", ViewData);
        }
    }
}
