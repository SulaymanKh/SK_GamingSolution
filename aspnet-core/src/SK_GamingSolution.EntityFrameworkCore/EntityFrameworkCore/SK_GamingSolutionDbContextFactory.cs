using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SK_GamingSolution.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SK_GamingSolutionDbContextFactory : IDesignTimeDbContextFactory<SK_GamingSolutionDbContext>
{
    public SK_GamingSolutionDbContext CreateDbContext(string[] args)
    {
        SK_GamingSolutionEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SK_GamingSolutionDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SK_GamingSolutionDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SK_GamingSolution.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
