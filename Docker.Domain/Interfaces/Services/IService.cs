using System.Collections.Generic;

namespace Docker.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> List();
        void Store(TEntity entity);
    }
}
