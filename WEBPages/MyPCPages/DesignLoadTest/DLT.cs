using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBPages.BasePageObject;

namespace WEBPages.MyPCPages.DesignLoadTest
{
    public class DLT
    {
        private DltGroupsAndWorkloadPage _workload;
        private DltSummaryPage _summary;

        private LoadTest _loadTest;

        public LoadTest LoadTest { get { return _loadTest; } }

        public DltGroupsAndWorkloadPage Workload { get { return _workload; } }

        public DltSummaryPage Summary { get { return _summary; } }

        public DLT(LoadTest loadTest)
        {
            this._loadTest = loadTest;
            _workload = new DltGroupsAndWorkloadPage(_loadTest);
            _summary = new DltSummaryPage(_loadTest);
        }

    }
}
