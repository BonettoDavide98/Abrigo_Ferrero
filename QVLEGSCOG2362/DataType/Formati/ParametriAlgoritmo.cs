using Cognex.VisionPro;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace QVLEGSCOG2362.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ParametriAlgoritmo : IDisposable
    {

        [Browsable(false)]
        public string IdFormato { get; set; }

        [Browsable(false)]
        public string TemplateName { get; set; }
        [Browsable(false)]
        public TemplateFormato Template { get; set; }

        [Browsable(false)]
        public bool WizardAcqCompleto { get; set; }
        [Browsable(false)]
        public bool WizardAcetatoCompleto { get; set; }

        [Browsable(false)]
        public double Expo { get; set; }
        [Browsable(false)]
        public double Gain { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public ICogImage ImageRef { get; set; }

        //[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        //[XmlElement("ImageRef")]
        //public byte[] ImageRefSerialized
        //{
        //    get
        //    {
        //        // serialize
        //        if (this.ImageRef == null)
        //            return null;
        //        else
        //            return this.ImageRef.SerializeImage();
        //    }
        //    set
        //    {
        //        // deserialize
        //        if (value == null)
        //        {
        //            this.ImageRef = null;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                this.ImageRef = new ICogImage();
        //                this.ImageRef.DeserializeImage(new HalconDotNet.HSerializedItem(value));
        //            }
        //            catch (Exception) { }
        //        }
        //    }
        //}

        //[Browsable(false)]
        //public Rectangle1Param RoiMain { get; set; }
        [Browsable(false)]
        public AcetatoParam AcetatoParam { get; set; }

        [Browsable(false)]
        public double AltezzaRoiSfondo { get; set; }
        [Browsable(false)]
        public int RigheVaschettaSegmentazione { get; set; }
        [Browsable(false)]
        public int ColonneVaschettaSegmentazione { get; set; }
        [Browsable(false)]
        public double AreaMinSegmentazione { get; set; }
        [Browsable(false)]
        public double AreaMaxSegmentazione { get; set; }

        [Browsable(false)]
        public int ThresholdMinBiscotto { get; set; }
        [Browsable(false)]
        public int ThresholdMaxBiscotto { get; set; }
        [Browsable(false)]
        public double DimensioneFiltroCioccolato { get; set; }
        [Browsable(false)]
        public double DistanzaBordo { get; set; }
        [Browsable(false)]
        public double AreaMinCioccolato { get; set; }

        public bool SegmentaSfondoHSV { get; set; }
        public double ThresholdMinHSV { get; set; }
        public double ThresholdMaxHSV { get; set; }


        public ParametriAlgoritmo()
        {
            this.Expo = 1000;
            this.Gain = 1;

            this.AcetatoParam = new AcetatoParam();

            this.RigheVaschettaSegmentazione = 1;
            this.ColonneVaschettaSegmentazione = 1;
            this.AreaMinSegmentazione = 170000;
            this.AreaMaxSegmentazione = 2000000;

            this.ThresholdMinBiscotto = 40;
            this.ThresholdMaxBiscotto = 255;
            this.DimensioneFiltroCioccolato = 20;
            this.AreaMinCioccolato = 1;

            this.SegmentaSfondoHSV = false;
            this.ThresholdMinHSV = 50;
            this.ThresholdMaxHSV = 170;
        }

        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                    
                    ((IDisposable)this.ImageRef)?.Dispose();
                    this.ImageRef = null;


                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~ParametriAlgoritmo()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}