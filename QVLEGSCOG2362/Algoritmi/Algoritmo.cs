using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageProcessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ViDi2;

namespace QVLEGSCOG2362.Algoritmi
{
    public class Algoritmo : AlgoritmoBase
    {
        protected static ViDi2.Runtime.IControl control = null;
        protected static IWorkspace workspace = null;
        protected static IStream streamCAM1 = null;
        protected static IStream streamCAM2 = null;

        public Algoritmo(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
            if(control == null)
            {
                control = new ViDi2.Runtime.Local.Control();
                workspace = control.Workspaces.Add("Ferrero_Abrigo_GRID_FAST", impostazioni.PathDatiBase + @"\ViDi_SUITE_RUNTIMES\Ferrero_Abrigo_GRID_FAST.vrws");
                streamCAM1 = workspace.Streams["CAM1"];
                streamCAM2 = workspace.Streams["CAM2"];
            }
        }

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
                    CogRectangle rectSX = new CogRectangle()
                    {
                        Width = param.RettangoloSXWidth,
                        Height = param.RettangoloSXHeight,
                        X = param.RettangoloSXX,
                        Y = param.RettangoloSXY,
                        Interactive = true,
                        GraphicDOFEnable = CogRectangleDOFConstants.All,
                        Color = CogColorConstants.Green
                    };

                    if(isWizard)
                        workingList.AddInteractiveGraphics(rectSX);

                    blobTool.Region = rectSX;

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
                    CogRectangle rectDX = new CogRectangle()
                    {
                        Width = param.RettangoloDXWidth,
                        Height = param.RettangoloDXHeight,
                        X = param.RettangoloDXX,
                        Y = param.RettangoloDXY,
                        Interactive = true,
                        GraphicDOFEnable = CogRectangleDOFConstants.All,
                        Color = CogColorConstants.Red
                    };

                    if (isWizard)
                        workingList.AddInteractiveGraphics(rectDX);

                    blobTool.Region = rectDX;

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
            catch(System.Exception ex)
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

        #region DL

        protected bool TestDL(ClassInputAlgoritmi inputAlg, DataType.DLParam param, bool isWizard, ref DataType.ElaborateResult res, ref Utilities.ObjectToDisplay workingList)
        {
            bool ret = false;

            ICogImage image = null;
            ISample sample = null;

            try
            {
                workingList.SetImage(inputAlg.Img.CopyBase(CogImageCopyModeConstants.CopyPixels));

                image = inputAlg.Img.CopyBase(CogImageCopyModeConstants.CopyPixels);

                using (IImage iimage = new FormsImage(image.ToBitmap()))
                {
                    if (idCamera == 1)
                        sample = streamCAM1.Tools["Classify"].Process(iimage);
                    else if (idCamera == 2)
                        sample = streamCAM2.Tools["Classify"].Process(iimage);
                }

                res.Success = true;
                ret = true;

                IGreenView greenView = null;
                for (int i = 0; i < sample.Markings["Classify"].Views.Count; i++)
                {
                    greenView = sample.Markings["Classify"].Views[i] as IGreenView;
                    
                    if (greenView.BestTag.Score < (param.CertaintyThreshold / 100))
                    {
                        res.Success = false;
                        ret = false;
                        res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_UNCERTAIN {0}"), i));
                    }
                    else if (i == 0 || i == 5 || i == 10)
                    {
                        if (greenView.BestTag.Name != "Raffaello_OK")
                        {
                            res.Success = false;
                            ret = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH {0} {1}"), i, "RAFFAELLO"));
                            break;
                        }
                    }
                    else if (i == 4 || i == 9 || i == 14)
                    {
                        if (greenView.BestTag.Name != "Rondnoir_OK")
                        {
                            res.Success = false;
                            ret = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH {0} {1}"), i, "RONDNOIR"));
                            break;
                        }
                    }
                    else
                    {
                        if (greenView.BestTag.Name != "Rocher_OK")
                        {
                            res.Success = false;
                            ret = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH {0} {1}"), i, "ROCHER"));
                            break;
                        }
                    }
                }

                res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_OK")), ret ? CogColorConstants.Green : CogColorConstants.Red));

                if (!ret)
                    res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_ERRORE_DL"));
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                ((IDisposable)image)?.Dispose();
            }

            return ret;
        }

        #endregion DL

        protected void DisposeBase()
        {
        }

    }
}