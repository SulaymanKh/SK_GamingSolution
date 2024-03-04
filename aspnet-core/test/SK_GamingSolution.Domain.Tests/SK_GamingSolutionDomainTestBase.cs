using Volo.Abp.Modularity;

namespace SK_GamingSolution;

/* Inherit from this class for your domain layer tests. */
public abstract class SK_GamingSolutionDomainTestBase<TStartupModule> : SK_GamingSolutionTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
