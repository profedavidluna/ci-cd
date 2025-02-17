
using MicroServiciosBccr.DA.AccesoDatos;
using MicroServiciosBccr.Services.Cuentas;
using Microsoft.EntityFrameworkCore;

namespace Cuentas
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
            builder.Services.AddSqlServer<BancoContext>("SERVER=docker_sqlserver;Initial Catalog=bccr;User Id=sa;Password=myPassword1!;Encrypt=False;Trust Server Certificate=True;");
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

            builder.Services.AddScoped<ICuentasService, CuentasService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

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
