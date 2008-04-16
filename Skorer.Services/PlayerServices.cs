using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skorer.DataAccess;
using Skorer.Core;

namespace Skorer.Services
{
    public class PlayerServices : DataServiceBase<Player, int>
    {
        public PlayerServices(IRepository<Player, int> repository)
            : base(repository)
        {

        }

        // TODO: add LINQ to NHibernate
        public IList<Player> Find(string FirstName, string LastName)
        {
            return _Repository.GetAll();
        }
    }
}
