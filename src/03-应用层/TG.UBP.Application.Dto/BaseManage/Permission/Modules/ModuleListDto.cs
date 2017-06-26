using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using TG.UBP.Domain.Entity.BaseManage.Permission;

namespace TG.UBP.Application.Dto.BaseManage.Permission.Modules
{
    [AutoMapFrom(typeof(Module))]
    public class ModuleListDto : FullAuditedEntityDto
    {
        public long? ParentId { get; set; }

        public string ModuleCode { get; set; }

        public string ModuleName { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public string Target { set; get; }

        public bool IsLast { get; set; }

        public int? Sort { get; set; }

        public bool EnabledMark { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// �Ƿ�����ģ�飬�������="closed"������="open"
        /// </summary>
        public string state { get; set; }
    }
}