using TG.UBP.Domain.SeedAction;
using TG.UBP.EF.Migrations;

namespace TG.UBP.EF.SqlServer
{
    public class SqlServerCreateDatabaseIfNotExistsWithSeed : CreateDatabaseIfNotExistsWithSeedBase<UbpDbContext>
    {
        public SqlServerCreateDatabaseIfNotExistsWithSeed()
        {
            SeedActions.Add(new CreateDatabaseSeedAction());
        }
    }
}
