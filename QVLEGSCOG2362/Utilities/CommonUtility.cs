using Cognex.VisionPro;
using QVLEGSCOG2362.DataType;
using System;
using System.Collections;
using System.Globalization;

namespace QVLEGSCOG2362.Utilities
{
    public static class CommonUtility
    {

        private static string timeElaborationPattern = "T. analisi: {0} ms";

        public static bool TryParseDouble(string sValue, out double value)
        {
            value = 0;
            try
            {
                bool bDecimal = false;
                bool bRet = false;
                string sDummy = sValue;
                char a = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                if ((sDummy.IndexOf(a) >= 0) || (sDummy.IndexOf('.') >= 0))
                {
                    bDecimal = true;
                    sDummy = sDummy.Replace(a, '.');
                }

                double retValue = 0.0;
                if (bDecimal)
                {
                    retValue = double.Parse(sDummy, System.Globalization.CultureInfo.InvariantCulture);
                    bRet = true;
                }

                value = retValue;
                return bRet;
            }
            catch (Exception) { }
            return false;
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static void ClearArrayList(ArrayList arr)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] != null)
                    {
                        ((Utilities.ObjectToDisplay)arr[i]).Dispose();
                        arr[i] = null;
                    }
                }
            }
        }

        public static void ClearArrayList(Utilities.ObjectToDisplay arr)
        {
            if (arr != null)
            {
                for (int i = 0; i < arr.GetStaticGraphics().Count; i++)
                {
                    if (arr.GetStaticGraphics()[i] != null)
                    {
                        //TODO :
                        //(arr.GetStaticGraphics()[i]).Dispose();
                        arr.GetStaticGraphics()[i] = null;
                    }
                }
            }
        }

        public static ArrayList CloneArrayList(ArrayList arr)
        {
            ArrayList ret = null;
            if (arr != null)
            {
                ret = new ArrayList();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] != null)
                    {
                        ret.Add(((Utilities.ObjectToDisplay)arr[i]).Clone());
                    }
                }
            }
            return ret;
        }

        //public static void DisplayResult(ElaborateResult result, HWindowControl hWndCntrl, object repaintLock)
        //{
        //    lock (repaintLock)
        //    {
        //        double ratio = (double)hWndCntrl.ImagePart.Height / (double)hWndCntrl.Height;

        //        hWndCntrl.HalconWindow.SetColor("yellow");
        //        hWndCntrl.HalconWindow.SetTposition((int)(hWndCntrl.ImagePart.Height - 20 * ratio), 10);

        //        string dummy = string.Format(timeElaborationPattern, result.ElapsedTime.ToString("F1", CultureInfo.InvariantCulture));

        //        if (result.InTimeout)
        //        {
        //            dummy = string.Format("{0} TIMEOUT", dummy);
        //        }

        //        hWndCntrl.HalconWindow.SetFont("Arial-Bold-16");
        //        hWndCntrl.HalconWindow.WriteString(dummy);
        //        hWndCntrl.HalconWindow.SetDraw("margin");
        //    }
        //}

        //public static void DisplayRegolazioni(ArrayList dipObjList, HWndCtrl mView, HWindowControl hWndCntrl, object repaintLock)
        //{
        //    if (dipObjList != null && dipObjList.Count > 0)
        //    {
        //        lock (repaintLock)
        //        {

        //            mView.clearList();
        //            mView.changeGraphicSettings(GraphicsContext.GC_LINESTYLE, new HTuple());

        //            for (int i = 0; i < dipObjList.Count; i++)
        //            {

        //                ObjectToDisplay obj = (ObjectToDisplay)dipObjList[i];
        //                HObject iconicVar = obj.IconicVar;
        //                try
        //                {
        //                    if (iconicVar != null)
        //                    {
        //                        if (!(iconicVar is ICogImage))
        //                        {
        //                            mView.changeGraphicSettings(GraphicsContext.GC_DRAWMODE, obj.DrawMode);
        //                            if (int.TryParse(obj.IconicColor, out int tmp))
        //                                mView.changeGraphicSettings(GraphicsContext.GC_COLORED, tmp);
        //                            else
        //                                mView.changeGraphicSettings(GraphicsContext.GC_COLOR, obj.IconicColor);
        //                            mView.changeGraphicSettings(GraphicsContext.GC_LINEWIDTH, obj.IconicLineWidth);
        //                        }

        //                        // chiamare dopo changeGraphicSettings
        //                        mView.addIconicVar(iconicVar);
        //                    }
        //                    else if (obj.StrToDisplay.Length > 0)
        //                    {
        //                        if ((mView.ShowStringMessage && obj.IsStringMessage) || !obj.IsStringMessage)
        //                        {
        //                            HTextEntry entry = new HTextEntry(string.Format("Arial-Bold-{0}", obj.FontSize), obj.Row, obj.Column, obj.IconicColor, obj.StrToDisplay);
        //                            mView.addTextVar(entry);
        //                        }

        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine("Eccezione RegolazioniCtrlInspect DisplayRegolazioniInspect");
        //                    Console.WriteLine(ex.Message);
        //                }
        //            }

        //            mView.repaint();

        //            /*
        //            for (int i = 0; i < dipObjList.Count; i++)
        //            {
        //                ObjectToDisplay obj = (ObjectToDisplay)dipObjList[i];
        //                if (obj.IconicVar != null)
        //                {
        //                    //obj.IconicVar.Dispose();
        //                }
        //                else
        //                {
        //                    if (obj.StrToDisplay.Length > 0)
        //                    {
        //                        hWndCntrl.HalconWindow.SetFont(string.Format("Arial-Bold-{0}", obj.FontSize));
        //                        hWndCntrl.HalconWindow.SetTposition(obj.Row, obj.Column);
        //                        hWndCntrl.HalconWindow.SetColor(obj.IconicColor);
        //                        hWndCntrl.HalconWindow.WriteString(obj.StrToDisplay);
        //                    }
        //                    else
        //                    {
        //                        switch (obj.DispObjectType)
        //                        {
        //                            case "Line":
        //                                hWndCntrl.HalconWindow.SetColor(obj.IconicColor);
        //                                hWndCntrl.HalconWindow.SetLineWidth(obj.IconicLineWidth);
        //                                hWndCntrl.HalconWindow.DispLine(obj.DispObject.DArr[0], obj.DispObject.DArr[1], obj.DispObject.DArr[2], obj.DispObject.DArr[3]);
        //                                break;
        //                            case "Cross":
        //                                hWndCntrl.HalconWindow.SetColor(obj.IconicColor);
        //                                hWndCntrl.HalconWindow.SetLineWidth(obj.IconicLineWidth);
        //                                hWndCntrl.HalconWindow.DispCross(obj.DispObject.DArr[0], obj.DispObject.DArr[1], obj.DispObject.DArr[2], obj.DispObject.DArr[3]);
        //                                break;
        //                            case "Rectangle1":
        //                                hWndCntrl.HalconWindow.SetColor(obj.IconicColor);
        //                                hWndCntrl.HalconWindow.SetLineWidth(obj.IconicLineWidth);
        //                                hWndCntrl.HalconWindow.DispRectangle1(obj.DispObject.DArr[0], obj.DispObject.DArr[1], obj.DispObject.DArr[2], obj.DispObject.DArr[3]);
        //                                break;
        //                            case "Rectangle2":
        //                                hWndCntrl.HalconWindow.SetColor(obj.IconicColor);
        //                                hWndCntrl.HalconWindow.SetLineWidth(obj.IconicLineWidth);
        //                                hWndCntrl.HalconWindow.DispRectangle2(obj.DispObject.DArr[0], obj.DispObject.DArr[1], obj.DispObject.DArr[2], obj.DispObject.DArr[3], obj.DispObject.DArr[3]);
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                    }
        //                }
        //            }
        //            */
        //        }
        //    }
        //}

        public static void DisplayResult(ElaborateResult result, CogRecordDisplay cogWndCntrl)
        {
            double ratio = (double)cogWndCntrl.Height / (double)cogWndCntrl.Height;

            string dummy = string.Format(timeElaborationPattern, result.ElapsedTime.ToString("F1", CultureInfo.InvariantCulture));

            if (result.InTimeout)
            {
                dummy = string.Format("{0} TIMEOUT", dummy);
            }

            CogGraphicLabel cgl = new CogGraphicLabel()
            {
                Text = dummy,
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold)
            };

            cogWndCntrl.StaticGraphics.Add(cgl, "default");
        }

        public static void DisplayRegolazioni(ObjectToDisplay dipObjList, CogRecordDisplay cogWndCntrl)
        {
            if (dipObjList != null && dipObjList.GetImage() != null)
            {
                cogWndCntrl.Image = dipObjList.GetImage();

                for (int i = 0; i < dipObjList.GetStaticGraphics().Count; i++)
                {
                    foreach (ICogGraphic cogGraphic in dipObjList.GetStaticGraphics())
                        cogWndCntrl.StaticGraphics.Add(cogGraphic, "default");
                }
            }
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Preso da : https://msdn.microsoft.com/en-us/library/bb762914%28v=vs.110%29.aspx

            if (System.IO.Directory.Exists(sourceDirName))
            {
                // Get the subdirectories for the specified directory.
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sourceDirName);
                System.IO.DirectoryInfo[] dirs = dir.GetDirectories();

                if (!dir.Exists)
                {
                    throw new System.IO.DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                // If the destination directory doesn't exist, create it. 
                if (!System.IO.Directory.Exists(destDirName))
                {
                    System.IO.Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                System.IO.FileInfo[] files = dir.GetFiles();
                foreach (System.IO.FileInfo file in files)
                {
                    string temppath = System.IO.Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }

                // If copying subdirectories, copy them and their contents to new location. 
                if (copySubDirs)
                {
                    foreach (System.IO.DirectoryInfo subdir in dirs)
                    {
                        string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
        }

    }
}