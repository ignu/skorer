using Castle.MonoRail.Framework;
using Skorer.DataAccess;
using Skorer.Core;

namespace Skorer.Web.Controllers
{
    [Layout("default")]
    public class PlayerController : BaseController
    {
        IRepository<Player, int> _PlayerRepository;

        public PlayerController(IRepository<Player, int> playerRepository)
        {
            _PlayerRepository = playerRepository;
        }

        public void Add()
        {

        }

        public void Edit(int playerID)
        {
            
        }

        public void Create([DataBind("Player")] Player player)
        {
            _PlayerRepository.Save(player);                        
            ConfirmationMessage = "Added Player: " + player.Name;
            RedirectToAction("Add");
        }

    }
}