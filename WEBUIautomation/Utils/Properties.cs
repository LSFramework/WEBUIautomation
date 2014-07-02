using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WEBUIautomation.Utils
{
    //Create XML properties file to read from
    public class Properties
    {
        public static string QCServer { get; private set; }
        public static string ServerPort { get; private set; }
        public static string UserName { get; private set; }
        public static string UserPasswod { get; private set; }
        public static string Domain { get; private set; }
        public static string ProjectName { get; private set; }

        private static string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "properties.xml");

        public static void Create()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode productsNode = doc.CreateElement("products");
            doc.AppendChild(productsNode);

            XmlNode productNode = doc.CreateElement("product");
            XmlAttribute productAttribute = doc.CreateAttribute("id");
            productAttribute.Value = "01";
            productNode.Attributes.Append(productAttribute);
            productsNode.AppendChild(productNode);

            XmlNode nameNode = doc.CreateElement("Name");
            nameNode.AppendChild(doc.CreateTextNode("Java"));
            productNode.AppendChild(nameNode);
            XmlNode priceNode = doc.CreateElement("Price");
            priceNode.AppendChild(doc.CreateTextNode("Free"));
            productNode.AppendChild(priceNode);

            // Create and add another product node.
            productNode = doc.CreateElement("product");
            productAttribute = doc.CreateAttribute("id");
            productAttribute.Value = "02";
            productNode.Attributes.Append(productAttribute);
            productsNode.AppendChild(productNode);
            nameNode = doc.CreateElement("Name");
            nameNode.AppendChild(doc.CreateTextNode("C#"));
            productNode.AppendChild(nameNode);
            priceNode = doc.CreateElement("Price");
            priceNode.AppendChild(doc.CreateTextNode("Free"));
            productNode.AppendChild(priceNode);

            doc.Save(startupPath);
        }
        
        public static void Read()
        {
            try
            {
                //string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "properties.xml");
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
