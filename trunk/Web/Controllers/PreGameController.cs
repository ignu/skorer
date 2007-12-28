using System;
using System.Web;
using System.Web.Mvc;
using ScoreKeeper.Core;

namespace ScoreKeeper.Web.Controllers
{
    public class PreGameController : Controller
    {

        [ControllerAction]
        public void PlayerSelection()
        {
            ViewData["Players"] = PlayerDao.GetAll();
        }

        [ControllerAction]
        public void AddPlayer()
        {

            if (!String.IsNullOrEmpty(Request.Form["Player"]))
            {
                SessionData.Players.Add(PlayerDao.FindByID(
                        Int32.Parse(Request.Form["Player"]))
                    );
            }
            ViewData["Players"] = PlayerDao.GetAll();
            ViewData["SelectedPlayers"] = SessionData.Players;
            RenderView("PlayerSelection");
        }
    }
}
