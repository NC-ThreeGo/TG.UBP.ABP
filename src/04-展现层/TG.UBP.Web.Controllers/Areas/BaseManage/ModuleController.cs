using Abp.Auditing;
using Abp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;
using TG.UBP.Application.Service.BaseManage.Permission.Modules;
using TG.UBP.Core.LinqHelper;

namespace TG.UBP.Web.Controllers.Areas.BaseManage
{
    [DisableAuditing]
    public class ModuleController : UbpControllerBase
    {
        private IModuleAppService _moduleAppService;

        public ModuleController(IModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }

        // GET: BaseManage/Module
        public ActionResult Index()
        {
            return View();
        }

        //ABP通过 AjaxResponse 对象来包装Actions的返回值。可以通过[DontWrapResult]来Enable/Disable包装
        [DontWrapResult]
        public async Task<JsonResult> GetList(string id)
        {
            if (id == null)
                id = "0";
            List<ModuleListDto> list = await _moduleAppService.GetModules(int.Parse(id));
            var json = from r in list
                       select new ModuleListDto()
                       {
                           Id = r.Id,
                           ModuleCode = r.ModuleCode,
                           ModuleName = r.ModuleName,
                           ParentId = r.ParentId,
                           Url = r.Url,
                           Icon = r.Icon,
                           Sort = r.Sort,
                           Remark = r.Remark,
                           EnabledMark = r.EnabledMark,
                           IsLast = r.IsLast,
                           state = (_moduleAppService.GetModules(r.Id).Result.Count() > 0) ? "closed" : "open"
                       };

            return Json(json);
        }


        #region 创建模块
        public ActionResult Create(string parentId)
        {
            if (parentId == null)
                parentId = "0";
            CreateModuleInput entity = new CreateModuleInput()
            {
                ParentId = int.Parse(parentId),
                Icon = "fa fa-puzzle-piece",
                EnabledMark = true,
                Sort = 0
            };
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateModuleInput model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (await _moduleAppService.CreateModule(model))
                {
                    return Success("增加模块成功");
                }
                else
                {
                    return Error("增加模块失败");
                }
            }
            else
            {
                return Error("模块数据验证失败");
            }
        }
        #endregion

        #region 修改模块
        public ActionResult Edit(string id)
        {
            CreateModuleInput entity = _moduleAppService.GetModuleById(int.Parse(id));
            return View(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CreateModuleInput model)
        {
            if (model != null && ModelState.IsValid)
            {
                if (await _moduleAppService.UpdateModule(model))
                {
                    return Success("修改模块成功");
                }
                else
                {
                    return Success("修改模块失败");
                }
            }
            else
            {
                return Error("模块数据验证失败");
            }
        }
        #endregion


        #region 查询操作码
        [HttpPost]
        [DontWrapResult]
        public JsonResult GetOptListByModule(GridPager pager, string mid)
        {
            if (mid == null)
                mid = "0";
            pager.rows = 1000;
            pager.page = 1;
            List<ModuleOperateDto> list = _moduleAppService.GetModuleOperates(ref pager, int.Parse(mid));
            var json = new
            {
                total = pager.totalRows,
                rows = list.ToArray()
            };

            return Json(json);
        }
        #endregion

        #region 创建操作码
        public ActionResult CreateOpt(string moduleId)
        {
            ModuleOperateDto moduleOperateDto = new ModuleOperateDto();
            moduleOperateDto.ModuleId = int.Parse(moduleId);
            moduleOperateDto.IsValid = true;
            return View(moduleOperateDto);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOpt(ModuleOperateDto input)
        {
            if (input != null && ModelState.IsValid)
            {
                if (await _moduleAppService.CreateModuleOperate(input))
                {
                    return Success("增加操作码成功");
                }
                else
                {
                    return Error("增加操作码失败");
                }
            }
            else
            {
                return Error("数据验证失败");
            }
        }
        #endregion

        #region 列过滤器
        [HttpPost]
        [DontWrapResult]
        public JsonResult GetColumnFiltersByModule(GridPager pager, string mid)
        {
            if (mid == null)
                mid = "0";
            pager.rows = 1000;
            pager.page = 1;
            List<ModuleColumnFilterDto> list = _moduleAppService.GetColumnFilters(ref pager, int.Parse(mid));
            var json = new
            {
                total = pager.totalRows,
                rows = list.ToArray()
            };

            return Json(json);
        }

        public ActionResult CreateColumnFilter(string moduleId)
        {
            ModuleColumnFilterDto columnFilterDto = new ModuleColumnFilterDto();
            columnFilterDto.ModuleId = int.Parse(moduleId);
            columnFilterDto.IsValid = true;
            return View(columnFilterDto);
        }


        [HttpPost]
        public async Task<ActionResult> CreateColumnFilter(ModuleColumnFilterDto input)
        {
            if (input != null && ModelState.IsValid)
            {
                if (await _moduleAppService.CreateColumnFilter(input))
                {
                    return Success("增加列过滤器成功");
                }
                else
                {
                    return Error("增加过滤器失败");
                }
            }
            else
            {
                return Error("数据验证失败");
            }
        }
        #endregion
    }
}