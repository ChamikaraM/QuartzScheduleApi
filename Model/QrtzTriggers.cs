﻿using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzTriggers
    {
        public QrtzTriggers()
        {
            QrtzExecutions = new HashSet<QrtzExecutions>();
            QrtzJobDetails = new HashSet<QrtzJobDetails>();
        }

        public int TriggerId { get; set; }
        public string SchedName { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroup { get; set; }
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string Description { get; set; }
        public long? NextFireTime { get; set; }
        public long? PrevFireTime { get; set; }
        public int? Priority { get; set; }
        public string TriggerState { get; set; }
        public string TriggerType { get; set; }
        public long StartTime { get; set; }
        public long? EndTime { get; set; }
        public string CalendarName { get; set; }
        public int? MisfireInstr { get; set; }
        public byte[] JobData { get; set; }
        public int? CronId { get; set; }

        public QrtzCronTriggers Cron { get; set; }
        public QrtzJobDetails QrtzJobDetailsNavigation { get; set; }
        public QrtzCronTriggers QrtzCronTriggers { get; set; }
        public QrtzSimpleTriggers QrtzSimpleTriggers { get; set; }
        public QrtzSimpropTriggers QrtzSimpropTriggers { get; set; }
        public ICollection<QrtzExecutions> QrtzExecutions { get; set; }
        public ICollection<QrtzJobDetails> QrtzJobDetails { get; set; }
    }
}
