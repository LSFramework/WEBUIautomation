using System.Diagnostics;
using System.Reflection;

namespace WEBUIautomation.Utils
{
    public class TestInfo
    {
        public static string GetTestName()
        {
            var stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            return methodBase.Name;
        }
    }
}
