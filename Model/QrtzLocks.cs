using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzLocks
    {
        public string SchedName { get; set; }
        public string LockName { get; set; }
    }
}
