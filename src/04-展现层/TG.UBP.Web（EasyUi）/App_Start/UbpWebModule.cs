using Abp.Modules;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TG.UBP.Web.Controllers;

namespace TG.UBP.Web
{
    //[DependsOn(
    //    typeof(AbpWebMvcModule),
    //    typeof(UbpEFModule), 
    //    typeof(UbpApplicationServiceModule),
    //    typeof(AbpWebSignalRModule),
    //    typeof(UBPWebApiModule))]
    [DependsOn(typeof(UbpWebControllerModule))]
    public class UbpWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            //Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<UbpNavigationProvider>();

            //Configure Hangfire - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            //});
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
