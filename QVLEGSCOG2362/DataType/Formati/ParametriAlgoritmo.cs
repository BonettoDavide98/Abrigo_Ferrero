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
        public bool WizardDLCompleto { get; set; }

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
        public DLParam DLParam { get; set; }

        public ParametriAlgoritmo()
        {
            this.Expo = 1000;
            this.Gain = 1;

            this.AcetatoParam = new AcetatoParam();

            this.DLParam = new DLParam();
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