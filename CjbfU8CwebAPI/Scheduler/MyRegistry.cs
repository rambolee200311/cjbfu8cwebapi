using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentScheduler;
using System.Diagnostics;
using System.IO;
using System.Threading;
using CjbfU8CwebAPI.Helper;
namespace CjbfU8CwebAPI.Scheduler
{
    public class MyRegistry:Registry
    {
        public MyRegistry()
        {
            // 每2秒一次循环
            Schedule<MyJob>().ToRunNow().AndEvery(60).Minutes();
            //Schedule<MyJob>().ToRunNow().AndEvery(3).Hours();
            LogHelper.Default.WriteInfo(DateTime.Now.ToString());
            //// 5秒后，只一次
            //Schedule<MyOtherJob>().ToRunOnceIn(5).Seconds();

            ////每天晚上21：15分执行
            //Schedule(() => Console.WriteLine("Timed Task - Will run every day at 9:15pm: " + DateTime.Now)).ToRunEvery(1).Days().At(11, 15);
            //Schedule<MyJob>().ToRunEvery(1).Days().At(21, 15);
            //// 每个月的执行
            //Schedule(() =>
            //{
            //    Console.WriteLine("Complex Action Task Starts: " + DateTime.Now);
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Complex Action Task Ends: " + DateTime.Now);
            //}).ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);

            ////先执行第一个Job、再执行第二个Job;完成后等5秒继续循环
            //Schedule<MyFirstJob>().AndThen<MySecoundJob>().ToRunNow().AndEvery(5).Seconds();
        }
    }
}