using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class AuditDetail
    {
        public int AuditDetailId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string? ChangeType { get; set; }
        public string? TableName { get; set; }
        public int? RecordId { get; set; }
        public string? ColumnName { get; set; }
        public string? FromValue { get; set; }
        public string? ToValue { get; set; }
    }
}
