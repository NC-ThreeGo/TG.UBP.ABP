using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using System.Reflection;
using TG.UBP.Application.Service;
using TG.UBP.EF;
using TG.UBP.WebApi;

namespace TG.UBP.Web.Controllers
{
    [DependsOn(
       typeof(AbpWebMvcModule),
       typeof(UbpEFModule),
       typeof(UbpApplicationServiceModule),
       typeof(AbpWebSignalRModule),
       typeof(UbpWebApiModule))]
    public class UbpWebControllerModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
