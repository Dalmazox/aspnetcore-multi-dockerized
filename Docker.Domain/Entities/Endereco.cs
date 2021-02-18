using System;

namespace Docker.Domain.Entities
{
    public class Endereco
    {
        public Guid UsuarioId { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
