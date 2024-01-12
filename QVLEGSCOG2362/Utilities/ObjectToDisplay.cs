using Cognex.VisionPro;
using System;
using System.Collections.Generic;

namespace QVLEGSCOG2362.Utilities
{
    public class ObjectToDisplay : IDisposable
    {

        private bool disposed = false; // to detect redundant calls

        private List<ICogGraphic> staticGraphics = null;
        private ICogImage image = null;

        public ObjectToDisplay()
        {
            staticGraphics = new List<ICogGraphic>();
        }
        public ObjectToDisplay(ICogImage image)
        {
            this.image = image;
            staticGraphics = new List<ICogGraphic>();
        }

        public void SetImage(ICogImage image)
        {
            this.image = image;
        }

        public ICogImage GetImage()
        {
            return image;
        }

        public void SetStaticGraphics(List<ICogGraphic> staticGraphics)
        {
            this.staticGraphics = staticGraphics;
        }

        public List<ICogGraphic> GetStaticGraphics()
        {
            return staticGraphics;
        }

        public void AddStaticGraphics(ICogGraphic cogGraphic)
        {
            staticGraphics.Add(cogGraphic);
        }

        public ObjectToDisplay Clone()
        {
            ObjectToDisplay ret = new ObjectToDisplay();

            try
            {
                if (this.image != null)
                {
                    ret.SetImage(this.image);
                }

                if (this.staticGraphics != null)
                {
                    ret.SetStaticGraphics(this.staticGraphics);
                }
            }
            catch (Exception) { }

            return ret;
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

                    if (this.image != null)
                    {
                        //this.IconicVar.Dispose();
                        this.image = null;
                    }
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~ObjectToDisplay()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

        #endregion IDisposable

    }
}
