using Docker.Domain.Entities;
using System.Collections.Generic;

namespace Docker.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> List();
        void Store(Usuario usuario);
    }
}
