using System;
using System.Collections.Generic;

namespace QuartzScheduleApi.Model
{
    public partial class QrtzJobSettings
    {
        public int SettingId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
        public string Path { get; set; }
        public int? JobId { get; set; }

        public QrtzJobDetails Job { get; set; }
    }
}
