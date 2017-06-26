using Abp.Modules;
using System.Reflection;

namespace TG.UBP.Domain.Entity
{
    //[DependsOn(typeof(AbpZeroCoreModule))]
    public class UbpDomainEntityModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
