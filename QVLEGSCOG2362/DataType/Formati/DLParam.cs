using System;
using System.ComponentModel;

namespace QVLEGSCOG2362.DataType
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DLParam : IDisposable
    {
        [Browsable(false)]
        [Category("CAT_GENERAL")]
        public bool AbilitaControllo { get; set; }

        [Browsable(false)]
        public int CertaintyThreshold { get; set; }

        public DLParam()
        {
            this.CertaintyThreshold = 95;
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
        ~DLParam()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}