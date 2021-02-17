using Docker.Domain.Entities;
using Docker.Domain.Interfaces.Repositories;
using Docker.Infra.Data.Context;

namespace Docker.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DockerContext context) : base(context)
        {
        }
    }
}
