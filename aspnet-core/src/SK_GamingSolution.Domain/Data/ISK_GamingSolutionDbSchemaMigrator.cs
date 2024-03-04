using System.Threading.Tasks;

namespace SK_GamingSolution.Data;

public interface ISK_GamingSolutionDbSchemaMigrator
{
    Task MigrateAsync();
}
