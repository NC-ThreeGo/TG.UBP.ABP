using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG.UBP.EF.Migrations;
using TG.UBP.Domain.SeedAction;

namespace TG.UBP.EF.OracleDevart
{
    public class OracleDevartCreateDatabaseIfNotExistsWithSeed : CreateDatabaseIfNotExistsWithSeedBase<UbpDbContext>
    {
        public OracleDevartCreateDatabaseIfNotExistsWithSeed()
        {
            SeedActions.Add(new CreateDatabaseSeedAction());
        }
    }
}
