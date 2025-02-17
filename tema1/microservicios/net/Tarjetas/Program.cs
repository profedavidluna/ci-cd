

using MicroServiciosBccr.DA.AccesoDatos;
using MicroServiciosBccr.Services.Tarjetas;

namespace Tarjetas
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
            builder.Services.AddSqlServer<BancoContext>("SERVER=docker_sqlserver,1433;Initial Catalog=bccr;User Id=sa;Password=myPassword1!;Encrypt=False;Trust Server Certificate=True;");
            builder.Services.AddAuthorization();

            builder.Services.AddScoped<ITarjetasService, TarjetasService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
