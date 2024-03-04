using Volo.Abp.Modularity;

namespace SK_GamingSolution;

[DependsOn(
    typeof(SK_GamingSolutionDomainModule),
    typeof(SK_GamingSolutionTestBaseModule)
)]
public class SK_GamingSolutionDomainTestModule : AbpModule
{

}
