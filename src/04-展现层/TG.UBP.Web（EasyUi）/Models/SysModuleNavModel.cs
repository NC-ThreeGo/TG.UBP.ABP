using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TG.UBP.Web.Models
{
    public partial class SysModuleNavModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string attributes { get; set; }
        public string state { get; set; }

    }
}