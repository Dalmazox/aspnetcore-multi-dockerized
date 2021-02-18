using Docker.Domain.Interfaces.Repositories;

namespace Docker.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        IUsuarioRepository Usuarios { get; }
        IEnderecoRepository Enderecos { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
