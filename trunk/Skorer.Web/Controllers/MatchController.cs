using Castle.MonoRail.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using System;

namespace Skorer.Web.Controllers
{
    [Layout("default")]
    public class MatchController : BaseController
    {
        IMatchRepository _MatchRepository;
        IRepository<Game, int> _GameRepository;
        IRepository<Player, int> _PlayerRepository;

        public MatchController(IMatchRepository matchRepository, 
            IRepository<Game, int> gameRepository,
            IRepository<Player, int> playerRepository
            )
        {
            _MatchRepository = matchRepository;
            _GameRepository = gameRepository;
            _PlayerRepository = playerRepository;
        }


        private void Start()
        {
            _MatchRepository.Save(_SessionMatch());            
        }

        private void _LoadGames()
        {
            PropertyBag["Games"] = _GameRepository.GetAll();
        }
        
        public void Create()
        {
            _LoadGames();  
        }
        public void Create(int gameID)
        {
            _LoadGames();
            Match match = new Match { Game = _GameRepository.GetById(gameID) };
            _MatchRepository.Save(match);
            Session["Match"] = match;
            RedirectToAction("AddPlayers");
        }

        public void AddPlayers()
        {
            if (Session["Match"] == null)
                throw new InvalidOperationException("There is no current Match");
        }

        private  Match _SessionMatch()
        {
            return ((Match)Session["Match"]);
        }

        public void AddPlayers(int playerID)
        {
            if (Session["Match"] == null)
                throw new InvalidOperationException("There is no current Match");

            Player playerToAdd = _PlayerRepository.GetById(playerID);

            _SessionMatch().Players.Add(playerToAdd);
                        
        }
    }
}