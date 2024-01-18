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
                        arr.GetStaticGraphics()[i] = null;
                    }
                }
            }
            arr.DisposeStaticGraphics();
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
                Font = new System.Drawing.Font("Arial", 20),
                Color = CogColorConstants.Yellow,
                X = 0,
                Y = cogWndCntrl.Image.Height,
                Alignment = CogGraphicLabelAlignmentConstants.BottomLeft
            };

            cogWndCntrl.StaticGraphics.Add(cgl, "timeDisplay");
        }

        public static void DisplayRegolazioni(ObjectToDisplay dipObjList, CogRecordDisplay cogWndCntrl)
        {
            if (dipObjList != null && dipObjList.GetImage() != null)
            {
                cogWndCntrl.Image = dipObjList.GetImage().CopyBase(CogImageCopyModeConstants.CopyPixels);
                
                cogWndCntrl.StaticGraphics.Clear();
                cogWndCntrl.InteractiveGraphics.Clear();

                for (int i = 0; i < dipObjList.GetStaticGraphics().Count; i++)
                {
                    foreach (ICogGraphic cogGraphic in dipObjList.GetStaticGraphics())
                        cogWndCntrl.StaticGraphics.Add(cogGraphic, "default");
                }

                for (int i = 0; i < dipObjList.GetInteractiveGraphics().Count; i++)
                {
                    foreach (ICogGraphicInteractive cogGraphic in dipObjList.GetInteractiveGraphics())
                        cogWndCntrl.InteractiveGraphics.Add(cogGraphic, "defaultInteractive", false);
                }

                dipObjList?.Dispose();
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