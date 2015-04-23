using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;


namespace WEBUIautomation.Utils
{
    //Create XML properties file to read from
    //public class Properties
    //{
    //    public static string QCServer { get; private set; }
    //    public static string ServerPort { get; private set; }
    //    public static string UserName { get; private set; }
    //    public static string UserPassword { get; private set; }
    //    public static string DomainName { get; private set; }
    //    public static string ProjectName { get; private set; }

    //   // public static IEnumerable<Browsers> Browsers { get; private set; }

    //    private static string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "properties.xml");

    //    public static void Create()
    //    {
    //        #region
    //        /*
    //        XmlDocument doc = new XmlDocument();
    //        XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
    //        doc.AppendChild(docNode);

    //        XmlNode propertiesNode = doc.CreateElement("properties");
    //        doc.AppendChild(propertiesNode);

    //        XmlNode serverNode = doc.CreateElement("Server");
    //        serverNode.AppendChild(doc.CreateTextNode("http://myd-vm00450.hpswlabs.adapps.hp.com"));
    //        propertiesNode.AppendChild(serverNode);

    //        XmlNode portNode = doc.CreateElement("Port");
    //        portNode.AppendChild(doc.CreateTextNode("8080"));
    //        propertiesNode.AppendChild(portNode);

    //        XmlNode userNameNode = doc.CreateElement("UserName");
    //        userNameNode.AppendChild(doc.CreateTextNode("sa"));
    //        propertiesNode.AppendChild(userNameNode);

    //        XmlNode UserPasswodNode = doc.CreateElement("UserPasswod");
    //        UserPasswodNode.AppendChild(doc.CreateTextNode(""));
    //        propertiesNode.AppendChild(UserPasswodNode);

    //        XmlNode DomainNode = doc.CreateElement("Domain");
    //        DomainNode.AppendChild(doc.CreateTextNode("OLEG"));
    //        propertiesNode.AppendChild(DomainNode);

    //        XmlNode ProjectNode = doc.CreateElement("Project");
    //        ProjectNode.AppendChild(doc.CreateTextNode("rest"));
    //        propertiesNode.AppendChild(ProjectNode);
            
    //        doc.Save(startupPath);
    //        */
    //        #endregion

    //        if (!File.Exists(startupPath))
    //        {
    //            try
    //            {
    //                XDocument xdoc = new XDocument(
    //                    new XElement("properties",
    //                        new XElement("Server", "http://myd-vm03805"),
    //                        new XElement("Port", "8080"),
    //                        new XElement("UserName", "sa"),
    //                        new XElement("UserPasswod", ""),
    //                        new XElement("Domain", "OLEG"),
    //                        new XElement("Project", "rest")
    //                    )
    //                );
    //                xdoc.Save(startupPath);
    //            }
    //            catch (Exception)
    //            {
    //                Environment.Exit(0);
    //            }
    //        }
    //    }
        
    //    public static void Read()
    //    {
    //        try
    //        {
    //            //string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "properties.xml");
    //            XDocument mXml = XDocument.Load(startupPath);

    //            QCServer = mXml.Descendants("Server").ElementAt(0).Value;
    //            ServerPort = mXml.Descendants("Port").ElementAt(0).Value;
    //            UserName = mXml.Descendants("UserName").ElementAt(0).Value;
    //            UserPassword = mXml.Descendants("UserPasswod").ElementAt(0).Value;
    //            DomainName = mXml.Descendants("Domain").ElementAt(0).Value;
    //            ProjectName = mXml.Descendants("Project").ElementAt(0).Value;
    //        }
    //        catch (Exception)
    //        {
    //            Environment.Exit(0);
    //        }
    //    }
    //}
}
