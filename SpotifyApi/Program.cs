using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotifyApi.BL.Interfaces;
using SpotifyApi.BL.Services;
using SpotifyApi.Repository;

namespace SpotifyApi
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
            builder.Services.AddSwaggerGen(options => {
                options.CustomSchemaIds(type => type.ToString());
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder
                        .AllowAnyOrigin()//localhost:3000") // Replace with your React app's domain
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
            });

            builder.Services.AddScoped<ISpotifyAuthorizationRepository, SpotifyAuthorizationRepository>();
            builder.Services.AddScoped<ISpotifyAuthorizationService, SpotifyAuthorizationService>();
            builder.Services.AddScoped<ISpotifyDataRepository, SpotifyDataRepository>();
            builder.Services.AddScoped<ISpotifyDataService, SpotifyDataService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowReactApp");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
