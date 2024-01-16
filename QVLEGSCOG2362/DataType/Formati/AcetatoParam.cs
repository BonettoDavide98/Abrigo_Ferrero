using Cognex.VisionPro;
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
        public bool AbilitaControllo { get; set; }

        [Browsable(false)]
        public int DistanzaBordo { get; set; }
        [Browsable(false)]
        public int Threshold { get; set; }
        [Browsable(false)]
        public int AreaMinDifetto { get; set; }
        [Browsable(false)]
        public double RettangoloSXWidth { get; set; }
        [Browsable(false)]
        public double RettangoloSXHeight { get; set; }
        [Browsable(false)]
        public double RettangoloSXX { get; set; }
        [Browsable(false)]
        public double RettangoloSXY { get; set; }
        [Browsable(false)]
        public double RettangoloDXWidth { get; set; }
        [Browsable(false)]
        public double RettangoloDXHeight { get; set; }
        [Browsable(false)]
        public double RettangoloDXX { get; set; }
        [Browsable(false)]
        public double RettangoloDXY { get; set; }

        public AcetatoParam()
        {
            this.DistanzaBordo = 4;
            this.Threshold = 100;
            this.AreaMinDifetto = 200;

            this.RettangoloSXWidth = 600;
            this.RettangoloSXHeight = 600;
            this.RettangoloSXX = 0;
            this.RettangoloSXY = 0;

            this.RettangoloDXWidth = 600;
            this.RettangoloDXHeight = 600;
            this.RettangoloDXX = 600;
            this.RettangoloDXY = 0;
        }

        public void SetRectangleSX(CogRectangle rectangle)
        {
            this.RettangoloSXWidth = rectangle.Width;
            this.RettangoloSXHeight = rectangle.Height;
            this.RettangoloSXX = rectangle.X;
            this.RettangoloSXY = rectangle.Y;
        }

        public void SetRectangleDX(CogRectangle rectangle)
        {
            this.RettangoloDXWidth = rectangle.Width;
            this.RettangoloDXHeight = rectangle.Height;
            this.RettangoloDXX = rectangle.X;
            this.RettangoloDXY = rectangle.Y;
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