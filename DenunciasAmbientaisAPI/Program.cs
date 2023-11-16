
using DenunciasAmbientaisAPI.Data;
using DenunciasAmbientaisAPI.Repositorios;
using DenunciasAmbientaisAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DenunciasAmbientaisAPI
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

            //faz a conexão com o sql server baseando-se na connection string "DataBase" (que está em appsettings.json)
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaDenunciasDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IDenunciasRepositorio, DenunciaRepositorio>();

            //Adiciona os Cors para permitir acesso de qualquer origem
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowedOrigins",
                    policy =>
                    {
                        policy.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            //Usa os Cors definidos anteriormente para qualquer origem
            app.UseCors("MyAllowedOrigins");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}