using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using TG.UBP.Application.Dto.BaseManage.Permission.Modules;
using TG.UBP.Application.Service.BaseManage.Permission.Modules;
using TG.UBP.Web.Models;

namespace TG.UBP.Web.Controllers
{
    public class HomeController : UbpControllerBase
    {
        private IModuleAppService _moduleAppService;

        public HomeController(IModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }


        #region UI框架
        public ActionResult Index()
        {
            if (Session["Account"] != null)
            {
                //SiteConfig siteConfig = SiteConfigProvider.LoadConfig(Utils.GetXmlMapPath("Configpath"));

                //获取是否开启WEBIM
                //ViewBag.IsEnable = siteConfig.webimstatus;
                //获取信息间隔时间
                //ViewBag.NewMesTime = siteConfig.refreshnewmessage;
                //系统名称
                //ViewBag.WebName = siteConfig.webname;
                ViewBag.WebName = "三行统一业务平台";
                //公司名称
                //ViewBag.ComName = siteConfig.webcompany;
                //版权
                //ViewBag.CopyRight = siteConfig.webcopyright;
                //在线人数
                //OnlineUserRecorder recorder = HttpContext.Cache[OnlineHttpModule.g_onlineUserRecorderCacheKey] as OnlineUserRecorder;
                ViewBag.OnlineCount = 100;// recorder.GetUserList().Count;
                AccountModel account = new AccountModel();
                account = (AccountModel)Session["Account"];
                return View(account);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        //父ID=0的数据为顶级菜单
        public async Task<ActionResult> GetTopMenu()
        {
            //加入本地化
            //CultureInfo info = Thread.CurrentThread.CurrentCulture;
            //string infoName = info.Name;
            //if (Session["Account"] != null)
            //{
            //    //加入本地化
            //    AccountModel account = (AccountModel)Session["Account"];
            //    List<SysModuleModel> list = homeBLL.GetMenuByPersonId(account.Id, "0");
            //    var json = from r in list
            //               select new SysModuleNavModel()
            //               {
            //                   id = r.Id,
            //                   text = infoName.IndexOf("zh") > -1 || infoName == "" ? r.Name : r.EnglishName,     //text
            //                   attributes = (infoName.IndexOf("zh") > -1 || infoName == "" ? "zh-CN" : "en-US") + "/" + r.Url,
            //                   iconCls = r.Iconic
            //               };


            //    return Json(json);
            //}
            //else
            //{
            //    return Json("0", JsonRequestBehavior.AllowGet);
            //}

            List<ModuleListDto> list = await _moduleAppService.GetModules(0);
            var json = from r in list
                       select new SysModuleNavModel()
                       {
                           id = r.Id.ToString(),
                           text = r.ModuleName,     //text
                           attributes = r.Url,
                           iconCls = r.Icon
                       };
            return Json(json);

            //List<SysModuleNavModel> list = new List<SysModuleNavModel>();
            //list.Add(new SysModuleNavModel() { id = "201605312304598866131890ede44b6", iconCls = "fa  fa-hand-pointer-o", attributes = "zh-CN/spl", text = "开发指南" });
            //list.Add(new SysModuleNavModel() { id = "20161124112512659817453d009fb84", iconCls = "fa fa-puzzle-piece", attributes = "zh-CN/", text = "信息系统" });
            //list.Add(new SysModuleNavModel() { id = "201407241558264790957ebaf9fec63", iconCls = "fa fa-sort-amount-asc", attributes = "zh-CN/flow", text = "工作流程" });
            //list.Add(new SysModuleNavModel() { id = "2016112411022140581745f0f582911", iconCls = "fa  fa-weixin", attributes = "fa  fa-weixin", text = "微信系统" });
            //list.Add(new SysModuleNavModel() { id = "SystemManage", iconCls = "fa fa-gears", attributes = "zh-CN/sys", text = "系统管理" });
            //list.Add(new SysModuleNavModel() { id = "20161124111315488817464f920b54f", iconCls = "fa  fa-shield", attributes = "zh-CN/", text = "权限系统" });
            //return Json(list, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public async Task<ActionResult> GetTreeByEasyui(string id)
        {
            //加入本地化
            //CultureInfo info = Thread.CurrentThread.CurrentCulture;
            //string infoName = info.Name;
            //if (Session["Account"] != null)
            //{
            //    //加入本地化
            //    AccountModel account = (AccountModel)Session["Account"];
            //    List<SysModuleModel> list = homeBLL.GetMenuByPersonId(account.Id, id);
            //    var json = from r in list
            //               select new SysModuleNavModel()
            //               {
            //                   id = r.Id,
            //                   text = infoName.IndexOf("zh") > -1 || infoName == "" ? r.Name : r.EnglishName,     //text
            //                   attributes = (infoName.IndexOf("zh") > -1 || infoName == "" ? "zh-CN" : "en-US") + "/" + r.Url,
            //                   iconCls = r.Iconic,
            //                   state = (m_BLL.GetList(r.Id).Count > 0) ? "closed" : "open"

            //               };


            //    return Json(json);
            //}
            //else
            //{
            //    return Json("0", JsonRequestBehavior.AllowGet);
            //}

            List<ModuleListDto> list = await _moduleAppService.GetModules(int.Parse(id));
            var json = from r in list
                       select new SysModuleNavModel()
                       {
                           id = r.Id.ToString(),
                           text = r.ModuleName,     //text
                           attributes = r.Url,
                           iconCls = r.Icon,
                           state = (_moduleAppService.GetModules(r.Id).Result.Count > 0) ? "closed" : "open"
                       };
            return Json(json);

            //List<SysModuleNavModel> list = new List<SysModuleNavModel>();
            //list.Add(new SysModuleNavModel() { id = "201611241127104938174ca14069a09", iconCls = "fa  fa-puzzle-piece", attributes = "zh-CN/", text = "简单样例", state = "closed" });
            //list.Add(new SysModuleNavModel() { id = "201611241128515238174870b8252a2", iconCls = "fa  fa-paste", attributes = "zh-CN/", text = "复杂样例", state = "closed" });
            //return Json(list, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SetThemes(string theme, string menu, bool topmenu)
        {
            //SysUserConfigModel entity = userConfigBLL.GetById("themes", GetUserId());
            //if (entity != null)
            //{
            //    entity.Value = theme;
            //    userConfigBLL.Edit(ref errors, entity);
            //}
            //else
            //{
            //    entity = new SysUserConfigModel()
            //    {
            //        Id = "themes",
            //        Name = "用户自定义主题",
            //        Value = theme,
            //        Type = "themes",
            //        State = true,
            //        UserId = GetUserId()
            //    };
            //    userConfigBLL.Create(ref errors, entity);

            //}
            //Session["themes"] = theme;

            ////开启顶部菜单，顶部菜单必须配置多一层
            //if (topmenu)
            //{
            //    menu = menu + ",topmenu";
            //}
            //SysUserConfigModel entityMenu = userConfigBLL.GetById("menu", GetUserId());
            //if (entityMenu != null)
            //{
            //    entityMenu.Value = menu;
            //    userConfigBLL.Edit(ref errors, entityMenu);
            //}
            //else
            //{
            //    entityMenu = new SysUserConfigModel()
            //    {
            //        Id = "menu",
            //        Name = "用户自定义菜单",
            //        Value = menu,
            //        Type = "menu",
            //        State = true,
            //        UserId = GetUserId()
            //    };
            //    userConfigBLL.Create(ref errors, entityMenu);

            //}

            //Session["menu"] = menu;
            //return Json("1", JsonRequestBehavior.AllowGet);

            return Json("1", JsonRequestBehavior.AllowGet);
        }


        public ActionResult TopInfo()
        {
            if (Session["Account"] != null)
            {
                AccountModel account = new AccountModel();
                account = (AccountModel)Session["Account"];
                return View(account);
            }
            return View();
        }

        #endregion

        #region js配置
        //public JavaScriptResult ConfigJs()
        //{
        //    CultureInfo info = Thread.CurrentThread.CurrentCulture;
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("var _YMGlobal;");
        //    sb.Append("(function(_YMGlobal) {");
        //    sb.Append("    var Config = (function() {");
        //    sb.Append("        function Config() {}");
        //    sb.AppendFormat("  Config.currentCulture = '{0}';", info.Name);
        //    sb.AppendFormat("  Config.apiUrl = '{0}';", "");
        //    sb.AppendFormat("  Config.token = '{0}';", "");
        //    sb.Append("       return Config;");
        //    sb.Append("   })();");
        //    sb.Append("   _YMGlobal.Config = Config;");
        //    sb.Append(" })(_YMGlobal || (_YMGlobal = { }));");

        //    return JavaScript(sb.ToString());
        //}
        #endregion

        public ActionResult Desktop()
        {
            //SysUserConfig ss = webPartBLL.GetByIdAndUserId("webpart", GetUserId());
            //if (ss != null)
            //{
            //    ViewBag.Value = ss.Value;
            //}
            //else
            //{
            //    ViewBag.Value = "";
            //}
            return View();
        }
    }
}