
using System;
using System.Web;
using System.Web.Mvc;
using ScoreKeeper.Core;
using System.Collections.Generic;

namespace ScoreKeeper.Web
{

    public class GameViewData
    {
        public GameViewData(IEnumerable<Game> games)
        {
            Games = new List<Game>(games);
        }

        public List<Game> Games { get; set; }
    }

    
}