using System;
using System.Web;
using System.Web.Mvc;
using ScoreKeeper.Core;
using System.Collections.Generic;

namespace ScoreKeeper.Web.Controllers
{
    

    public class HomeController : Controller
    {

        [ControllerAction]
        public void SelectGame()
        {
            SessionData.SelectedGame = GameDao.FindByID(Int32.Parse(Request.Form["Game"]));
            this.RedirectToAction("AddPlayer", "PreGame");            
        }

        [ControllerAction]
        public void Index()
        {            
            RenderView("Index", new GameViewData(GameDao.GetAll()));
        }

        [ControllerAction]
        public void About()
        {
            RenderView("About");
        }
    }
}
