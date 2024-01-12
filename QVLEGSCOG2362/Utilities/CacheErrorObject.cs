using QVLEGSCOG2362.DataType;
using System;
using System.Collections;

namespace QVLEGSCOG2362.Utilities
{
    public class CacheErrorObject : IDisposable
    {

        private bool disposed = false; // to detect redundant calls

        public DateTime TimeStamp { get; private set; }
        public Utilities.ObjectToDisplay IconicVar { get; set; }
        public ElaborateResult ElaborateResult { get; set; }

        public CacheErrorObject(Utilities.ObjectToDisplay iconicVar, ElaborateResult elaborateResult) : this(iconicVar, elaborateResult, DateTime.Now) { }

        public CacheErrorObject(Utilities.ObjectToDisplay iconicVar, ElaborateResult elaborateResult, DateTime timeStamp)
        {
            this.TimeStamp = timeStamp;
            this.ElaborateResult = elaborateResult;

            this.IconicVar = iconicVar.Clone();
        }

        public CacheErrorObject Clona()
        {
            return (CacheErrorObject)this.MemberwiseClone();
        }

        #region IDisposable

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
                    this.IconicVar?.Dispose();
                    this.IconicVar = null;

                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~CacheErrorObject()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion IDisposable

    }
}