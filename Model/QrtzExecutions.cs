using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzExecutions
    {
        public int ExecutionId { get; set; }
        public long StartTime { get; set; }
        public long? EndTime { get; set; }
        public string State { get; set; }
        public long? PrevFireTime { get; set; }
        public long? NextFireTime { get; set; }
        public int JobId { get; set; }
        public int TriggerId { get; set; }
        public int? LogId { get; set; }

        public QrtzJobDetails Job { get; set; }
        public QrtzLogRecords Log { get; set; }
        public QrtzTriggers Trigger { get; set; }
    }
}
