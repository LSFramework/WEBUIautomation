using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBPages.ContentLocators
{
    public enum MainHead_Links
    {
        [Description("Test Management")]
        TestManagement,

        [Description("Runs & Analysis")]
        RunAnalysis,

        [Description("Resources")]
        Resources,

        [Description("Personalized Views")]
        PersonalizedViews
    }

    public enum Perspectives
    {
        [Description("Start")]
        Start,

        [Description("Test Plan")]
        TestPlan,

        [Description("Test Lab")]
        TestLab,

        [Description("Runs")]
        Runs,

        [Description("Trending")]
        Trending,

        [Description("PAL")]
        PAL,

        [Description("Test Resources")]
        TestResources,

        [Description("Testing Hosts")]
        TestingHosts,

        [Description("Timeslots")]
        Timeslots,

        [Description("Topologies")]
        Topologies,

        [Description("MI Listeners")]
        MIListeners,

        [Description("Reports")]
        Reports,

        [Description("Create New")]
        CreateNew
    }
}
