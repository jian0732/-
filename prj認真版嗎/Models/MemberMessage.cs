using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class MemberMessage
    {
        public int MemberMessageId { get; set; }
        public int MembersId { get; set; }
        public string MemberMessageData { get; set; }

        public virtual Member Members { get; set; }
    }
}
