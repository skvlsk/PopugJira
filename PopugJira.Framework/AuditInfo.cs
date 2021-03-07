#nullable enable

using System;

namespace PopugJira.Framework
{
    public class AuditInfo
    {
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }

        public int Version { get; set; }
    }
}