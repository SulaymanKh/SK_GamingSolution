using SK_GamingSolution.Samples;
using Xunit;

namespace SK_GamingSolution.EntityFrameworkCore.Domains;

[Collection(SK_GamingSolutionTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SK_GamingSolutionEntityFrameworkCoreTestModule>
{

}
