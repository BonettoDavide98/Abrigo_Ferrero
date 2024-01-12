using System;
using HalconDotNet;
using System.Drawing;

namespace ViewROI
{

    /// <summary>
    /// This class implements an ROI shaped as a circular
    /// arc. ROICircularArc inherits from the base class ROI and 
    /// implements (besides other auxiliary methods) all virtual methods 
    /// defined in ROI.cs.
    /// </summary>
    public class ROICircularArc3 : ROI
    {
        //handles
        private double midR, midC;                  // 0. handle: midpoint
        private double sizeR, sizeC;                // 1. handle        
        private double startR, startC;              // 2. handle
        private double extentR, extentC;            // 3. handle
        private double sizeLittleR, sizeLittleC;    // 4. handle

        //model data to specify the arc
        private double radius, radiusLittle;
        private double startPhi, extentPhi; // -2*PI <= x <= 2*PI

        //display attributes
        private HXLDCont contour, contourLittle;
        private string circDir;
        private double TwoPI;
        private double PI;


        public ROICircularArc3()
        {
            NumHandles = 5;         // midpoint handle + three handles on the arc
            activeHandleIdx = 0;
            contour = new HXLDCont();
            contourLittle = new HXLDCont();

            circDir = "";

            TwoPI = 2 * Math.PI;
            PI = Math.PI;
        }

        /// <summary>Creates a new ROI instance at the mouse position</summary>
        public override void createROI(double midX, double midY)
        {
            midR = midY;
            midC = midX;

            radius = 100;
            radiusLittle = radius / 2;

            sizeR = midR;
            sizeC = midC - radius;

            sizeLittleR = midR;
            sizeLittleC = midC - radiusLittle;

            startPhi = PI * 0.25;
            extentPhi = PI * 1.5;
            circDir = "positive";

            determineArcHandles();
        }

        /// <summary>Paints the ROI into the supplied window</summary>
        /// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window)
        {
            try
            {
                contour.Dispose();
                contour.GenCircleContourXld(midR, midC, radius, startPhi, (startPhi + extentPhi), circDir, 1.0);
                window.DispObj(contour);

                contourLittle.Dispose();
                contourLittle.GenCircleContourXld(midR, midC, radiusLittle, startPhi, (startPhi + extentPhi), circDir, 1.0);
                window.DispObj(contourLittle);

                PointF p1 = FindPointOnLineAtGivenDistance(new PointF((float)midC, (float)midR), new PointF((float)startC, (float)startR), (float)radiusLittle);
                PointF p2 = FindPointOnLineAtGivenDistance(new PointF((float)midC, (float)midR), new PointF((float)extentC, (float)extentR), (float)radiusLittle);

                window.DispLine(startR, startC, p1.Y, p1.X);
                window.DispLine(extentR, extentC, p2.Y, p2.X);

                window.DispRectangle2(sizeR, sizeC, 0, 5, 5);
                window.DispRectangle2(sizeLittleR, sizeLittleC, 0, 5, 5);

                window.DispRectangle2(startR, startC, startPhi, 10, 2);
                window.DispRectangle2(extentR, extentC, startPhi + extentPhi, 10, 2);

                if (midR > 0 && midC > 0)
                    window.DispRectangle2(midR, midC, 0, 5, 5);
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }
        }

