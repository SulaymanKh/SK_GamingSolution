using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SK_GamingSolution.Data;
using Volo.Abp.DependencyInjection;

namespace SK_GamingSolution.EntityFrameworkCore;

public class EntityFrameworkCoreSK_GamingSolutionDbSchemaMigrator
    : ISK_GamingSolutionDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSK_GamingSolutionDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SK_GamingSolutionDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SK_GamingSolutionDbContext>()
            .Database
            .MigrateAsync();
    }
}
