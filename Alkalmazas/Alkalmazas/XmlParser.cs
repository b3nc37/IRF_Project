using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Text;
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

            List<string> headers = new List<string>();
            foreach (var item in firstNode)
            {
                var element = item as XmlElement;
                if (!(element is null))
                {
                    headers.Add(element.Name);
                }
            }

            return CreateCsv(headers);
        }

        private static string CreateCsv(IEnumerable<string> values) 
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in values)
            {
                sb.Append($"{item};");
            }
            return sb.ToString().TrimEnd(';');
        }
    }
}
