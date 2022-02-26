namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Repositories.Abstraction;
    using Domain;
    using NHibernate;

    public class SubscriberRepository : IRepository<Subscriber>
    {
        public bool Create<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Subscriber> Filter(ISession session, System.Linq.Expressions.Expression<Func<Subscriber, bool>> predicate)
        {
            return this.GetAll(session)
                .Where(predicate);
        }

        public Subscriber Find(ISession session, System.Linq.Expressions.Expression<Func<Subscriber, bool>> predicate)
        {
            return this.GetAll(session)
                .FirstOrDefault(predicate);
        }

        public Subscriber Get(ISession session, int id) =>
                  session?.Get<Subscriber>(id);

        public IQueryable<Subscriber> GetAll(ISession session) =>
                  session?.Query<Subscriber>();

        public bool Update<TEntity>(TEntity oldEntity, TEntity newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
