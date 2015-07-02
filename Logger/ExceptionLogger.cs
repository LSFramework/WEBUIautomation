using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.IO;

namespace ExLogger
{
    public class ExceptionLogger
    {
        private Logger _log;

        public ExceptionLogger()
        {
            _log = LogManager.GetCurrentClassLogger();
        }

        public Logger Log
        {
            get { return _log; }
        }

    }
}
