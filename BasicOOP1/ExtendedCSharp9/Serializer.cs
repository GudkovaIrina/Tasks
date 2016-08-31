using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExtendedCSharp9
{
    class Serializer
    {
        static public void SerializeTo(string nameFile, LogItems logItems)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LogItems));
            TextWriter writer = new StreamWriter(nameFile);
            xmlSerializer.Serialize(writer, logItems);
            writer.Close();
        }

        static public void DeserializeTo(string nameFile, ref LogItems logItems)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LogItems));
            FileStream fs = new FileStream(nameFile, FileMode.Open);
            logItems = (LogItems)xmlSerializer.Deserialize(fs);
            fs.Close();
        }
    }
}
