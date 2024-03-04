using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SK_GamingSolution;

[Dependency(ReplaceServices = true)]
public class SK_GamingSolutionBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SK_GamingSolution";
}
