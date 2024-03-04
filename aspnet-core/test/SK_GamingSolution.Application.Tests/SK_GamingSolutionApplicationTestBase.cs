using Volo.Abp.Modularity;

namespace SK_GamingSolution;

public abstract class SK_GamingSolutionApplicationTestBase<TStartupModule> : SK_GamingSolutionTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
