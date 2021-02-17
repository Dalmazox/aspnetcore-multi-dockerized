using Docker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Docker.Infra.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email).HasColumnType("VARCHAR(128)").IsRequired();
            builder.Property(x => x.Nascimento).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
