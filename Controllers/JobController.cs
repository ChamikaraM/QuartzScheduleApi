using System;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;
using QuartzScheduleApi.Models;
using QuartzScheduleApi.Model;
using System.Linq;
using QuartzScheduleApi.Jobs;

namespace QuartzScheduleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly QuartzDBContext _context;
        private static IScheduler _scheduler; // add this field

        public JobController(QuartzDBContext context)
        {
            _context = context;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }


        [HttpGet("start")]
        public void start()
        {
            var properties = new NameValueCollection
            {
                // json serialization is the one supported under .NET Core (binary isn't)

                ["quartz.serializer.type"] = "json",
                ["quartz.scheduler.instanceName"] = "s1",
                // the following setup of job store is just for example and it didn't change from v2
                // according to your usage scenario though, you definitely need 
                // the ADO.NET job store and not the RAMJobStore.
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                ["quartz.jobStore.useProperties"] = "true",
                ["quartz.jobStore.dataSource"] = "sqlserver",
                ["quartz.jobStore.tablePrefix"] = "QRTZ_",
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
                //["quartz.dataSource.default.provider"] = "SqlServer-41", // SqlServer-41 is the new provider for .NET Core
                ["quartz.dataSource.sqlserver.provider"] = "SqlServer",
                ["quartz.dataSource.sqlserver.connectionString"] = @"Server=UNICORNCMI; Database = QuartzDB; Trusted_Connection = True;",
                ["quartz.threadPool.threadCount"] = "1",

            };
            var schedulerFactory = new StdSchedulerFactory(properties);
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.Start().Wait();
        }


        [HttpPost("addNewJob")]
        public void Post1([FromBody] Job new_job_details)
        {
            var properties = new NameValueCollection
            {
                // json serialization is the one supported under .NET Core (binary isn't)

                ["quartz.serializer.type"] = "json",
                ["quartz.scheduler.instanceName"] = new_job_details.Sched_Name,
                // the following setup of job store is just for example and it didn't change from v2
                // according to your usage scenario though, you definitely need 
                // the ADO.NET job store and not the RAMJobStore.
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                ["quartz.jobStore.useProperties"] = "true",
                ["quartz.jobStore.dataSource"] = "sqlserver",           //default dataSource is not working
                ["quartz.jobStore.tablePrefix"] = "QRTZ_",
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
                ["quartz.dataSource.sqlserver.provider"] = "SqlServer", // SqlServer-41 is the new provider for .NET Core
                ["quartz.dataSource.sqlserver.connectionString"] = @"Server=UNICORNCMI; Database = QuartzDB; Trusted_Connection = True;",
                ["quartz.threadPool.threadCount"] = "1",

            };



            var schedulerFactory = new StdSchedulerFactory(properties);
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.Start().Wait();

            var userEmailsJob = JobBuilder.Create<Job1>()
                .WithIdentity(new_job_details.Job_Name, new_job_details.Job_Group)
                //.UsingJobData("JobKey", Guid.NewGuid().ToString("N"))
                .Build();
            var userEmailsTrigger = TriggerBuilder.Create()
                .WithIdentity(new_job_details.Job_Name + " " + new_job_details.Cron_Expression)
                .StartNow()
                .WithCronSchedule(new_job_details.Cron_Expression)
                .Build();

            _scheduler.ScheduleJob(userEmailsJob, userEmailsTrigger).Wait();

            var JobDetails = _context.QrtzJobDetails.Where(a => a.JobName.Equals(new_job_details.Job_Name)).SingleOrDefault();
            var TriggerDetails = _context.QrtzTriggers.Where(a => a.JobName.Equals(new_job_details.Job_Name)).SingleOrDefault();
            var CronTrigger = _context.QrtzCronTriggers.Where(a => a.TriggerName.Equals(TriggerDetails.TriggerName)).SingleOrDefault();

            JobDetails.TriggerId = TriggerDetails.TriggerId;
            TriggerDetails.CronId = CronTrigger.CronId;

            _context.SaveChanges();

        }

        [HttpPost("update")]
        public void Update([FromBody] Job update_job_details)
        {
            Console.WriteLine("update ");
            var JobDetails = _context.QrtzJobDetails.Where(a => a.JobName.Equals(update_job_details.Job_Name)).SingleOrDefault();
            var TriggerDetails = _context.QrtzTriggers.Where(a => a.JobName.Equals(update_job_details.Job_Name)).SingleOrDefault();
            var CronDetails = _context.QrtzCronTriggers.Where(a => a.TriggerName.Equals(TriggerDetails.TriggerName)).SingleOrDefault();
            JobDetails.SchedName = update_job_details.Sched_Name;
            JobDetails.JobName = update_job_details.Job_Name;
            JobDetails.JobGroup = update_job_details.Job_Group;
            CronDetails.CronExpression = update_job_details.Cron_Expression;


            _context.SaveChanges();
            Console.WriteLine(JobDetails);

        }

        [HttpPost("delete")]
        public void Delete([FromBody] Job update_job_details)
        {
            Console.WriteLine("delete ");
            var JobDetails = _context.QrtzJobDetails.Where(a => a.JobName.Equals(update_job_details.Job_Name)).SingleOrDefault();
            _context.QrtzJobDetails.Remove(JobDetails);
            _context.SaveChanges();


        }


        [HttpGet("jobView")]
        public IActionResult GetAll()
        {
            Console.WriteLine("Inside of get all");
            var JobDetails = _context.QrtzJobDetails.ToList();
            Console.WriteLine(JobDetails);
            return Ok(JobDetails);
        }

        [HttpGet("TriggerView")]
        public IActionResult GetAllTrigger()
        {
            Console.WriteLine("Inside of get all tigger");
            var TriggerDetails = _context.QrtzTriggers.ToList();
            Console.WriteLine(TriggerDetails);
            return Ok(TriggerDetails);
        }


    }
}