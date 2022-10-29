using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class EmailQueue
    {
        public int EmailQueueId { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? Recipients { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string? Status { get; set; }
        public string? ProcessMessages { get; set; }
        public int? UserId { get; set; }
    }
}
