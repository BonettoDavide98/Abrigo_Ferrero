using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using QVLEGSCOG2362.DataType;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Class
{
    public class FrameGrabberFileManager : IDisposable, IFrameGrabberManager
    {

        private bool disposed = false;

        int index = 0;
        string[] files;
        private CogImageFileTool imageFileTool = null;
        private FrameGrabberConfig frameGrabberConfig = null;
        private FrameGrabberConfigOverride frameGrabberConfigOverride = null;

        public event NewImageDelegate.OnNewImageDelegate OnNewImage;

        public FrameGrabberFileManager(FrameGrabberConfig configFrameGrabber)
        {
            try
            {
                this.frameGrabberConfig = configFrameGrabber;

                imageFileTool = new CogImageFileTool();
                files = Directory.GetFiles(frameGrabberConfig.CameraType);
                //this.framegrabber = new ICogFrameGrabber(frameGrabberConfig.Name
                //    , frameGrabberConfig.Horizzontal_resolution
                //    , frameGrabberConfig.Vertical_resolution
                //    , frameGrabberConfig.ImageWidth
                //    , frameGrabberConfig.ImageHeight
                //    , frameGrabberConfig.StartRow
                //    , frameGrabberConfig.StartColumn
                //    , frameGrabberConfig.Field
                //    , frameGrabberConfig.BitsPerChannel
                //    , frameGrabberConfig.ColorSpace
                //    , frameGrabberConfig.Generic
                //    , frameGrabberConfig.ExternalTrigger
                //    , frameGrabberConfig.CameraType
                //    , frameGrabberConfig.Device
                //    , frameGrabberConfig.Port
                //    , frameGrabberConfig.LineIn);

                SetConfigFrameGrabberParam(this.frameGrabberConfig.ParamList);

                SetTrigger(true, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.imageFileTool = null;
                throw ex;
            }
        }

        private void SetConfigFrameGrabberParam(ArrayList paramList)
        {
            if (paramList != null)
            {
                for (int i = 0; i < paramList.Count; i++)
                {
                    FrameGrabberParam obj = (FrameGrabberParam)paramList[i];
                    SetParam(obj.Param, obj.Value);
                }
            }
        }

        public void SetDelegate(NewImageDelegate.OnNewImageDelegate OnNewImage_)
        {
            OnNewImage = OnNewImage_;
        }

        public void SetTrigger(bool trigger, bool triggerSoftware)
        {
            if (trigger)
            {
                SetParam("TriggerMode", "On");
                SetParam("TriggerSource", triggerSoftware ? "Software" : "Line1");
                SetParam("continuous_grabbing", "enable");
            }
            else
            {
                SetParam("continuous_grabbing", "disable");
                SetParam("TriggerMode", "Off");
                SetParam("AcquisitionFrameRate", "1");
            }
        }

        public void SetOutput(string line, bool value)
        {
            //if (!line.Equals("Line3"))
            //{
            SetParam("LineSelector", line);
            SetParam("outputLineSource", "SoftwareControlled");
            SetParam("outputLineValue", value ? "Active" : "Inactive");
            //}
        }

        public bool GetValueInput(string line)
        {
            try
            {
                SetParam("LineSelector", line);
                if (GetParam("LineStatus") == "enable")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SetExpo(double expo)
        {
            throw new Exception("EXPO NOT AVAILABLE IN FILE");
        }

        public void SetGain(double gain)
        {

            throw new Exception("GAIN NOT AVAILABLE IN FILE");
        }

        public double GetExpo()
        {
            throw new Exception("EXPO NOT AVAILABLE IN FILE");
        }

        public double GetGain()
        {
            throw new Exception("GAIN NOT AVAILABLE IN FILE");
        }


        public void GrabImageStart()
        {
            //TODO : Evaluate
        }

        public ICogImage GrabASyncNoDelegate(out long tPreElab)
        {
            tPreElab = 0;

            imageFileTool.Operator.Open(files[index], CogImageFileModeConstants.Read);
            imageFileTool.Run();

            index++;
            if (index >= files.Length)
                index = 0;

            return imageFileTool.OutputImage;
        }

        public ICogImage GrabImage()
        {
            imageFileTool.Operator.Open(files[index], CogImageFileModeConstants.Read);
            imageFileTool.Run();

            index++;
            if (index >= files.Length)
                index = 0;

            return imageFileTool.OutputImage;
        }

        public void ForceTrigger()
        {
            //try
            //{
            //    framegrabber.SetFramegrabberParam(new HTuple("do_abort_grab"), new HTuple(1));
            //}
            //catch (Exception) { }
        }


        public void TriggerSoftware()
        {
            //try
            //{
            //    framegrabber.SetFramegrabberParam(new HTuple("TriggerSoftware"), new HTuple("False"));
            //}
            //catch (Exception ex) { }
        }


        public void ResetDefaulParameter()
        {
            SetConfigFrameGrabberParam(this.frameGrabberConfig.ParamList);
        }

        public void SetOverrideParameter(FrameGrabberConfigOverride param)
        {
            this.frameGrabberConfigOverride = param;
            SetConfigFrameGrabberParam(this.frameGrabberConfig.ParamList);
            if (param != null)
            {
                SetConfigFrameGrabberParam(this.frameGrabberConfigOverride.ParamList);
            }
        }

        public ArrayList GetParameter()
        {
            return this.frameGrabberConfig.ParamList;
        }

        public ArrayList GetOverrideParameter()
        {
            return this.frameGrabberConfigOverride == null ? null : this.frameGrabberConfigOverride.ParamList;
        }

        public void SetParam(string param, string value)
        {
            //try
            //{
            //    ICogGigEAccess gigEAccess = framegrabber.OwnedGigEAccess;

            //    gigEAccess.SetFeature(param, value);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace);
            //}
            //            double dValue = 0.0;
            //            int nValue = 0;
            //            try
            //            {
            //#if !_Simulazione
            //                if (CommonUtility.TryParseDouble(value, out dValue))
            //                {
            //                    framegrabber.SetFramegrabberParam(new HTuple(param), new HTuple(dValue));
            //                }
            //                else if (int.TryParse(value, out nValue))
            //                {
            //                    framegrabber.SetFramegrabberParam(new HTuple(param), new HTuple(nValue));
            //                }
            //                else
            //                {
            //                    framegrabber.SetFramegrabberParam(new HTuple(param), new HTuple(value));
            //                }
            //#endif
            //            }
            //            catch (Exception) { }
        }

        public string GetParam(string param)
        {
            //try
            //{
            //    ICogGigEAccess gigEAccess = framegrabber.OwnedGigEAccess;

            //    return gigEAccess.GetFeature(param);
            //}
            //catch (Exception ex)
            //{
            //    return "";
            //}
            return "";
        }

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
                    //framegrabber.Dispose();
                    //framegrabber.Disconnect(false);
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~FrameGrabberFileManager()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}