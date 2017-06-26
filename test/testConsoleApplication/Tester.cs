//using Abp.AutoMapper;
using AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;
using TG.UBP.Application.Service.BaseManage.Permission.Modules;
using TG.UBP.Domain.Entity;
using TG.UBP.Domain.Entity.BaseManage.Permission;
using Abp.AutoMapper;

namespace TestConsoleApplication
{
    public class Tester : ITransientDependency
    {
        public ILogger Logger { get; set; }

        private readonly IRepository<Module, int> _moduleRepository;
        //private readonly IRepository<User, long> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private IModuleAppService _moduleAppService;

        public Tester(IRepository<Module, int> moduleRepository
            //, IRepository<User, long> userRepository
            , IUnitOfWorkManager unitOfWorkManager
            , IModuleAppService moduleAppService
            )
        {
            _moduleRepository = moduleRepository;
            //_userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _moduleAppService = moduleAppService;

            Logger = NullLogger.Instance;
        }

        public void TestEntitiyMapToDto()
        {
            //Mapper.Configuration.ResolveTypeMap(typeof(Module), typeof(ModuleListDto));

            Module m = new Module()
            {
                ParentId = 0,
                Icon = "fa fa-puzzle-piece",
                EnabledMark = true,
                Sort = 0,
                ModuleCode = "BaseManager",
                ModuleName = "系统管理",
                Remark = "平台的基础管理模块",
                IsLast = true,
                Url = "BaseManager",
                CreationTime = DateTime.Now,
                IsDeleted = false,
            };
            ModuleListDto dto = m.MapTo<ModuleListDto>();
            //ModuleListDto dto = Mapper.Map<ModuleListDto>(m);
        }

        public void TestCreateModule()
        {
            CreateModuleInput entity = new CreateModuleInput()
            {
                ParentId = 0,
                Icon = "fa fa-puzzle-piece",
                EnabledMark = true,
                Sort = 0,
                ModuleCode = "BaseManager",
                ModuleName = "系统管理",
                Remark = "平台的基础管理模块",
                IsLast = true,
                Url = "BaseManager"
            };
            _moduleAppService.CreateModule(entity);
        }

        public void Run()
        {
            //InintDevartOracle();
            Logger.Debug("Started Tester.Run()");

            //var module = _moduleRepository.Insert(new Module() { EnCode = "test11", FullName = "test11" });
            //_moduleRepository.Insert(new Module() { EnCode = "test2", FullName = "test2" });
            //_moduleRepository.Insert(new Module() { EnCode = "test3", FullName = "test3" });
            //_moduleRepository.Insert(new Module() { EnCode = "test4", FullName = "test4" });

            //_userRepository.Insert(new User() { EnCode = "test1", FullName = "test1" });
            //_userRepository.Insert(new User() { EnCode = "test1", FullName = "test1" });

            Console.WriteLine("禁用过滤器");
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                //Devart.Data.Oracle.OracleMonitor monitor = new Devart.Data.Oracle.OracleMonitor() { IsActive = true };
                _unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete);
                //GetAllList
                foreach (var user in _moduleRepository.GetAllList())
                {
                    Console.WriteLine(user);
                }
            }


            //Console.WriteLine("启用过滤器");
            //using (var unitOfWork = _unitOfWorkManager.Begin())
            //{
            //    //Devart.Data.Oracle.OracleMonitor monitor = new Devart.Data.Oracle.OracleMonitor() { IsActive = true };
            //    _unitOfWorkManager.Current.EnableFilter(AbpDataFilters.SoftDelete);
            //    //GetAllList
            //    foreach (var user in _moduleRepository.GetAllList())
            //    {
            //        Console.WriteLine(user);
            //    }
            //}

            Logger.Debug("Finished Tester.Run()");
        }

        private void InintDevartOracle()
        {
            Devart.Data.Oracle.OracleMonitor monitor = new Devart.Data.Oracle.OracleMonitor() { IsActive = true };
            Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig devartConfig = Devart.Data.Oracle.Entity.Configuration.OracleEntityProviderConfig.Instance;
            devartConfig.Workarounds.IgnoreSchemaName = true;
            devartConfig.Workarounds.DisableQuoting = true;
            devartConfig.CodeFirstOptions.UseDateTimeAsDate = true;
            devartConfig.CodeFirstOptions.UseNonLobStrings = true;
            devartConfig.CodeFirstOptions.UseNonUnicodeStrings = true;
            devartConfig.CodeFirstOptions.TruncateLongDefaultNames = true;
            //devartConfig.DatabaseScript.Column.MaxStringSize = Devart.Data.Oracle.Entity.Configuration.OracleMaxStringSize.Standard;
        }
    }
}
