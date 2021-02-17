using Docker.Domain.Interfaces.Repositories;
using Docker.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Docker.Application.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _repository.List();
        }

        public virtual void Store(TEntity entity)
        {
            _repository.Store(entity);
        }
    }
}
