using System.Collections.Generic;
using System.Xml.Serialization;

namespace MongoXmlTutorial
{
    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}
