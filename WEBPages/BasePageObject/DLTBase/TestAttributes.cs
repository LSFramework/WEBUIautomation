using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.BasePageObject
{
    public enum TestAttributes
    {
        [Description("Test name")]
        TestName,

        [Description("Short Test Name")]
        ShortName,

        [Description("Test ID")]
        TestId,

        [Description("Validation")]
        Validation,

        [Description("Workload Type")]
        WorkloadType,

        [Description("Total Vusers")]
        TotalVusers,

        [Description("Topology")]
        Topology,

        [Description("Diagnostics")]
        Diagnostics,

        [Description("Monitors")]
        Monitors,

        [Description("IP Spoofer")]
        IP_Spoofer,

        [Description("Controller")]
        Controller,

        [Description("Assign To")]
        AssignTo
    }
}
