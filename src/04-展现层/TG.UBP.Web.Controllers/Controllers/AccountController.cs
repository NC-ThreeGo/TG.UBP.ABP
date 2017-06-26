using Abp.Localization;
using System.Threading.Tasks;
using System.Web.Mvc;
using TG.UBP.Core;
using TG.UBP.Core.Security;
using TG.UBP.Web.Models;
using TG.UBP.Web.Utility;

namespace TG.UBP.Web.Controllers
{
    public class AccountController : UbpControllerBase
    {
        private readonly ILanguageManager _languageManager;

        public AccountController(
            ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        // GET: Account
        public ActionResult Index()
        {
            //系统名称
            ViewBag.WebName = "三行统一业务平台";
            //公司名称
            ViewBag.ComName = "南昌三行";
            //CopyRight
            ViewBag.CopyRight = "2013-2017";

            return View();
        }

        public ActionResult Login()
        {
            //系统名称
            ViewBag.WebName = "三行统一业务平台";
            //公司名称
            ViewBag.ComName = "南昌三行";
            //CopyRight
            ViewBag.CopyRight = "2013-2017";

            return View();
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        [HttpPost]
        public async Task<ActionResult> Login(string UserName, string Password, string Code)
        {
            if (Session[ContextKeys.VerifyCodeSession] == null)
                return Error("请重新刷新验证码");

            if (!SecurityHelper.CheckVerify(Code))
                return Error("验证码错误");

            //UserOutputDto user = await IdentityContract.Login(UserName, Password);
            //if (user == null)
            //{
            //    Logger.Info("用户:" + UserName + "在" + Utils.NowTime + "登录系统,IP:" + this.Request.GetIpAddress() + "账户或密码错误");
            //    return Json(new OperationResult(OperationResultType.ValidError, "用户名或密码错误").ToAjaxResult(), JsonRequestBehavior.AllowGet);
            //}
            //else if (Convert.ToBoolean(user.IsLocked))//被禁用
            //{
            //    return Json(new OperationResult(OperationResultType.ValidError, "账户被系统禁用").ToAjaxResult(), JsonRequestBehavior.AllowGet);
            //}

            AccountModel account = new AccountModel();
            //account.Id = user.Id.ToString();
            //account.NickName = user.NickName;
            ////account.Photo = string.IsNullOrEmpty(user.Photo) ? "/Images/Photo.jpg" : user.Photo;
            //Session["Account"] = account;
            //GetThemes(user.Id.ToString());

            if (UserName == "admin" && Password == "123456")
            {
                account.Id = "1";
                account.NickName = "admin";
                Session["Account"] = account;
                GetThemes("1");
                return Success("登录成功");
            }
            else
            {
                return Error("用户名或密码错误");
            }

            //LoginUserManage.Add(Session.SessionID, account.Id);

            //在线用户统计
            //OnlineHttpModule.ProcessRequest();
            //Logger.Info("用户:" + UserName + "在" + Utils.NowTime + "登录系统,IP:" + this.Request.GetIpAddress() + "登录成功");

            return Success("登录成功");
        }
        /// <summary>
        /// 安全退出
        /// </summary>
        [HttpPost]
        public void LogOut()
        {
            if (Session["Account"] != null)
                Session["Account"] = null;
            Session.Clear();
            Session.Abandon();
        }

        public void GetThemes(string userid)
        {
            //SysUserConfigModel entity = userConfigBLL.GetById("themes", userid);
            //SysUserConfigModel menuEntity = userConfigBLL.GetById("menu", userid);
            //if (entity != null)
            //{
            //    Session["themes"] = entity.Value;
            //}
            //else
            //{
            //    Session["themes"] = "blue";
            //}
            //if (menuEntity != null)
            //{
            //    Session["menu"] = menuEntity.Value;
            //}
            //else
            //{
            //    Session["menu"] = "accordion";
            //}

            Session["themes"] = "purple";
            Session["menu"] = "accordion,topmenu";
        }
    }
}