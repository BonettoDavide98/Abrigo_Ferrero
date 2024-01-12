using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace QVLEGSCOG2362.DataType
{
    public static class Extension
    {

        public static T Clone<T>(this T a)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }

        public static void ToBinaryFile<T>(this T o, string path) where T : class
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, o);
            }
        }

        public static T FromBinaryFile<T>(string path) where T : class
        {
            T o = default(T);
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                o = (T)bf.Deserialize(fileStream);
            }
            return o;
        }

        public static void ToXmlFile<T>(this T istanza, string fileName) where T : class
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, istanza);
            myWriter.Close();
        }

        public static T FromXmlFile<T>(string fileName) where T : class
        {
            if (File.Exists(fileName))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(T));
                FileStream myFileStream;
                myFileStream = new FileStream(fileName, FileMode.Open);
                T obj = (T)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                return obj;
            }
            else
            {
                return default(T);
            }
        }

        public static string SerializeAsString<T>(T obj)
        {
            StringWriter ret = new StringWriter();
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            xmlSer.Serialize(ret, obj);
            return ret.ToString();
        }

        public static T DeSerializeStringAsT<T>(string xml)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            return (T)xmlSer.Deserialize(new StringReader(xml));
        }

    }
}