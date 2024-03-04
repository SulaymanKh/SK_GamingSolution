using SK_GamingSolution.Samples;
using Xunit;

namespace SK_GamingSolution.EntityFrameworkCore.Applications;

[Collection(SK_GamingSolutionTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SK_GamingSolutionEntityFrameworkCoreTestModule>
{

}
