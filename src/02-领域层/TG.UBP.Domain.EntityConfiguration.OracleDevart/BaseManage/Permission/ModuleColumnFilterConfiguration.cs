﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG.UBP.Domain.Entity.BaseManage.Permission;
using TG.UBP.EF;

namespace TG.UBP.Domain.EntityConfiguration.OracleDevart.BaseManage.Permission
{
    public class ModuleColumnFilterConfiguration : EntityConfigurationBase<ModuleColumnFilter, int>
    {
        public ModuleColumnFilterConfiguration()
        {
            this.ToTable("BASE_MODULECOLUMNFILTERS");
            this.Property(p => p.Id).HasColumnName("COLUMNFILTER_ID");
            this.Property(p => p.ModuleId).HasColumnName("MODULE_ID");
        }
    }
}
