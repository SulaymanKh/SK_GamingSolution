using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SK_GamingSolution.Data;

/* This is used if database provider does't define
 * ISK_GamingSolutionDbSchemaMigrator implementation.
 */
public class NullSK_GamingSolutionDbSchemaMigrator : ISK_GamingSolutionDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
