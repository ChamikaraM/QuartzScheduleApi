using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzCronTriggers
    {
        public QrtzCronTriggers()
        {
            QrtzTriggersNavigation = new HashSet<QrtzTriggers>();
        }

        public int CronId { get; set; }
        public string SchedName { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroup { get; set; }
        public string CronExpression { get; set; }
        public string TimeZoneId { get; set; }

        public QrtzTriggers QrtzTriggers { get; set; }
        public ICollection<QrtzTriggers> QrtzTriggersNavigation { get; set; }
    }
}
