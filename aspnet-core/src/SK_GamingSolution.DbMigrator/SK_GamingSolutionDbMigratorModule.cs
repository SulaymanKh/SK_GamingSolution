using SK_GamingSolution.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SK_GamingSolution.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SK_GamingSolutionEntityFrameworkCoreModule),
    typeof(SK_GamingSolutionApplicationContractsModule)
    )]
public class SK_GamingSolutionDbMigratorModule : AbpModule
{
}
