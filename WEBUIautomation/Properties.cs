using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WEBUIautomation
{
    public class Properties
    {
        public static string QCServer { get; private set; }
        public static string ServerPort { get; private set; }
        public static string UserName { get; private set; }
        public static string UserPasswod { get; private set; }
        public static string Domain { get; private set; }
        public static string ProjectName { get; private set; }

        public static void Read()
        {
            try
            {
                string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "properties.xml");
                XDocument mXml = XDocument.Load(startupPath);

                QCServer = mXml.Descendants("Server").ElementAt(0).Value;
                ServerPort = mXml.Descendants("Port").ElementAt(0).Value;
                UserName = mXml.Descendants("UserName").ElementAt(0).Value;
                UserPasswod = mXml.Descendants("UserPasswod").ElementAt(0).Value;
                Domain = mXml.Descendants("Domain").ElementAt(0).Value;
                ProjectName = mXml.Descendants("Project").ElementAt(0).Value;
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
