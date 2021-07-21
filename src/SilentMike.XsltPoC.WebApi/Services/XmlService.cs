namespace SilentMike.XsltPoC.WebApi.Services
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    using Microsoft.Extensions.FileProviders;

    internal sealed class XmlService
    {
        private readonly IFileProvider fileProvider;

        public XmlService(IFileProvider fileProvider)
            => (this.fileProvider) = (fileProvider);

        public string GetHtml(string xmlString, string xsltFileName)
        {
            using var xsltStream = this.fileProvider.GetFileInfo(xsltFileName).CreateReadStream();
            using var xsltReader = XmlReader.Create(xsltStream);
            var transform = new XslCompiledTransform();
            transform.Load(xsltReader);

            using var xmlReader = XmlReader.Create(new StringReader(xmlString));

            var stringBuilder = new StringBuilder();
            using var xmlWriter = XmlWriter.Create(new StringWriter(stringBuilder), transform.OutputSettings);
            transform.Transform(xmlReader, xmlWriter);

            return stringBuilder.ToString();
        }
    }
}
