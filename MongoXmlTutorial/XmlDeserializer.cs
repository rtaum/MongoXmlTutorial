using System.IO;
using System.Xml.Serialization;

namespace MongoXmlTutorial
{
    public class XmlDeserializer
    {
        public static T Deserialize<T>(string objectData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(objectData))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
