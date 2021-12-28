using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ProyectoNetCore.Models;
using System.Text;
using ProyectoNetCore.Tools;
using ProyectoNetCore.Services;

namespace ProyectoNetCore
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Los servicios trabajan con controladores
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ProyectoNetCore", Version = "v1" });
            }); // Configuración de proyecto con swagger

            services.Configure<JWTConfig>(Configuration.GetSection("JWTConfig"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        RequireAudience = true,
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JWTConfig:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWTConfig:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWTConfig:Secret"])),
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = System.TimeSpan.Zero // Para errores de zona horaria.
                    };
                });

            services.AddScoped<IOperationScope, Operation>();
            services.AddTransient<IOperationTransient, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddScoped<Operation2>();
            services.AddScoped<IPersonService, PersonService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoNetCore")); // Agregar la interfaz de usuario

            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapDefaultControllerRoute(); // Define un controlador por defecto
                endpoints.MapControllers();
            });
        }
    }
}
