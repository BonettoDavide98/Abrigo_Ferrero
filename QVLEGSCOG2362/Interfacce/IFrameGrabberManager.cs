using System.Collections;
using Cognex.VisionPro;
using QVLEGSCOG2362.DataType;

namespace QVLEGSCOG2362.Class
{
    public interface IFrameGrabberManager
    {
        event NewImageDelegate.OnNewImageDelegate OnNewImage;

        void Dispose();
        void ForceTrigger();
        double GetExpo();
        double GetGain();
        ArrayList GetOverrideParameter();
        string GetParam(string param);
        ArrayList GetParameter();
        bool GetValueInput(string line);
        ICogImage GrabASyncNoDelegate(out long tPreElab);
        ICogImage GrabImage();
        void GrabImageStart();
        void ResetDefaulParameter();
        void SetDelegate(NewImageDelegate.OnNewImageDelegate OnNewImage_);
        void SetExpo(double expo);
        void SetGain(double gain);
        void SetOutput(string line, bool value);
        void SetOverrideParameter(FrameGrabberConfigOverride param);
        void SetParam(string param, string value);
        void SetTrigger(bool trigger, bool triggerSoftware);
        void TriggerSoftware();
    }
}