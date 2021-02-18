using Docker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docker.Infra.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");
            builder.HasKey(x => x.UsuarioId);

            builder.Property(x => x.Rua).HasColumnType("VARCHAR(128)").IsRequired();
            builder.Property(x => x.Numero).IsRequired();

            builder.HasOne(x => x.Usuario).WithOne(x => x.Endereco).HasForeignKey<Endereco>(x => x.UsuarioId);
        }
    }
}
