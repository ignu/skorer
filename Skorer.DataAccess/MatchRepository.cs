using System;
using Skorer.Core;

namespace Skorer.DataAccess
{
    public interface IMatchRepository : IRepository<Match, int>
    {
    }

    public class MatchRepository : Repository<Match, int>, IMatchRepository
    {
        public MatchRepository(INHibernateSessionManager sessionManager) : base(sessionManager) { }
    }
}
