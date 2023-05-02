using Quartz;
using Quartz.Impl;

namespace Expansion;

public abstract class Jobs
{
    public static async Task RunProgram()
    {
        try
        {
            //Create Scheduler
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();
            
            //Create Job
            var job = JobBuilder.Create<ShowDataTimeJob>()
                .WithIdentity("job1", "group1").Build();
            
            //Create Trigger 
            var trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();
            
            //Add into ScheduleJob
            await scheduler.ScheduleJob(job, trigger);
            
            //Start
            await scheduler.Start();
            
            //Run how many times
            await Task.Delay(TimeSpan.FromSeconds(10));
            
            //Shutdown
            await scheduler.Shutdown();
        }
        catch (SchedulerException schedulerException)
        {
            await Console.Error.WriteLineAsync(schedulerException.ToString());
        }
    }

    
    [DisallowConcurrentExecution]
    private class ShowDataTimeJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync($"Time: {DateTime.Now}");
        }
    }
}