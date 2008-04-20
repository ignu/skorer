using System;
using Skorer.Core;

namespace Skorer.DataAccess
{
    public interface IMatchEventRepository : IRepository< MatchEvent, int>
    {
    }

    public class MatchEventRepository : Repository<MatchEvent, int>, IMatchEventRepository
    {
        public MatchEventRepository(INHibernateSessionManager sessionManager) : base(sessionManager) { }
    }    
}