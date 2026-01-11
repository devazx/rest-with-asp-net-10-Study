using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace restWithASPNET10Study.Configurations
{
    public static class EvolveConfig 
    {
        public static IServiceCollection AddEvolveConfiguration(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment environment)
        {

            if (environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentException("Connection string 'MSSQLServerSQLConnectionString' not found.");
                }

                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);
                    evolveConnection.Open();
                    var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };
                    evolve.Migrate();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Database connection error: " + ex.Message);
                }
                catch (EvolveException ex)
                {
                    throw new Exception("Evolve migration error: " + ex.Message);
                }
            }
            return services;
        } 
    }
}
