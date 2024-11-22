
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Project_API_ontwikkeling_LarsLauryssens.Data;
using Project_API_ontwikkeling_LarsLauryssens.Services;
using System.Globalization;


namespace Project_API_ontwikkeling_LarsLauryssens
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", "false");
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            var builder = WebApplication.CreateBuilder(args);
            


            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Set the default culture to InvariantCulture to avoid culture-related issues
           




            //kijken welke db er actief staat in de appsettings
            var activeDatabase = builder.Configuration.GetValue<string>("ActiveDatabase");

            // Configureer dan de dbcontext gebaseerd op deze waarde, ik gebruik mysql or inmemory
            if (activeDatabase == "MySql")
            {
                // de MySql connection string ophalen
                var mySqlConnectionString = builder.Configuration.GetSection("Databases:MySql:ConnectionStrings:MySqlConnection").Value;

                // Configureer MySQL database
                //builder.Services.AddDbContext<ProjectDbContext>(options =>
                //    options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));
            }
            else if (activeDatabase == "SQLserver")
            {
                //terug connectie ophalen
                var sqlConnectionString = builder.Configuration.GetSection("Databases:SQLserver:ConnectionStrings:SqlServerConnection").Value;

                //en dan terug configureren
                builder.Services.AddDbContext<ProjectDbContext>(options =>
                    options.UseSqlServer(sqlConnectionString));

            }
            //als ik gene actieve db meegeef dan wordt het automatisch inmemory
            else
            {
               
                // Configureer de In-Memory database
                builder.Services.AddDbContext<ProjectDbContext>(options =>
                    options.UseInMemoryDatabase("InMemory"));
            }

            //services toevoegen, eventueel op volgorde 
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IIndustryService, IndustryService>();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //ervoor zorgen dat de database zeker gecreerd word in de huidige scope. anders blijft deze leeg
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();
                dbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
