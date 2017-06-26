using System;
using System.Data.Entity;
using Abp.EntityFramework;
using TG.UBP.EF;
using TG.UBP.EF.OracleDevart;
using EntityFramework.DynamicFilters;
using Abp.Domain.Uow;
using TG.UBP.Core.Config;
using Abp;
using Castle.Facilities.Logging;
using Abp.Dependency;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;
using TG.UBP.Application.Service.BaseManage.Permission.Modules;

namespace TestConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Devart.Data.Oracle.OracleMonitor monitor = new Devart.Data.Oracle.OracleMonitor() { IsActive = true };
            Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig devartConfig = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
            devartConfig.Workarounds.IgnoreSchemaName = true;
            devartConfig.Workarounds.DisableQuoting = true;
            devartConfig.CodeFirstOptions.UseDateTimeAsDate = true;
            devartConfig.CodeFirstOptions.UseNonLobStrings = true;
            devartConfig.CodeFirstOptions.UseNonUnicodeStrings = true;
            devartConfig.CodeFirstOptions.TruncateLongDefaultNames = true;

            using (var bootstrapper = AbpBootstrapper.Create<TestConsoleAppModule>())
            {
                bootstrapper.IocManager
                    .IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));

                bootstrapper.Initialize();

                //Getting a Tester object from DI and running it
                using (var tester = bootstrapper.IocManager.ResolveAsDisposable<Tester>())
                {
                    tester.Object.TestEntitiyMapToDto();
                } //Disposes tester and all it's dependencies

                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }

            #region 手工创建DbContext
            ////UbpConfig config = UbpConfig.Instance;
            ////IDatabaseInitializer databaseInitializer = new DatabaseInitializer();
            ////databaseInitializer.Initialize(config.DbContextInitializerConfig);

            //Database.SetInitializer<UbpDbContext>(null);
            ////Database.SetInitializer(new OracleDevartCreateDatabaseIfNotExistsWithSeed());
            ////Database.SetInitializer(new MigrateDatabaseToLatestVersion<UbpDbContext, OracleDevartMigrationsConfiguration>());

            UbpDbContext dbContext = new UbpDbContext("default");
            ////if (!dbContext.Database.Exists())
            ////{
            ////    Database.SetInitializer(new OracleDevartCreateDatabaseIfNotExistsWithSeed());
            ////}
            ////else
            ////{
            ////    Database.SetInitializer(new MigrateDatabaseToLatestVersion<UbpDbContext, OracleDevartMigrationsConfiguration>());
            ////}

            Add(dbContext);
            //dbContext.DisableFilter(AbpDataFilters.SoftDelete);
            //Query(dbContext);

            //Console.WriteLine("Press enter to exit...");
            //Console.ReadLine();
            #endregion
        }

        private static void Add(UbpDbContext context)
        {
            //var m = context.Modules.Add(new TG.UBP.Domain.Entity.Module() { EnCode = "test21", FullName = "test21" });
            //context.Modules.Add(new TG.UBP.Domain.Entity.Module() { EnCode = "test2", FullName = "test2" });
            //context.Modules.Add(new TG.UBP.Domain.Entity.Module() { EnCode = "test3", FullName = "test3" });

            //context.Users.Add(new TG.UBP.Domain.Entity.User() { EnCode = "test1", FullName = "test1" });
            //context.Users.Add(new TG.UBP.Domain.Entity.User() { EnCode = "test2", FullName = "test2" });

            //context.SaveChanges();
        }

        private static void Query(UbpDbContext context)
        {
            //var datas = context.Modules;

            //Console.WriteLine("数据有：");
            //foreach (var data in datas)
            //{
            //    Console.WriteLine("{0}", data.FullName);
            //}
        }
    }
}
