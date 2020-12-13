using System;
using System.Xml;

namespace Alkalmazas
{
    
    public class XmlParser
    {
        public static XmlDocument LoadXml(string path) 
        {
            var xml = new XmlDocument();
            xml.Load(path); 
            return xml;
        }
        
        public static string GetHeadersForCsv(XmlDocument xmlDocument)
        {
            var records = xmlDocument.DocumentElement?.ChildNodes;
            if (records is null)
            {
                throw new Exception("Érvénytelen az Xml fájl");
            }

            var firstNode = (records[0] as XmlElement)?.ChildNodes;
            if (firstNode is null)
            {
                throw new Exception("Nem tartalmaz adatokat az Xml");
            }
        }
    }
}
