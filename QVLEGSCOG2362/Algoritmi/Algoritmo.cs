using Cognex.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QVLEGSCOG2362.Algoritmi
{
    public class Algoritmo : AlgoritmoBase
    {

        public Algoritmo(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager) { }

        public void NOPAlgorithm(ICogImage image, out Utilities.ObjectToDisplay iconicList, out DataType.ElaborateResult result)
        {
            Utilities.ObjectToDisplay workingList = new Utilities.ObjectToDisplay();
            DataType.ElaborateResult res = new DataType.ElaborateResult(false) { Success = true };

            workingList.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));

            iconicList = workingList;
            result = res;
        }

        protected void DisposeBase()
        {
        }

    }
}