using System.Xml;

namespace sc
{
    public class xml
    {
        // ─── Load ─────────────────────────────────────────────────────────────────

        public static object[]? loadAbsolute(string absolutePath, string rootName = "root")
        {
            var doc = new XmlDocument();
            try { doc.Load(absolutePath); }
            catch { return null; }

            var xmlRoot = doc.SelectSingleNode(rootName);
            if (xmlRoot == null) return null;
            return new object[] { getXmlAttribs(xmlRoot), getXmlValues(xmlRoot)! };
        }

        // CHANGED: removed HttpContext.Server.MapPath virtual-path resolution — API has no HttpContext
        // Only absolute paths (containing ":\") are supported now
        public static XmlDocument? getXmlDocument(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return null;
            try
            {
                var doc = new XmlDocument();
                doc.Load(path);
                return doc;
            }
            catch { return null; }
        }

        // ─── Helpers ──────────────────────────────────────────────────────────────

        static object getXmlAttribs(XmlNode xmlNode)
        {
            var atts = new Dictionary<string, object>();
            if (xmlNode.Attributes == null) return atts;
            foreach (XmlAttribute a in xmlNode.Attributes)
                atts[a.Name.ToLower()] = a.Value;
            return atts;
        }

        static object? getXmlValues(XmlNode xmlNode)
        {
            Dictionary<string, object>? vals = null;
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element && node is XmlElement ele)
                {
                    vals ??= new Dictionary<string, object>();
                    object nodeValue = new object[] { getXmlAttribs(ele), ele.HasChildNodes ? getXmlValues(ele)! : (object)ele.InnerText };
                    vals[ele.Name] = nodeValue;
                }
                else if (node.NodeType == XmlNodeType.Text)
                {
                    return node.InnerText;
                }
            }
            return vals;
        }
    }
}
