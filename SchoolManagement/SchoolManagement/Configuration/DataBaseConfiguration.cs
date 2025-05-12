using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess;

namespace SchoolManagement.Server.Configuration;

public static class DataBaseConfiguration
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<MainContext>(o =>
          o.UseSqlServer(connectionString));
    }

}
