using Abp.Web.Mvc.Views;
using TG.UBP.Domain.Core;

namespace TG.UBP.Web.Views
{
    public abstract class UBPWebViewPageBase : UBPWebViewPageBase<dynamic>
    {

    }

    public abstract class UBPWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected UBPWebViewPageBase()
        {
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
        }
    }
}