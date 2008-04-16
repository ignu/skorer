using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skorer.DataAccess;

namespace Skorer.Services
{
    public abstract class DataServiceBase<T, IdT>
    {
        protected IRepository<T, IdT> _Repository;

        public DataServiceBase(IRepository<T, IdT> repository)
        {
            _Repository = repository;
        }

        public T GetByID(IdT id)
        {
            return _Repository.GetById(id);
        }
    }
}
