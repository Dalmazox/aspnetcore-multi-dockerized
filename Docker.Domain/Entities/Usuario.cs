using System;

namespace Docker.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
