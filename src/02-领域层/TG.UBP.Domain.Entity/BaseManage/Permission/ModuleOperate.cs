﻿using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace TG.UBP.Domain.Entity.BaseManage.Permission
{
    public class ModuleOperate : FullAuditedEntity
    {
        [Display(Name = "操作码")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        public string OperateCode { get; set; }

        [Display(Name = "操作名称")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        public string OperateName { get; set; }

        [Display(Name = "所属模块")]
        public int ModuleId { get; set; }

        [Display(Name = "是否验证")]
        public bool IsValid { get; set; }

        [Display(Name = " 排序码")]
        public int Sort { set; get; }

        /// <summary>
        /// 导航地址
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength200)]
        [Display(Name = "导航地址")]
        public string Url { set; get; }

        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Display(Name = "图标")]
        public string Icon { set; get; }

        //public virtual Module Model { get; set; }
    }
}
