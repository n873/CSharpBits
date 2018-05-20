using System;
using System.Collections.Generic;
using System.Xml;

namespace CSharpBits.Common.Utility.Xml
{
    public static class XmlUtility
    {
        public static string ExtractFieldFromResponse(string response, string fieldName)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(response);

                XmlNodeList nodes = document.GetElementsByTagName(fieldName);

                if (nodes.Count > 0)
                    return nodes[0].InnerText;

                return string.Empty;
            }
            catch (Exception) { throw; }
        }

        public static List<string> ExtractFieldsFromResponse(string response, string fieldName)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(response);

                XmlNodeList nodes = document.GetElementsByTagName(fieldName);

                if (nodes.Count > 0)
                {
                    var fields = new List<string>();
                    foreach (XmlNode node in nodes)
                        fields.Add(node.InnerText);

                    return fields;
                }

                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
