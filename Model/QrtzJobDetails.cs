using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzJobDetails
    {
        public QrtzJobDetails()
        {
            QrtzExecutions = new HashSet<QrtzExecutions>();
            QrtzJobSettings = new HashSet<QrtzJobSettings>();
            QrtzTriggers = new HashSet<QrtzTriggers>();
        }

        public int JobId { get; set; }
        public string SchedName { get; set; }
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string Description { get; set; }
        public string JobClassName { get; set; }
        public bool IsDurable { get; set; }
        public bool IsNonconcurrent { get; set; }
        public bool IsUpdateData { get; set; }
        public bool RequestsRecovery { get; set; }
        public byte[] JobData { get; set; }
        public int? TriggerId { get; set; }

        public QrtzTriggers Trigger { get; set; }
        public ICollection<QrtzExecutions> QrtzExecutions { get; set; }
        public ICollection<QrtzJobSettings> QrtzJobSettings { get; set; }
        public ICollection<QrtzTriggers> QrtzTriggers { get; set; }
    }
}
