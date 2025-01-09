using Microsoft.EntityFrameworkCore;
using TangoRoom.Server.Interfaces;
using TangoRoom.Server.Models.Data;
using TangoRoom.Server.Services;

namespace TangoRoom.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string? connect = builder.Configuration.GetConnectionString("TangoRoomConnect");

            // Add services to the container.
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            //Enregistre la classe de contexte de donnée comme service en lui indiquant la connexion a utiliser
            builder.Services.AddDbContext<ContextTangoRoom>(opt => opt.UseSqlServer(connect));

            //injection services modeles
            builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
            builder.Services.AddScoped<IMarathonService, MarathonService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
