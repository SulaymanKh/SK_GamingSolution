using Volo.Abp.Modularity;

namespace SK_GamingSolution;

[DependsOn(
    typeof(SK_GamingSolutionApplicationModule),
    typeof(SK_GamingSolutionDomainTestModule)
)]
public class SK_GamingSolutionApplicationTestModule : AbpModule
{

}
