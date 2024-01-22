using Cognex.VisionPro;
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

        [Browsable(false)]
        public double RettangoloWidth { get; set; }
        [Browsable(false)]
        public double RettangoloHeight { get; set; }
        [Browsable(false)]
        public double CellWidth { get; set; }
        [Browsable(false)]
        public double CellHeight { get; set; }
        [Browsable(false)]
        public double OffsetX { get; set; }
        [Browsable(false)]
        public double OffsetY { get; set; }
        [Browsable(false)]
        public int Rows { get; set; }
        [Browsable(false)]
        public int Columns { get; set; }

        public DLParam()
        {
            this.CertaintyThreshold = 95;

            this.RettangoloWidth = 815;
            this.RettangoloHeight = 594;
            this.CellWidth = 163;
            this.CellHeight = 198;
            this.OffsetX = 25;
            this.OffsetY = 15;
            this.Rows = 3;
            this.Columns = 5;
        }

        public void SetRectangle(CogRectangle rectangle, int rows, int columns)
        {
            this.RettangoloWidth = rectangle.Width;
            this.RettangoloHeight = rectangle.Height;
            this.CellWidth = rectangle.Width / columns;
            this.CellHeight = rectangle.Height / rows;
            this.OffsetX = rectangle.X;
            this.OffsetY = rectangle.Y;
            this.Rows = rows;
            this.Columns = columns;
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