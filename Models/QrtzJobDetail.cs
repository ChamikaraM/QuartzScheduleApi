using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzScheduleApi.Models
{
    public class QrtzJobDetail
    {
        [Key]
        public string SCHED_NAME { get; set; }
        public string JOB_NAME { get; set; }
        public string JOB_GROUP { get; set; }
        public string DESCRIPTION { get; set; }
        public string JOB_CLASS_NAME { get; set; }
        public string IS_DURABLE { get; set; }
        public string IS_NONCONCURRENT { get; set; }
        public string IS_UPDATE_DATA { get; set; }
        public string REQUESTS_RECOVERY { get; set; }
        public string JOB_DATA { get; set; }

    }
}
