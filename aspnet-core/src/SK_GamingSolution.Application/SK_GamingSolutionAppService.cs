using System;
using System.Collections.Generic;
using System.Text;
using SK_GamingSolution.Localization;
using Volo.Abp.Application.Services;

namespace SK_GamingSolution;

/* Inherit your application services from this class.
 */
public abstract class SK_GamingSolutionAppService : ApplicationService
{
    protected SK_GamingSolutionAppService()
    {
        LocalizationResource = typeof(SK_GamingSolutionResource);
    }
}
