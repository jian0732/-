﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class Admin
    {
        public Admin()
        {
            AdminStatuses = new HashSet<AdminStatus>();
        }

        public int AdminId { get; set; }
        [DisplayName("品名")]
        public string AdminName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public virtual ICollection<AdminStatus> AdminStatuses { get; set; }
    }
}
