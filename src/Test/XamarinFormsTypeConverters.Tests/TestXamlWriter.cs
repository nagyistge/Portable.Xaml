using System.Text;
using System.Xml;
using Portable.Xaml;

namespace XamarinFormsTypeConverters.Tests
{
    public class XamarinFormsSchemaContext : XamlSchemaContext
    {
        public XamarinFormsSchemaContext(XamlSchemaContextSettings settings)
            : base(settings)
        {
        }
    }

    public static class TestXamlWriter
    {
        public static string Save(object instance)
        {
            var sb = new StringBuilder();

            var xmlsettings = new XmlWriterSettings
            {
                NewLineOnAttributes = true,
                Indent = true,
                IndentChars = "\t",
                OmitXmlDeclaration = false,
                NewLineHandling = NewLineHandling.None,
            };

            var xmlwriter = XmlWriter.Create(sb, xmlsettings);

            var xamlschema = new XamarinFormsSchemaContext(new XamlSchemaContextSettings());
            var xxwriter = new XamlXmlWriter(xmlwriter, xamlschema);
            XamlServices.Save(xxwriter, instance);
            return sb.ToString();
        }
    }
}