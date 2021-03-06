﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ASPCoreMVC.TCUEnglish.UserMessages
{
    public class UserMessageDTO : AuditedEntityDto<Guid>
    {
        [Required]
        public Guid MessGroupId { get; set; }
        [Required]
        public string Message { get; set; }
        public string Photo { get; set; }
        public string DisplayName { get; set; }
        public bool IsReceived { get; set; }
        public bool IsReaded { get; set; }
    }
}
