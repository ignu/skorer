using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skorer.Core;
using NHibernate;
using NHibernate.Criterion;

namespace Skorer.DataAccess
{
    public interface IGameEventRepository : IRepository<GameEvent, int>
    {
        GameEvent GetByNameAndGame(string name, Game game);
    }

    public class GameEventRepository : Repository<GameEvent, int>, IGameEventRepository
    {

        public GameEventRepository(INHibernateSessionManager sessionManager) : base(sessionManager) { }

        public GameEvent GetByNameAndGame(string name, Game game)
        {
            ICriteria criteria = base.CreateCriteria();
            criteria.Add(Expression.Eq("Name", name));
            criteria.Add(Expression.Eq("Game", game));
            return criteria.UniqueResult<GameEvent>();
        }
    }
}
