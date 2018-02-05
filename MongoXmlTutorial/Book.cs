using MongoDB.Bson;
using System;
using System.Xml.Serialization;

namespace MongoXmlTutorial
{
    [XmlRoot("book")]
    public class Book
    {
        [XmlIgnore]
        public ObjectId Id { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; }

        [XmlElement("price")]
        public float Price { get; set; }

        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
    }
}
