using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate;
using Skorer.Core;

namespace Skorer.DataAccess
{
        public interface ITransactional
        {
            void AbandonTransaction();
            void StartTransaction();
            void CommitTransaction();
        }

        public interface IFlushable
        {
            void Flush();
            void Clear();
        }
        public interface IRepository<T, IdT> : ITransactional, IFlushable
        {
            T CreateNew();
            T GetById(IdT id);
            IList<T> GetAll();
            T GetFirst();
            IList<T> GetByCriteria(params ICriterion[] criterion);
            T Save(T entity);
            T SaveOrUpdate(T entity);
            T SaveOrUpdateCopy(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Evict(T entity);
        }

        public class Repository<T, IdT> : IRepository<T, IdT> where T : Entity<IdT>
        {
            internal INHibernateSessionManager _NHibernateSessionManager;

            public Repository(INHibernateSessionManager nhibernateSessionManager)
            {
                this._NHibernateSessionManager = nhibernateSessionManager;
            }

            virtual public T CreateNew()
            {
                return (T)typeof(T).GetConstructor(System.Type.EmptyTypes).Invoke(null);
            }

            /// <summary>
            /// Loads an instance of type T from the DB based on its ID.
            /// </summary>
            virtual public T GetById(IdT id)
            {
                return (T)NHibernateSession.Load(typeof(T), id);
            }

            /// <summary>
            /// Loads every instance of the requested type with no filtering.
            /// </summary>
            virtual public IList<T> GetAll()
            {
                return GetByCriteria();
            }

            /// <summary>
            /// Loads the first instance of the requested type with no filtering
            /// (this is useful for testing)
            /// </summary>
            /// <returns></returns>
            virtual public T GetFirst()
            {
                IList<T> first = this._GetFirstN(1);

                if (first.Count == 1)
                {
                    return first[0];
                }

                return default(T);
            }

            virtual public IList<T> GetFirst(int n)
            {
                IList<T> first = this._GetFirstN(n);

                if (first.Count == n)
                {
                    return first;
                }

                return new List<T>();
            }

            protected IList<T> _GetFirstN(int n)
            {
                return NHibernateSession.CreateCriteria(typeof(T))
                   .SetFirstResult(0)
                   .SetMaxResults(n)
                   .List<T>() as List<T>;
            }

            /// <summary>
            /// Loads every instance of the requested type using the supplied <see cref="ICriterion" />.
            /// If no <see cref="ICriterion" /> is supplied, this behaves like <see cref="GetAll" />.
            /// </summary>
            virtual public IList<T> GetByCriteria(params ICriterion[] criterion)
            {
                ICriteria criteria = NHibernateSession.CreateCriteria(typeof(T));

                foreach (ICriterion criterium in criterion)
                {
                    criteria.Add(criterium);
                }

                return criteria.List<T>() as List<T>;
            }


            /// <summary>
            /// For entities that have assigned ID's, you must explicitly call Save to add a new one.
            /// See http://www.hibernate.org/hib_docs/reference/en/html/mapping.html#mapping-declaration-id-assigned.
            /// </summary>
            virtual public T Save(T entity)
            {

                NHibernateSession.Save(entity);
                return entity;
            }

            /// <summary>
            /// For entities with automatatically generated IDs, such as identity, SaveOrUpdate may 
            /// be called when saving a new entity.  SaveOrUpdate can also be called to _update_ any 
            /// entity, even if its ID is assigned.
            /// </summary>
            virtual public T SaveOrUpdate(T entity)
            {
                NHibernateSession.SaveOrUpdate(entity);
                return entity;
            }

            virtual public T SaveOrUpdateCopy(T entity)
            {
                NHibernateSession.SaveOrUpdateCopy(entity);
                return entity;
            }

            virtual public void Update(T entity)
            {
                NHibernateSession.Update(entity);
            }

            virtual public void Delete(T entity)
            {
                NHibernateSession.Delete(entity);
            }

            /// <summary>
            /// Commits changes regardless of whether there's an open transaction or not
            /// </summary>
            virtual public void Flush()
            {
                NHibernateSession.Flush();
            }

            /// <summary>
            /// Exposes the ISession used within the DAO.
            /// </summary>
            protected ISession NHibernateSession
            {
                get
                {
                    return this._NHibernateSessionManager.GetSession();
                }
            }

            public void Evict(T entity)
            {
                _NHibernateSessionManager.GetSession().Evict(entity);
            }

            protected int GetCount(string sql)
            {
                IQuery query = _NHibernateSessionManager.GetSession().CreateSQLQuery(sql).AddScalar("count", NHibernateUtil.Int32);
                return Int32.Parse(query.UniqueResult<Int32>().ToString());
            }

            public void StartTransaction()
            {
                _NHibernateSessionManager.BeginTransaction();
            }

            public void AbandonTransaction()
            {
                _NHibernateSessionManager.RollbackTransaction();
            }

            public void CommitTransaction()
            {
                _NHibernateSessionManager.CommitTransaction();
            }

            public void Clear()
            {
                _NHibernateSessionManager.GetSession().Clear();
            }
        }
    
}
