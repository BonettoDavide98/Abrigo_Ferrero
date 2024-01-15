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
        public void AddStaticGraphics(string text, CogColorConstants color, int y, int x)
        {
            AddStaticGraphics(text, color, y, x, 18, true);
        }

        public void AddStaticGraphics(string text, CogColorConstants color, int y, int x, int fontSize)
        {
            AddStaticGraphics(text, color, y, x, fontSize, false);
        }

        public void AddStaticGraphics(string text, CogColorConstants color, int y, int x, int fontSize, bool isStringMessage)
        {
            CogGraphicLabel cgl = new CogGraphicLabel();

            cgl.Text = text;
            cgl.Color = color;
            cgl.Y = (staticGraphics.Count * 60) + y;
            cgl.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;
            cgl.X = x;
            cgl.Font = new System.Drawing.Font("Arial", fontSize);

            AddStaticGraphics(cgl);
        }

        public ObjectToDisplay Clone()
        {
            ObjectToDisplay ret = new ObjectToDisplay();

            try
            {
                if (this.image != null)
                {
                    ret.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));
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
                        if (this.image is IDisposable)
                        {
                            ((IDisposable)this.image).Dispose();
                            this.image = null;

                            DisposeStaticGraphics();
                        }

                    }
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        public void DisposeStaticGraphics()
        {
            //((IDisposable)this.staticGraphics).Dispose();
            this.staticGraphics = null;
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
