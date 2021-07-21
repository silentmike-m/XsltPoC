namespace SilentMike.XsltPoC.WebApi.Extensions
{
    using System.Xml.Serialization;
    using SilentMike.XsltPoC.WebApi.Common;

    public static class XmlSerializerExtensions
    {
        public static string Serialize(this XmlSerializer self, object o)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using var stringwriter = new Utf8StringWriter();
            self.Serialize(stringwriter, o, ns);
            return stringwriter.ToString();
        }
    }
}