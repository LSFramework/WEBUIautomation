using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBUIautomation.Wait
{
    public class WaitProfile
    {
        public TimeSpan PollingInterval { get; private set; }
        public TimeSpan Timeout { get; private set; }

        private bool condition(TimeSpan timeout, TimeSpan pollingInterval)
        {
            return 
                timeout >= TimeSpan.Zero && 
                pollingInterval >= TimeSpan.Zero && 
                timeout >= pollingInterval;            
        }

        public WaitProfile(TimeSpan timeout, TimeSpan pollingInterval) 
        {
            Contract.Requires(condition(timeout, pollingInterval));

            PollingInterval = pollingInterval;
            Timeout = timeout;
        }
        
    }
}
