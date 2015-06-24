using System.ComponentModel;

namespace WEBPages.BasePageObject
{
    public enum WorkloadMenu
    {
        [Description("Summary")]
        Summary=1,

        [Description("Groups & Workload")]
        GroupsAndWorkload=2,

        [Description("Monitors")]
        Monitors=3,

        [Description("Topology")]
        Topology=4,

        [Description("Diagnostics")]
        Diagnostics=5,

        [Description("Test Runs Trend")]
        TestRunsTrend=6
    }
}
