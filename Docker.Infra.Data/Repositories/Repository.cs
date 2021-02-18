using Docker.Domain.Interfaces.Repositories;
using Docker.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Docker.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private IDbContextTransaction Transaction = null;
        private readonly DockerContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(DockerContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual IEnumerable<T> List()
        {
            return DbSet.ToList();
        }

        public virtual void Store(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public T One(Expression<Func<T, bool>> exp)
        {
            return DbSet.FirstOrDefault(exp);
        }

        public T One(Expression<Func<T, bool>> exp, params string[] includes)
        {
            var query = DbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(exp);
        }

        public void BeginTransaction()
        {
            if (Transaction is null)
                Transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (Transaction is not null)
                {
                    Context.Database.CommitTransaction();
                    Transaction = null;
                }
            }
            catch
            {
                Rollback();
            }
        }

        public void Rollback()
        {
            if (Transaction is not null)
            {
                Context.Database.RollbackTransaction();
                Transaction = null;
            }
        }

        public IDbContextTransaction GetTransaction()
        {
            return Transaction;
        }
    }
}
