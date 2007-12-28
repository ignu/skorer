using System;
using System.Web;
using System.Web.Mvc;
using ScoreKeeper.Core;
using System.Collections.Generic;
namespace ScoreKeeper.Web
{

    public static class SessionData
    {

        public static List<GameEvent> GameEvents
        {
            get
            {
                if (HttpContext.Current.Session["GameEvents"] == null)
                    HttpContext.Current.Session["GameEvents"] = new List<GameEvent>(GameEventDao.GetAllByGame(SelectedGame));

                return (List<GameEvent>)HttpContext.Current.Session["GameEvents"];
            }

        }

        public static Game SelectedGame
        {
            get
            {
                if (HttpContext.Current.Session["SelectedGame"] == null)
                    return null;

                return (Game)HttpContext.Current.Session["SelectedGame"];
            }

            set
            {
                HttpContext.Current.Session["SelectedGame"] = value;
            }
        }

        public static List<Player> Players
        {
            get
            {
                if (HttpContext.Current.Session["Players"] == null)
                    HttpContext.Current.Session["Players"]  =  new List<Player>();

                return HttpContext.Current.Session["Players"] as List<Player>;
            }
            set
            {
                HttpContext.Current.Session["Players"] = value;
            }
        }

        public static Match Match
        {
            get
            {
                if (HttpContext.Current.Session["Match"] == null)
                    HttpContext.Current.Session["Match"] = new Match();

                return HttpContext.Current.Session["Match"] as Match;
            }
            set
            {
                HttpContext.Current.Session["Match"] = value;
            }
        }
    }
}