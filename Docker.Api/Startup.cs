using Docker.Api.Validators;
using Docker.Application.Services;
using Docker.Domain.Interfaces.Repositories;
using Docker.Domain.Interfaces.Services;
using Docker.Domain.Interfaces.UoW;
using Docker.Infra.Data.Context;
using Docker.Infra.Data.Repositories;
using Docker.Infra.Data.UoW;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Docker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddControllers()
                .AddFluentValidation(options =>
                {
                    options.AutomaticValidationEnabled = false;
                    options.ValidatorOptions.CascadeMode = CascadeMode.Stop;
                    options.RegisterValidatorsFromAssembly(typeof(UsuarioValidator).Assembly);
                });

            services
                .AddDbContext<DockerContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Default")))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DockerContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.EnsureCreated();
        }
    }
}
