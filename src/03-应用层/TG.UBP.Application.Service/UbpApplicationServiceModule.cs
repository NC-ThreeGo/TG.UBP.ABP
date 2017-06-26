using System.Reflection;
using Abp.Modules;
using TG.UBP.Domain.Core;
using Abp.AutoMapper;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;

namespace TG.UBP.Application.Service
{
    [DependsOn(typeof(UbpDomainCoreModule), typeof(UbpApplicationDtoModule))]
    public class UbpApplicationServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                mapper.CreateMap<Module, ModuleListDto>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
