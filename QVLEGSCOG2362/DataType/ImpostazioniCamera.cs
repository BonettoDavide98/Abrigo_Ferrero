using System;
using System.ComponentModel;

namespace QVLEGSCOG2362.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ImpostazioniCamera
    {

        public TipoCamera TipoCamera { get; set; }

        public string IpCamera { get; set; }
        public string PathImmaginiDaCamera { get; set; }

        public double FiltroMinArea { get; set; }
        public double KConvPX_mm { get; set; }

        public double KConvPX_mm_W { get; set; }
        public double KConvPX_mm_H { get; set; }

        public double ScaleWidth { get; set; }
        public double ScaleHeight { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }

        public int IdStazione { get; set; }
        public bool Attiva { get; set; }

        public double ThresholdMaxSfondo { get; set; }

        public double CorrezioneAngolo { get; set; }

        public ImpostazioniCamera()
        {
            this.TipoCamera = TipoCamera.Acetato;

            this.FiltroMinArea = 200;
            this.KConvPX_mm = 1;

            this.KConvPX_mm_W = 1;
            this.KConvPX_mm_H = 1;

            this.ScaleWidth = 1.0;
            this.ScaleHeight = 1.0;

            this.Width = 1280;
            this.Height = 1024;
            this.OffsetX = 0;
            this.OffsetY = 0;

            //this.AreaMinSegmentazione = 70000;
            //this.AreaMaxSegmentazione = 2000000;
            this.ThresholdMaxSfondo = 45;

            this.Attiva = true;
        }

    }
}