using System;
using System.IO;
using System.Xml.Serialization;

namespace Epam.ListUsers.DAL.XMLFiles
{
    internal class Serializer<T>
    {
        static public DateTime TimeOfLastDeserialization { get; private set; }

        static public void SerializeTo(string nameFile, T entities)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(nameFile);
            xmlSerializer.Serialize(writer, entities);
            writer.Close();
        }

        static public void DeserializeTo(string nameFile, ref T entities)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(nameFile, FileMode.Open);
            entities = (T)xmlSerializer.Deserialize(fs);
            fs.Close();
            TimeOfLastDeserialization = DateTime.Now;
        }
    }
}