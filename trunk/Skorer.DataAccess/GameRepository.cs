using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skorer.Core;
using NHibernate;
using NHibernate.Criterion;

namespace Skorer.DataAccess
{
    public interface IGameRepository : IRepository<Game, int>
    {
        Game GetByName(string name);
    }

    
    public class GameRepository : Repository<Game, int>, IGameRepository
    {

        public GameRepository(INHibernateSessionManager sessionManager) : base(sessionManager) { }

        public Game GetByName(string name)
        {
            ICriteria criteria = base.CreateCriteria();
            criteria.Add(Expression.Eq("Name", name));
            return criteria.UniqueResult<Game>();
        }

    }
}
