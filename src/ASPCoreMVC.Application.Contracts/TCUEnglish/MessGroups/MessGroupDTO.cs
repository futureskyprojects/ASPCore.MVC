﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ASPCoreMVC.TCUEnglish.MessGroups
{
    public class MessGroupDTO : EntityDto<Guid>
    {
        [Required]
        public Guid Starter { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Members { get; set; }
        public string LatestMessage { get; set; }
        public DateTime LatestMessageTime { get; set; }
        public int UnReadCount { get; set; }
        public string Photo { get; set; }

        public void SetId(Guid id)
        {
            this.Id = id;
        }
    }
}
