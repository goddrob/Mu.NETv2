using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace Mu.NETv2.Configs
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<RankJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("rank", "gamedb")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(30)
                .RepeatForever())
               .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}