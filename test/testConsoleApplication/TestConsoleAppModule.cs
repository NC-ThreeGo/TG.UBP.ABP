using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TG.UBP.Application.Service;
using TG.UBP.EF;

namespace TestConsoleApplication
{
    [DependsOn(
       typeof(UbpEFModule),
       typeof(UbpApplicationServiceModule))
        ]
    public class TestConsoleAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
