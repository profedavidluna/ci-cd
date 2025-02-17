
using MicroServiciosBccr.DA.AccesoDatos;
using MicroServiciosBccr.Services.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Clientes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSqlServer<BancoContext>("Data Source=\"localhost, 1433\";Initial Catalog=bccr;User ID=sa;Password=Nuevo123*;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            builder.Services.AddSqlServer<BancoContext>("SERVER=docker_sqlserver,1433;Initial Catalog=bccr;User Id=sa;Password=myPassword1!;Encrypt=False;Trust Server Certificate=True;");
            builder.Services.AddAuthorization();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader();
                    //policy.WithOrigins("https://localhost:5000");
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                });
            });

            builder.Services.AddScoped<IClientesService, ClientesService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
           // if (app.Environment.IsDevelopment())
           // {
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var contexto = services.GetRequiredService<BancoContext>();
                contexto.Database.Migrate();
            }

            app.Run();
        }
    }
}
