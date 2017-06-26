using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;
using System.Collections.Generic;
using TG.UBP.Core.LinqHelper;

namespace TG.UBP.Application.Service.BaseManage.Permission.Modules
{
    public interface IModuleAppService : IApplicationService
    {
        #region ģ��
        Task<List<ModuleListDto>> GetModules(int parentId);

        CreateModuleInput GetModuleById(int id);

        Task<bool> CreateModule(CreateModuleInput input);
        Task<bool> UpdateModule(CreateModuleInput input);
        #endregion

        #region ģ��Ĳ�����
        List<ModuleOperateDto> GetModuleOperates(ref GridPager pager, int moduleId);

        ModuleOperateDto GetModuleOperateById(int id);

        Task<bool> CreateModuleOperate(ModuleOperateDto input);
        Task<bool> UpdateModuleOperate(ModuleOperateDto input);
        #endregion

        #region ģ��������й�����
        List<ModuleColumnFilterDto> GetColumnFilters(ref GridPager pager, int moduleId);

        ModuleColumnFilterDto GetColumnFilterById(int id);

        Task<bool> CreateColumnFilter(ModuleColumnFilterDto input);
        Task<bool> UpdateColumnFilter(ModuleColumnFilterDto input);
        #endregion
    }
}