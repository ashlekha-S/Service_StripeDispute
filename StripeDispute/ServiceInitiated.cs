using StripeDispute.StripeDisputeService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace SaavorService
{
    /// <summary>
    /// ServiceInitiated
    /// </summary>
    public class ServiceInitiated
    {
        private readonly Timer _timer;

        public ServiceInitiated()
        {
            _timer = new Timer(60000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Task.Run(() =>
            {
                string filePath = string.Empty;
                try
                {
                    DateTime utcdate = DateTime.UtcNow;
                    DateTime istDateTime = TimeZoneInfo.ConvertTimeFromUtc(
                        utcdate,
                        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

                    string currentTime = istDateTime.ToString("hh:mm tt");
                    filePath = Path.Combine(
                        ConfigurationManager.AppSettings["LogFilePath"],
                        DateTime.Now.ToString("MM-dd-yyyy") + "_Logs.txt"
                    );
                    File.AppendAllLines(filePath, new[]
                        {
                        $"India Time {currentTime} UTC Time {utcdate}"
                    });
                    StripeDisputeService stripeDisputeService = new StripeDisputeService();
                    stripeDisputeService.GetInvoke();
                }
                catch (Exception ex)
                {
                    File.AppendAllText(filePath, ex.ToString());
                }
            });
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();
    }
}

 
