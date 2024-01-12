using Cognex.VisionPro;
using System.Collections;
using System.Xml.Serialization;

namespace QVLEGSCOG2362.DataType
{
    public class FrameGrabberConfig
    {

        public FrameGrabberConfig()
        {
            ParamList = new ArrayList();
        }

        public string Name { get; set; }
        public int Horizzontal_resolution { get; set; }
        public int Vertical_resolution { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public string Field { get; set; }
        public CogAcqFifoPixelFormatConstants pixelFormatConstants { get; set; }
        public int BitsPerChannel { get; set; }
        public string ColorSpace { get; set; }
        public int Generic { get; set; }
        public string ExternalTrigger { get; set; }
        public string CameraType { get; set; }
        public string Device { get; set; }
        public int Port { get; set; }
        public int LineIn { get; set; }
        [XmlArrayItem(typeof(FrameGrabberParam))]
        public ArrayList ParamList { get; set; }

    }
}