        /// <summary> 
        /// Returns the distance of the ROI handle being
        /// closest to the image point(x,y)
        /// </summary>
        public override double distToClosestHandle(double x, double y)
        {
            double max = 10000;
            double[] val = new double[NumHandles];

            val[0] = HMisc.DistancePp(y, x, midR, midC);                // midpoint 
            val[1] = HMisc.DistancePp(y, x, sizeR, sizeC);              // border handle 
            val[2] = HMisc.DistancePp(y, x, startR, startC);            // border handle 
            val[3] = HMisc.DistancePp(y, x, extentR, extentC);          // border handle 
            val[4] = HMisc.DistancePp(y, x, sizeLittleR, sizeLittleC);  // border handle 

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
        public override void displayActive(HalconDotNet.HWindow window)
        {
            switch (activeHandleIdx)
            {
                case 0:
                    window.DispRectangle2(midR, midC, 0, 5, 5);
                    break;
                case 1:
                    window.DispRectangle2(sizeR, sizeC, 0, 5, 5);
                    break;
                case 2:
                    window.DispRectangle2(startR, startC, startPhi, 10, 2);
                    break;
                case 3:
                    window.DispRectangle2(extentR, extentC, startPhi + extentPhi, 10, 2);
                    break;
                case 4:
                    window.DispRectangle2(sizeLittleR, sizeLittleC, 0, 5, 5);
                    break;
            }
        }

        /// <summary> 
        /// Recalculates the shape of the ROI. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y)
        /// </summary>
        public override void moveByHandle(double newX, double newY)
        { 
            double dirX, dirY, prior, next, valMax, valMin;

            PointF c;
            float r;

            switch (activeHandleIdx)
            {
                case 0: // midpoint 
                    #region Centro cerchio
                    dirY = midR - newY;
                    dirX = midC - newX;

                    midR = newY;
                    midC = newX;

                    sizeR -= dirY;
                    sizeC -= dirX;

                    sizeLittleR -= dirY;
                    sizeLittleC -= dirX;

                    determineArcHandles();
                    #endregion
                    break;

                case 1: // handle at circle border                  
                    #region Centro arco
                    sizeR = newY;
                    sizeC = newX;

                    FindCircle(new PointF((float)sizeC, (float)sizeR), new PointF((float)startC, (float)startR), new PointF((float)extentC, (float)extentR), out c, out r);

                    radius = r;
                    midR = c.Y;
                    midC = c.X;

                    startPhi = Math.Atan2(-(startR - c.Y), startC - c.X);

                    if (startPhi < 0)
                        startPhi = PI + (startPhi + PI);

                    prior = extentPhi;
                    extentPhi = HMisc.AngleLl(midR, midC, startR, startC, midR, midC, extentR, extentC);

                    if (extentPhi < 0 && prior > PI * 0.8)
                        extentPhi = (PI + extentPhi) + PI;
                    else if (extentPhi > 0 && prior < -PI * 0.7)
                        extentPhi = -PI - (PI - extentPhi);

                    radiusLittle = HMisc.DistancePp(midR, midC, sizeLittleR, sizeLittleC);

                    #endregion
                    break;

                case 2: // start handle for arc                
                    #region Inizio arco grande
                    startR = newY;
                    startC = newX;

                    FindCircle(new PointF((float)sizeC, (float)sizeR), new PointF((float)startC, (float)startR), new PointF((float)extentC, (float)extentR), out c, out r);

                    radius = r;
                    midR = c.Y;
                    midC = c.X;

                    startPhi = Math.Atan2(-(startR - c.Y), startC - c.X);

                    if (startPhi < 0)
                        startPhi = PI + (startPhi + PI);

                    prior = extentPhi;
                    extentPhi = HMisc.AngleLl(midR, midC, startR, startC, midR, midC, extentR, extentC);

                    if (extentPhi < 0 && prior > PI * 0.8)
                        extentPhi = (PI + extentPhi) + PI;
                    else if (extentPhi > 0 && prior < -PI * 0.7)
                        extentPhi = -PI - (PI - extentPhi);

                    radiusLittle = HMisc.DistancePp(midR, midC, sizeLittleR, sizeLittleC);

                    #endregion
                    break;

                case 3: // end handle for arc
                    #region Fine arco grande
                    extentR = newY;
                    extentC = newX;

                    FindCircle(new PointF((float)sizeC, (float)sizeR), new PointF((float)startC, (float)startR), new PointF((float)extentC, (float)extentR), out c, out r);

                    radius = r;
                    midR = c.Y;
                    midC = c.X;

                    startPhi = Math.Atan2(-(startR - c.Y), startC - c.X);

                    if (startPhi < 0)
                        startPhi = PI + (startPhi + PI);

                    prior = extentPhi;
                    next = Math.Atan2(-(extentR - c.Y), extentC - c.X);

                    if (next < 0)
                        next = PI + (next + PI);

                    if (circDir == "positive" && startPhi >= next)
                        extentPhi = (next + TwoPI) - startPhi;
                    else if (circDir == "positive" && next > startPhi)
                        extentPhi = next - startPhi;
                    else if (circDir == "negative" && startPhi >= next)
                        extentPhi = -1.0 * (startPhi - next);
                    else if (circDir == "negative" && next > startPhi)
                        extentPhi = -1.0 * (startPhi + TwoPI - next);

                    valMax = Math.Max(Math.Abs(prior), Math.Abs(extentPhi));
                    valMin = Math.Min(Math.Abs(prior), Math.Abs(extentPhi));

                    if ((valMax - valMin) >= PI)
                        extentPhi = (circDir == "positive") ? -1.0 * valMin : valMin;

                    radiusLittle = HMisc.DistancePp(midR, midC, sizeLittleR, sizeLittleC);

                    #endregion
                    break;

                case 4:
                    #region Punto arco piccolo
                    sizeLittleR = newY;
                    sizeLittleC = newX;

                    radiusLittle = HMisc.DistancePp(midR, midC, sizeLittleR, sizeLittleC);

                    #endregion
                    break;
            }

            circDir = (extentPhi < 0) ? "negative" : "positive";
        }

        /// <summary>
        /// Gets the HALCON region described by the ROI
        /// </summary>
        public override HRegion getRegion()
        {
            HRegion region;

            contour.Dispose();
            contour.GenCircleContourXld(midR, midC, radius, startPhi, (startPhi + extentPhi), circDir, 1.0);
            contourLittle.Dispose();
            contourLittle.GenCircleContourXld(midR, midC, radiusLittle, startPhi, (startPhi + extentPhi), circDir, 1.0);

            PointF p1 = FindPointOnLineAtGivenDistance(new PointF((float)midC, (float)midR), new PointF((float)startC, (float)startR), (float)radiusLittle);
            PointF p2 = FindPointOnLineAtGivenDistance(new PointF((float)midC, (float)midR), new PointF((float)extentC, (float)extentR), (float)radiusLittle);

            //window.DispLine(startR, startC, p1.Y, p1.X);
            //window.DispLine(extentR, extentC, p2.Y, p2.X);

            HXLDCont contLine = new HXLDCont();
            contLine.GenContourPolygonXld(new HTuple(startR, p1.Y), new HTuple(startC, p1.X));

            HXLDCont ret = contour.ConcatObj(contLine);
            contLine.GenContourPolygonXld(new HTuple(extentR, p2.Y), new HTuple(extentC, p2.X));
            ret = ret.ConcatObj(contourLittle);
            ret = ret.ConcatObj(contLine);

            ret = ret.UnionAdjacentContoursXld(10, 1, "attr_keep");

            region = ret.GenRegionContourXld("filled");
            return region;
        }

        /// <summary>
        /// Gets the model information described by the ROI
        /// </summary> 
        public override HTuple getModelData()
        {
            return new HTuple(new double[] { midR, midC, radius, startPhi, extentPhi });
        }

        /// <summary>
        /// Auxiliary method to determine the positions of the second and
        /// third handle.
        /// </summary>
        private void determineArcHandles()
        {
            setStartHandle();
            setExtentHandle();
        }

        /// <summary> 
        /// Auxiliary method to recalculate the start handle for the arc 
        /// </summary>
        private void setStartHandle()
        {
            startR = midR - radius * Math.Sin(startPhi);
            startC = midC + radius * Math.Cos(startPhi);
        }

        /// <summary>
        /// Auxiliary method to recalculate the extent handle for the arc
        /// </summary>
        private void setExtentHandle()
        {
            extentR = midR - radius * Math.Sin(startPhi + extentPhi);
            extentC = midC + radius * Math.Cos(startPhi + extentPhi);
        }






        /// <summary>
        /// Find a circle through the three points.
        /// </summary>
        private void FindCircle(PointF a, PointF b, PointF c, out PointF center, out float radius)
        {
            // Get the perpendicular bisector of (x1, y1) and (x2, y2).
            float x1 = (b.X + a.X) / 2;
            float y1 = (b.Y + a.Y) / 2;
            float dy1 = b.X - a.X;
            float dx1 = -(b.Y - a.Y);

            // Get the perpendicular bisector of (x2, y2) and (x3, y3).
            float x2 = (c.X + b.X) / 2;
            float y2 = (c.Y + b.Y) / 2;
            float dy2 = c.X - b.X;
            float dx2 = -(c.Y - b.Y);

            // See where the lines intersect.
            bool lines_intersect, segments_intersect;
            PointF intersection, close1, close2;

            FindIntersection(new PointF(x1, y1), new PointF(x1 + dx1, y1 + dy1), new PointF(x2, y2), new PointF(x2 + dx2, y2 + dy2), out lines_intersect, out segments_intersect, out intersection, out close1, out close2);

            if (!lines_intersect)
            {
                center = new PointF(0, 0);
                radius = 0;
            }
            else
            {
                center = intersection;
                float dx = center.X - a.X;
                float dy = center.Y - a.Y;
                radius = (float)Math.Sqrt(dx * dx + dy * dy);
            }
        }

        /// <summary>
        /// Find the point of intersection between the lines p1 --> p2 and p3 --> p4.
        /// </summary>      
        private void FindIntersection(PointF p1, PointF p2, PointF p3, PointF p4, out bool lines_intersect, out bool segments_intersect, out PointF intersection, out PointF close_p1, out PointF close_p2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;

            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                return;
            }

            lines_intersect = true;

            float t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }

        /// <summary>
        /// Find the poin on a line at a given distance
        /// </summary>
        private PointF FindPointOnLineAtGivenDistance(PointF a, PointF b, float distance)
        {

            // a. calculate the vector from o to g:
            float vectorX = b.X - a.X;
            float vectorY = b.Y - a.Y;

            // b. calculate the proportion of hypotenuse
            float factor = distance / (float)Math.Sqrt(vectorX * vectorX + vectorY * vectorY);

            // c. factor the lengths
            vectorX *= factor;
            vectorY *= factor;

            // d. calculate and Draw the new vector,
            return new PointF((a.X + vectorX), (a.Y + vectorY));
        }


    }//end of class
}//end of namespace

