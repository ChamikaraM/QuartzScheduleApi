using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzLogRecords
    {
        public QrtzLogRecords()
        {
            QrtzExecutions = new HashSet<QrtzExecutions>();
        }

        public int LogId { get; set; }
        public long? ExecutionTime { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }

        public ICollection<QrtzExecutions> QrtzExecutions { get; set; }
    }
}
