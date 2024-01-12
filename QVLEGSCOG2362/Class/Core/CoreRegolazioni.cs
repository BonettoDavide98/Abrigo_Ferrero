using Cognex.VisionPro;
using System;
using System.Collections;
using System.Diagnostics;

namespace QVLEGSCOG2362.Class
{
    public class CoreRegolazioni : CoreBase
    {

        #region Variabili Private

        private readonly Core core = null;

        private ICogImage lastGrabImg = null;

        #endregion

        public CoreRegolazioni(int numCamera, int idCamera, int idStazione, Core core, DataType.Impostazioni config) : base(numCamera, idCamera, idStazione, config)
        {
            try
            {
                this.core = core;

                core.SetOnNewImageForRegolazioni(core_OnNewImageForRegolazioni);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IFrameGrabberManager GetFrameGrabberManager()
        {
            return this.core.GetFrameGrabberManager();
        }

        public void ExecuteOnLastImage()
        {
            ICogImage lastGrabImgTmp = GetLastGrabImage();

            if (lastGrabImgTmp != null && lastGrabImgTmp.Allocated)
            {
                CoreOnNewImage(lastGrabImgTmp);
            }
        }

        public ICogImage GetLastGrabImage()
        {
            ICogImage lastGrabImgTmp = null;

            lock (onNewImageLock)
            {
                if (lastGrabImg != null)
                {
                    lastGrabImgTmp = lastGrabImg.CopyBase(CogImageCopyModeConstants.CopyPixels); ;
                }
            }
            return lastGrabImgTmp;
        }

        private void core_OnNewImageForRegolazioni(ICogImage hImage)
        {
            if (this.IsRunning)
                CoreOnNewImage(hImage);
        }

        private void CoreOnNewImage(ICogImage hImage)
        {
            lock (onNewImageLock)
            {
                //if (this.lastGrabImg != null)
                //    this.lastGrabImg.Dispose();
                this.lastGrabImg = hImage.CopyBase(CogImageCopyModeConstants.CopyPixels);

                Stopwatch sw = Stopwatch.StartNew();

                Utilities.ObjectToDisplay iconicVarList;
                DataType.ElaborateResult result;
                ElaborateImage(hImage, out iconicVarList, out result);

                if (result != null)
                {
                    result.ElapsedTime = sw.ElapsedMilliseconds;

                    RaiseNewImageToDisplayEvent(iconicVarList, result);
                }
            }

            ((IDisposable)hImage).Dispose();
        }

        public override void Run()
        {
            this.IsRunning = true;
        }

        public override void StopAndWaitEnd(bool forceTrigger)
        {
            this.IsRunning = false;
        }

        public override void CloseFrameGrabber()
        {
            if (this.lastGrabImg != null)
            {
                //this.lastGrabImg.Dispose();
                //this.lastGrabImg = null;
            }
            core.SetOnNewImageForRegolazioni(null);
        }

    }
}