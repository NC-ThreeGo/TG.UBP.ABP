using System.Reflection;
using Abp.Modules;
using Abp.AutoMapper;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;

namespace TG.UBP.Application.Service
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class UbpApplicationDtoModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<Module, ModuleListDto>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
