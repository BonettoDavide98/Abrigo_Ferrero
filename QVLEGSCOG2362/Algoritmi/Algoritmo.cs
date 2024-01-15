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

            //??
            ((IDisposable)image).Dispose();
        }

        #region ACETATO

        protected bool TestAcetato(ClassInputAlgoritmi inputAlg, DataType.AcetatoParam param, bool isWizard, ref DataType.ElaborateResult res, ref Utilities.ObjectToDisplay workingList)
        {
            bool ret = false;

            //HRegion regionLavoro = null;
            ICogImage imageReduced = null;
            //HRegion regionErrore = null;
            //HRegion regionConnection = null;
            //HRegion regionSelected = null;

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    //regionLavoro = GetCorniceRegion2(inputAlg.RegionThresholdCioccolato, CalibraFrom_mmToPx(param.DistanzaBordo));
                    //imageReduced = inputAlg.ImageV.ReduceDomain(regionLavoro);
                    //regionErrore = imageReduced.Threshold(0.0, param.Threshold);
                    //regionConnection = regionErrore.Connection();
                    //regionSelected = regionConnection.SelectShape("area", "and", CalibraFrom_mm2ToPx(param.AreaMinDifetto), double.MaxValue);

                    //double area = regionSelected.CountObj() > 0 ? regionSelected.Area.TupleMax().D : 0.0;
                    //double area_mm = CalibraFromPxTo_mm2(area);

                    //ret = area_mm < param.AreaMinDifetto;

                    //res.TestiOutAlgoritmi.Add(new Tuple<string, string>(string.Format(linguaManager.GetTranslation("MSG_OUT_Acetato_AREA"), area_mm, param.AreaMinDifetto), ret ? "green" : "red"));

                    //if (isWizard)
                    //{
                    //    workingList.Add(new Utilities.ObjectToDisplay(regionLavoro.Clone(), "blue", 2));
                    //    workingList.Add(new Utilities.ObjectToDisplay(regionSelected.Clone(), "red", 2) { DrawMode = "fill" });
                    //}

                    //if (!ret)
                    //{
                    //    res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_ERRORE_Acetato"));
                    //}
                }
            }
            finally
            {
                //regionLavoro?.Dispose();
                //imageReduced?.Dispose();
                //regionErrore?.Dispose();
                //regionConnection?.Dispose();
                //regionSelected?.Dispose();
            }
            return ret;
        }

        #endregion ACETATO

        protected void DisposeBase()
        {
        }

    }
}