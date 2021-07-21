namespace SilentMike.XsltPoC.WebApi.Entities
{
    using System.Xml.Serialization;
    using SilentMike.XsltPoC.WebApi.Extensions;

    public class XmlEmail
    {
        public string ToXmlString()
        {
            var serializer = new XmlSerializer(this.GetType());
            return serializer.Serialize(this);
        }
    }
}
