using System.ComponentModel;

namespace WEBPages.BasePageObject
{
    public enum WorkloadMenu
    {
        [Description("Summary")]
        Summary,

        [Description("Groups & Workload")]
        GroupsAndWorkload,

        [Description("Monitors")]
        Monitors,

        [Description("Topology")]
        Topology,

        [Description("Diagnostics")]
        Diagnostics,

        [Description("Test Runs Trend")]
        TestRunsTrend
    }
}
