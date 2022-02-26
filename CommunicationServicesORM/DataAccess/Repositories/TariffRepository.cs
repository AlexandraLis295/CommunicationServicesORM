namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using DataAccess.Repositories.Abstraction;
    using Domain;
    using NHibernate;

    public class TariffRepository : IRepository<Tariff>
    {
        public Tariff Get(ISession session, int id) =>
            session?.Get<Tariff>(id);

        public Tariff Find(ISession session, Expression<Func<Tariff, bool>> predicate)
        {
            return this.GetAll(session).FirstOrDefault(predicate);
        }

        public IQueryable<Tariff> GetAll(ISession session) =>
            session?.Query<Tariff>();

        public IQueryable<Tariff> Filter(ISession session, Expression<Func<Tariff, bool>> predicate)
        {
            return this.GetAll(session).Where(predicate);
        }

        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
