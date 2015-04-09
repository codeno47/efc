using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Principal;

namespace Experion.Updated.Tester
{
    using System.ServiceModel;

    using HealthServiceClient = Experion.Updated.Tester.EHS.HealthServiceClient;

    class Program
    {
        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName, String lpszDomain,
            String lpszPassword, int dwLogonType, int dwLogonProvider,
            ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken, int impersonationLevel,
            ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        static void Main(string[] args)
        {
            try
            {
                //AuthenticateUser();
                EHS.IService1 service = new EHS.Service1Client();
                EHS.IHealthService healthService = new HealthServiceClient();

                service.GetData(0);
                var data = healthService.GetMemoryUsage();


            }
            catch (FaultException exception)
            {

                throw;
            }

            //localEHS.IService1 service = new Service1Client();
            //service.GetData(0);

            Console.WriteLine("Service Call went successful, Press any key to continue...");
            Console.ReadKey();
        }

        private static void StartPerfomanceCounter()
        {
            var category = "Web Service";
            var counter = "Current Connections";
            var instance = "_Total";
            var server = "192.168.1.7";
            var perf = new PerformanceCounter(category, counter, instance, server);

            int connections = (int)perf.NextValue();
        }

        private static void AuthenticateUser()
        {
            var username = "binu.bhasuran";
            var password = "win2008...";
            var domain = "experion.in";

            WindowsImpersonationContext impersonationContext;

            // if impersonation fails - return
            if (!ImpersonateValidUser(username, password, domain, out impersonationContext))
            {
                throw new AuthenticationException("Impersonation failed");
            }
            StartPerfomanceCounter();
            //PerformanceCounterCategory.Delete(PerfCategory);
            //UndoImpersonation(impersonationContext);
        }

        private static bool ImpersonateValidUser(string username, string password,
    string domain, out WindowsImpersonationContext impersonationContext)
        {
            const int LOGON32_LOGON_INTERACTIVE = 2;
            const int LOGON32_PROVIDER_DEFAULT = 0;
            WindowsIdentity tempWindowsIdentity;
            var token = IntPtr.Zero;
            var tokenDuplicate = IntPtr.Zero;

            if (RevertToSelf())
            {
                if (LogonUserA(username, domain, password,
                     LOGON32_LOGON_INTERACTIVE,
                     LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();

                        if (impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }

            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);

            impersonationContext = null;
            return false;
        }

    }
}
