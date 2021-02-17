using Docker.Infra.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace Docker.Infra.Data.Context
{
    public class DockerContext : DbContext
    {
        public DockerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioMap).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
