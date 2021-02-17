using Docker.Domain.Interfaces.Repositories;
using Docker.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Docker.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
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
    }
}
