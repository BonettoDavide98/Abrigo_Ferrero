using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace QVLEGSCOG2362.DataType
{
    [Serializable]
    public class FrameGrabberConfigOverride
    {

        public FrameGrabberConfigOverride()
        {
            ParamList = new ArrayList();
        }

        [XmlArrayItem(typeof(FrameGrabberParam))]
        public ArrayList ParamList { get; set; }

        public static void Serialize(FrameGrabberConfigOverride obj, string file)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FrameGrabberConfigOverride));

                using (TextWriter writer = new StreamWriter(file))
                {
                    serializer.Serialize(writer, obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static FrameGrabberConfigOverride Deserialize(string file)
        {
            try
            {
                FrameGrabberConfigOverride obj = null;
                XmlSerializer serializer = new XmlSerializer(typeof(FrameGrabberConfigOverride));
                if (File.Exists(file))
                {
                    using (TextReader reader = new StreamReader(file))
                    {

                        obj = (FrameGrabberConfigOverride)serializer.Deserialize(reader);

                    }
                }
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}