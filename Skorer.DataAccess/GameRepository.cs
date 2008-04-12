using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skorer.Core;

namespace Skorer.DataAccess
{
    public interface IGameRepository : IRepository<Game, int>
    {
    }

    public class GameRepository : RepositoryBase<Game, int>, IGameRepository
    {

        public GameRepository(INHibernateSessionManager sessionManager) : base(sessionManager) { }
    }
}
