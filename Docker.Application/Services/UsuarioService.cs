using Docker.Domain.Entities;
using Docker.Domain.Interfaces.Services;
using Docker.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;

namespace Docker.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;

        public UsuarioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Usuario> List()
        {
            return _uow.Usuarios.List();
        }

        public void Store(Usuario model)
        {
            var usuario = _uow.Usuarios.One(u => u.Email == model.Email);

            if (usuario is not null)
                throw new Exception("E-mail já em uso");

            _uow.BeginTransaction();
            _uow.Usuarios.Store(model);
            _uow.Commit();
        }
    }
}
