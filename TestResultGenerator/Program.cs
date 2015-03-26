
using System;
using System.IO;
namespace TestResultGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("TestFixtureResult.html"))
                {
                    // Produce the report.
                    NUnitDocumentor.NUnitDocumentor documentor = new NUnitDocumentor.NUnitDocumentor(
                        "TestResult.xml",
                        "WEBUItests.xml",
                        "WEBUItests.dll", writer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("");
                Console.WriteLine(e.StackTrace);               
            }
        }
    }
}
