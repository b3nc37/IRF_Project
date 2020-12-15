using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Alkalmazas
{
    
    public static class XmlParser
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

        public static IEnumerable<string> GetRawValues(XmlDocument xmlDocument) 
        {
            var records = xmlDocument.DocumentElement?.ChildNodes;
            if (records is null)
            {
                throw new Exception("Érvénytelen az Xml fájl");
            }

            List<string> values = new List<string>();
            foreach (var record in records)
            {
                var currentRecord = record as XmlElement;
                if (!(currentRecord is null))
                {
                    foreach (var item in currentRecord.ChildNodes)
                    {
                        var leaf = item as XmlElement;
                        if (leaf != null)
                        {
                            values.Add(leaf.InnerText);
                        }
                    }

                    yield return CreateCsv(values); 
                    values.Clear();
                }
            }

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
