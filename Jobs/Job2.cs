using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzScheduleApi.Jobs
{
    public class Job2 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job2 done");

            // delegate the actual work to email service
            Console.WriteLine(DateTime.Now.ToString());
            return Task.FromResult(0);
        }
    }
}
