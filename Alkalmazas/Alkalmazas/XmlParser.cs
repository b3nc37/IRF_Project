using System;
using System.Xml;

namespace Alkalmazas
{
    public class XmlParser
    {
        public static XmlDocument LoadXml(string path) 
        {
            var xml = new XmlDocument();
            xml.Load(path); // a LoadXml itt nem működött
            return xml;
        }
    }
}
