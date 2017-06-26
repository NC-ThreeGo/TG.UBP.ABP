using System.Web.Mvc;

namespace TG.UBP.Web.Areas.BaseManage
{
    public class BaseManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BaseManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BaseManage_default",
                "BaseManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
                 , namespaces: new string[] { "TG.UBP.Web.Controllers.Areas.BaseManage" }
            );
        }
    }
}