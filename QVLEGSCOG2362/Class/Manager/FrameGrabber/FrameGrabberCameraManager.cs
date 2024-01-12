using Cognex.VisionPro;
using QVLEGSCOG2362.DataType;
using System;
using System.Collections;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Class
{
    public class FrameGrabberCameraManager : IDisposable, IFrameGrabberManager
    {

        private bool disposed = false;

        private ICogFrameGrabber framegrabber = null;
        private ICogAcqFifo acqFifo = null;
        private FrameGrabberConfig frameGrabberConfig = null;
        private FrameGrabberConfigOverride frameGrabberConfigOverride = null;
        
        public event NewImageDelegate.OnNewImageDelegate OnNewImage;

        public FrameGrabberCameraManager(FrameGrabberConfig configFrameGrabber)
        {
            try
            {
                this.frameGrabberConfig = configFrameGrabber;

                CogFrameGrabbers cogFrameGrabbers = new CogFrameGrabbers();
                foreach(ICogFrameGrabber frameGrabber in cogFrameGrabbers)
                {
                    if(frameGrabber.OwnedGigEAccess.CurrentIPAddress == frameGrabberConfig.Device)
                    {
                        this.framegrabber = frameGrabber;
                    }
                }

                if (framegrabber == null)
                    throw new Exception("CAM IP ERROR");

                acqFifo = framegrabber.CreateAcqFifo("Generic GigEVision (Bayer Color)", frameGrabberConfig.pixelFormatConstants, 0, true);
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
                this.framegrabber = null;
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
            SetParam("LineSelector", line);
            SetParam("outputLineSource", "SoftwareControlled");
            SetParam("outputLineValue", value ? "Active" : "Inactive");
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
            try
            {
                acqFifo.OwnedExposureParams.Exposure = expo;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public void SetGain(double gain)
        {
            try
            {
                //TODO : Set Gain
                //acqFifo.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public double GetExpo()
        {
            return acqFifo.OwnedExposureParams.Exposure;
        }

        public double GetGain()
        {
            //TODO : Get Gain
            //return GetParam("Gain");
            return 1;
        }


        public void GrabImageStart()
        {
            //TODO : Evaluate
        }

        public ICogImage GrabASyncNoDelegate(out long tPreElab)
        {
            tPreElab = 0;
            int triggerNumber;
            ICogImage img = acqFifo.Acquire(out triggerNumber);

            return img;
        }

        public ICogImage GrabImage()
        {
            int triggerNumber;
            return acqFifo.Acquire(out triggerNumber);
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
            try
            {
                ICogGigEAccess gigEAccess = framegrabber.OwnedGigEAccess;

                //gigEAccess.SetFeature(param, value);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
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
            try
            {
                ICogGigEAccess gigEAccess = framegrabber.OwnedGigEAccess;

                return gigEAccess.GetFeature(param);
            }
            catch (Exception ex)
            {
                return "";
            }
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
                    framegrabber.Disconnect(false);
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~FrameGrabberCameraManager()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}