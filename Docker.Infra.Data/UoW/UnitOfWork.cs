using Docker.Domain.Interfaces.Repositories;
using Docker.Domain.Interfaces.UoW;
using Docker.Infra.Data.Context;
using Docker.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Docker.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DockerContext _context;
        private IDbContextTransaction _transaction = null;
        private readonly IUsuarioRepository _usuarios;
        private readonly IEnderecoRepository _enderecos;

        public UnitOfWork(DockerContext context)
        {
            _context = context;
        }

        public IUsuarioRepository Usuarios => _usuarios ?? new UsuarioRepository(_context);
        public IEnderecoRepository Enderecos => _enderecos ?? new EnderecoRepository(_context);

        public void BeginTransaction()
        {
            if (_transaction is null)
                _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            if (_transaction is not null)
            {
                _transaction.Commit();
                _transaction = null;
            }
        }

        public void Commit()
        {
            try
            {
                if (_transaction is not null)
                {
                    _transaction.Commit();
                    _transaction = null;
                }
            }
            catch
            {
                Rollback();
            }
        }
    }
}
