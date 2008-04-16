using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Skorer.Core;

namespace Skorer.DataAccess
{

    public interface IPlayerRepository : IRepository<Player, int>
    {
        IList<Player> Find(string lastName, string firstName);
    }
    public class PlayerRepository : Repository<Player, int>, IPlayerRepository
    {

        public PlayerRepository(INHibernateSessionManager sessionManager) : base(sessionManager)
        {
            
        }
        public IList<Player> Find(string firstName, string lastName)
        {
            ICriteria criteria = CreateCriteria();

            if (!String.IsNullOrEmpty(firstName))
                criteria.Add(new NHibernate.Criterion.LikeExpression("FirstName", firstName + "%"));

            if (!String.IsNullOrEmpty(lastName))
                criteria.Add(new NHibernate.Criterion.LikeExpression("LastName", lastName + "%"));

            return criteria.List<Player>();
        }
    }
}
