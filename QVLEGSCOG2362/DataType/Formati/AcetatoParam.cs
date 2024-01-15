using System;
using System.ComponentModel;

namespace QVLEGSCOG2362.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AcetatoParam : IDisposable
    {

        [Browsable(false)]
        [Category("CAT_GENERAL")]
        public bool WizardCompleto { get; set; }
        [Browsable(false)]
        [Category("CAT_GENERAL")]
        public bool AbilitaControllo { get; set; }

        [Browsable(false)]
        public double DistanzaBordo { get; set; }
        [Browsable(false)]
        public double Threshold { get; set; }
        [Browsable(false)]
        public double AreaMinDifetto { get; set; }

        public AcetatoParam()
        {
            this.DistanzaBordo = 4;
            this.Threshold = 45;
            this.AreaMinDifetto = 2;
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

                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AcetatoParam()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}