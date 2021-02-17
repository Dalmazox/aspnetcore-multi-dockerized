using Docker.Domain.Entities;
using Docker.Domain.Interfaces.Repositories;
using Docker.Domain.Interfaces.Services;
using System;

namespace Docker.Application.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository) { }

        public override void Store(Usuario entity)
        {
            var usuario = _repository.One(u => u.Email == entity.Email);

            if (usuario is not null)
                throw new Exception("E-mail já cadastrado");

            base.Store(entity);
        }
    }
}
