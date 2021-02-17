using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Docker.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        void Store(T entity);
        T One(Expression<Func<T, bool>> exp);
    }
}
