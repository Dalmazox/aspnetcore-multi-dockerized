using Docker.Domain.Entities;
using Docker.Domain.Interfaces.Repositories;
using Docker.Infra.Data.Context;

namespace Docker.Infra.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DockerContext context) : base(context)
        {
        }
    }
}
