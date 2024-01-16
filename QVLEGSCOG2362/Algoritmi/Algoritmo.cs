﻿using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageProcessing;
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
            
            ((IDisposable)image)?.Dispose();
        }

        #region ACETATO

        protected bool TestAcetato(ClassInputAlgoritmi inputAlg, DataType.AcetatoParam param, bool isWizard, ref DataType.ElaborateResult res, ref Utilities.ObjectToDisplay workingList)
        {
            bool ret = false;
            bool ret1 = false;
            bool ret2 = false;

            CogBlobTool blobTool = new CogBlobTool();
            CogImageConvertTool imageConvertTool = new CogImageConvertTool();

            try
            {
                if (!param.AbilitaControllo)
                {
                    ret = true;
                }
                else
                {
                    imageConvertTool.InputImage = inputAlg.Img;
                    imageConvertTool.Run();

                    blobTool.InputImage = imageConvertTool.OutputImage;
                    blobTool.RunParams.ConnectivityMinPixels = param.AreaMinDifetto;
                    blobTool.RunParams.SegmentationParams.SetSegmentationHardFixedThreshold(100, CogBlobSegmentationPolarityConstants.LightBlobs);

                    //VASSOIO SX
                    blobTool.Region = new CogRectangle()
                    {
                        Width = imageConvertTool.OutputImage.Width / 2,
                        Height = imageConvertTool.OutputImage.Height
                    };

                    workingList.AddStaticGraphics(new CogRectangle()
                    {
                        Width = imageConvertTool.OutputImage.Width / 2,
                        Height = imageConvertTool.OutputImage.Height,
                        X = 0,
                        Y = 0
                    });

                    blobTool.Run();

                    ret1 = blobTool.Results.GetBlobIDs(true).Length == 0;

                    //if (isWizard)
                    //    workingList.SetImage(blobTool.Results.CreateBlobImage());

                    double areaTot1 = 0;
                    foreach(CogBlobResult blobResult in blobTool.Results.GetBlobs())
                    {
                        areaTot1 += blobResult.Area;

                        //if(isWizard)
                        //    workingList.AddStaticGraphics(blobResult.CreateResultGraphics(CogBlobResultGraphicConstants.All));
                    }

                    res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_ACETATO_AREA_1 {0} {1}"), areaTot1, param.AreaMinDifetto), ret1 ? CogColorConstants.Green : CogColorConstants.Red));

                    if (!ret1)
                        res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_ERRORE_ACETATO"));

                    //VASSOIO DX
                    blobTool.Region = new CogRectangle()
                    {
                        Width = imageConvertTool.OutputImage.Width / 2,
                        Height = imageConvertTool.OutputImage.Height,
                        Y = 0
                    };

                    workingList.AddStaticGraphics(new CogRectangle()
                    {
                        Width = imageConvertTool.OutputImage.Width / 2,
                        Height = imageConvertTool.OutputImage.Height,
                        X = imageConvertTool.OutputImage.Width / 2,
                        Y = 0
                    });

                    blobTool.Run();

                    ret2 = blobTool.Results.GetBlobIDs(true).Length == 0;

                    //if (isWizard)
                    //    workingList.SetImage(blobTool.Results.CreateBlobImage());

                    double areaTot2 = 0;
                    foreach (CogBlobResult blobResult in blobTool.Results.GetBlobs())
                    {
                        areaTot2 += blobResult.Area;

                        //if(isWizard)
                        //    workingList.AddStaticGraphics(blobResult.CreateResultGraphics(CogBlobResultGraphicConstants.All));
                    }

                    res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_ACETATO_AREA_1 {0} {1}"), areaTot2, param.AreaMinDifetto), ret2 ? CogColorConstants.Green : CogColorConstants.Red));

                    if (!ret2)
                        res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_ERRORE_ACETATO"));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                imageConvertTool?.Dispose();
                blobTool?.Dispose();
            }

            return ret = ret1 & ret2;
        }

        #endregion ACETATO

        protected void DisposeBase()
        {
        }

    }
}