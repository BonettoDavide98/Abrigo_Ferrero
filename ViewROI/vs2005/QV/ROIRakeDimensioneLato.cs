using System;
using HalconDotNet;

namespace ViewROI
{
    /// <summary>
    /// This class demonstrates one of the possible implementations for a 
    /// (simple) rectangularly shaped ROI. ROIRectangle1 inherits 
    /// from the base class ROI and implements (besides other auxiliary
    /// methods) all virtual methods defined in ROI.cs.
    /// Since a simple rectangle is defined by two data points, by the upper 
    /// left corner and the lower right corner, we use four values (row1/col1) 
    /// and (row2/col2) as class members to hold these positions at 
    /// any time of the program. The four corners of the rectangle can be taken
    /// as handles, which the user can use to manipulate the size of the ROI. 
    /// Furthermore, we define a midpoint as an additional handle, with which
    /// the user can grab and drag the ROI. Therefore, we declare NumHandles
    /// to be 5 and set the activeHandle to be 0, which will be the upper left
    /// corner of our ROI.
    /// </summary>
    public class ROIRakeDimensioneLato : ROI
    {

        private const int MULT_DISEGNI = 4;

        private double row1, col1;   // upper left
        private double row2, col2;   // lower right 
        private double midR, midC;   // midpoint 

        private double measR, measC;   // punto misura 

        private bool isHor = true;

        /// <summary>Constructor</summary>
        public ROIRakeDimensioneLato(bool isHor)
        {
            this.isHor = isHor;

            NumHandles = 1;
            activeHandleIdx = 0;
        }

        /// <summary>Creates a new ROI instance at the mouse position</summary>
        /// <param name="midX">
        /// x (=column) coordinate for interactive ROI
        /// </param>
        /// <param name="midY">
        /// y (=row) coordinate for interactive ROI
        /// </param>
        public override void createROI(double midX, double midY)
        {
            midR = midY;
            midC = midX;

            measR = midR;
            measC = midC;

            row1 = midR - 50;
            col1 = midC - 50;
            row2 = midR + 50;
            col2 = midC + 50;
        }

        /// <summary>Paints the ROI into the supplied window</summary>
        /// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window)
        {
            window.DispRectangle1(row1, col1, row2, col2);

            double deltaMisura = 100;

            if (isHor)
            {
                window.DispLine(measR, col1 - deltaMisura, measR, col2 + deltaMisura);
                window.DispRectangle2(measR, measC, 0, (col2 - col1 + deltaMisura) / 2.0, 10);
                window.SetColor("red");
                window.DispArrow(measR, col1 - deltaMisura, measR, col1 - deltaMisura / 2.0, 4);
                window.DispArrow(measR, col2 + deltaMisura, measR, col2 + deltaMisura / 2.0, 4);
            }
            else
            {
                window.DispLine(row1 - deltaMisura, measC, row2 + deltaMisura, measC);
                window.DispRectangle2(measR, measC, new HTuple(90).TupleRad().D, (row2 - row1 + deltaMisura) / 2.0, 10);
                window.SetColor("red");
                window.DispArrow(row1 - deltaMisura, measC, row1 - deltaMisura / 2.0, measC, 4);
                window.DispArrow(row2 + deltaMisura, measC, row2 + deltaMisura / 2.0, measC, 4);
            }

            window.DispRectangle2(measR, measC, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
        }

        /// <summary> 
        /// Returns the distance of the ROI handle being
        /// closest to the image point(x,y)
        /// </summary>
        /// <param name="x">x (=column) coordinate</param>
        /// <param name="y">y (=row) coordinate</param>
        /// <returns> 
        /// Distance of the closest ROI handle.
        /// </returns>
        public override double distToClosestHandle(double x, double y)
        {
            double max = 10000;
            double[] val = new double[NumHandles];

            val[0] = HMisc.DistancePp(y, x, measR, measC);

            for (int i = 0; i < NumHandles; i++)
            {
                if (val[i] < max)
                {
                    max = val[i];
                    activeHandleIdx = i;
                }
            }// end of for 

            return val[activeHandleIdx];
        }

        /// <summary> 
        /// Paints the active handle of the ROI object into the supplied window
        /// </summary>
        /// <param name="window">HALCON window</param>
        public override void displayActive(HalconDotNet.HWindow window)
        {
            switch (activeHandleIdx)
            {
                case 0:
                    window.DispRectangle2(measR, measC, 0, 5 * MULT_DISEGNI, 5 * MULT_DISEGNI);
                    break;
            }
        }

        /// <summary>Gets the HALCON region described by the ROI</summary>
        public override HRegion getRegion()
        {
            HRegion region = new HRegion();
            region.GenRectangle1(row1, col1, row2, col2);
            return region;
        }

        /// <summary>
        /// Gets the model information described by 
        /// the interactive ROI
        /// </summary> 
        public override HTuple getModelData()
        {
            return new HTuple(new double[] { row1, col1, row2, col2, isHor ? (measR - midR) : (measC - midC) });
        }

        /// <summary>
        /// Set the model information described by 
        /// the  ROI
        /// </summary> 
        public override void setModelData(HTuple data)
        {
            if (data.DArr.Length >= 5)
            {
                row1 = data.DArr[0];
                col1 = data.DArr[1];
                row2 = data.DArr[2];
                col2 = data.DArr[3];

                double offsetR = isHor ? data.DArr[4] : 0;
                double offsetC = isHor ? 0 : data.DArr[4];

                midR = ((row2 - row1) / 2) + row1;
                midC = ((col2 - col1) / 2) + col1;

                measR = midR + offsetR;
                measC = midC + offsetC;
            }
        }

        /// <summary> 
        /// Recalculates the shape of the ROI instance. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y)
        /// </summary>
        /// <param name="newX">x mouse coordinate</param>
        /// <param name="newY">y mouse coordinate</param>
        public override void moveByHandle(double newX, double newY)
        {
            //double len1, len2;
            //double tmp;

            switch (activeHandleIdx)
            {
                case 0:
                    if (isHor)
                        measR = newY;
                    else
                        measC = newX;

                    break;
            }

        }//end of method

    }//end of class
}//end of namespace
