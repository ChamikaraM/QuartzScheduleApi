using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzScheduleApi.Models
{
    public class Job
    {
        [Key]
        public string Sched_Name { get; set; }
        public string Job_Name { get; set; }
        public string Job_Group { get; set; }
        public string Cron_Expression { get; set; }
    }
}
