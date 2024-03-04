using SK_GamingSolution.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SK_GamingSolution.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SK_GamingSolutionController : AbpControllerBase
{
    protected SK_GamingSolutionController()
    {
        LocalizationResource = typeof(SK_GamingSolutionResource);
    }
}
