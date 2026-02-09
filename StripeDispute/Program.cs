using System;
using Topshelf;

namespace SaavorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x=>{
                x.Service<ServiceInitiated>(s=>
                {
                    s.ConstructUsing(ServiceInitiated => new ServiceInitiated());
                    s.WhenStarted(ServiceInitiated => ServiceInitiated.Start());
                    s.WhenStopped(ServiceInitiated => ServiceInitiated.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("SaavorDisputeService");
                x.SetDisplayName("SaavorDisputeService");
                x.SetDescription("This is Saavor Dispute service");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
