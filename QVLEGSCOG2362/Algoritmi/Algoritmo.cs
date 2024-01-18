using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageProcessing;
using System;
using ViDi2;

namespace QVLEGSCOG2362.Algoritmi
{
    public class Algoritmo : AlgoritmoBase
    {
        //non possono esistere due istanze di queste variabili, quindi sono statiche
        protected static ViDi2.Runtime.IControl control = null;
        protected static IWorkspace workspace = null;
        protected static IStream streamCAM1 = null;
        protected static IStream streamCAM2 = null;

        public Algoritmo(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
            //singleton
            if (control == null)
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
                    //int limit = 0;

                    //imageConvertTool converte l'immagine in una CogImage8Grey (ovvero in bianco e nero)
                    imageConvertTool.InputImage = inputAlg.Img;
                    imageConvertTool.Run();
                    
                    //l'immagine in bianco e nero viene data in input al cogBlobTool
                    blobTool.InputImage = imageConvertTool.OutputImage;
                    blobTool.RunParams.ConnectivityMinPixels = param.AreaMinDifetto;
                    blobTool.RunParams.SegmentationParams.SetSegmentationHardFixedThreshold(100, CogBlobSegmentationPolarityConstants.LightBlobs);
                    //eseguo una volta il blobtool su tutta l'immagine per avere un immagine da mettere a display
                    blobTool.Run();
                    workingList.SetImage(blobTool.Results.CreateBlobImage());

                    //VASSOIO SX
                    //creo un rettangolo a partire dai parametri in AcetatoParam; questo rettangolo verrà usato come ROI
                    CogRectangle rectSX = new CogRectangle()
                    {
                        Width = param.RettangoloSXWidth,
                        Height = param.RettangoloSXHeight,
                        X = param.RettangoloSXX,
                        Y = param.RettangoloSXY,
                        Interactive = true,
                        GraphicDOFEnable = CogRectangleDOFConstants.All,
                        Color = CogColorConstants.Magenta,
                        LineWidthInScreenPixels = 5
                    };

                    //se sono in wizard il rettangolo è interattivo, ovvero posso trascinarlo e ridimensionarlo, altrimenti è fisso
                    if (isWizard)
                        workingList.AddInteractiveGraphics(rectSX);
                    else
                        workingList.AddStaticGraphics(rectSX);

                    //imposto ROI ed eseguo
                    blobTool.Region = rectSX;
                    blobTool.Run();

                    //se non trovo blobs vuol dire che non è presente acetato
                    ret1 = blobTool.Results.GetBlobIDs(true).Length == 0;

                    double areaTot1 = 0;
                    //limit = 0;
                    foreach (CogBlobResult blobResult in blobTool.Results.GetBlobs())
                    {
                        areaTot1 += blobResult.Area;

                        //mostro una bounding box per ogni blob trovato se sono in wizard
                        if (isWizard)
                        {
                            CogRectangleAffine rect = blobResult.GetBoundingBox(CogBlobAxisConstants.PixelAligned);
                            rect.Color = CogColorConstants.Magenta;
                            workingList.AddStaticGraphics(rect);
                        }
                        //else
                        //{
                        //    //limito in numero di blob raffigurati in live per evitare lag
                        //    limit++;
                        //    if (limit > 4)
                        //        break;
                        //    CogRectangleAffine rect = blobResult.GetBoundingBox(CogBlobAxisConstants.PixelAligned);
                        //    rect.Color = CogColorConstants.Red;
                        //    workingList.AddStaticGraphics(rect);
                        //}
                    }

                    //non funziona???
                    res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_ACETATO_AREA_1"), areaTot1), ret1 ? CogColorConstants.Green : CogColorConstants.Red));

                    res.Result1 = ret1;

                    //VASSOIO DX
                    //creo un rettangolo a partire dai parametri in AcetatoParam; questo rettangolo verrà usato come ROI
                    CogRectangle rectDX = new CogRectangle()
                    {
                        Width = param.RettangoloDXWidth,
                        Height = param.RettangoloDXHeight,
                        X = param.RettangoloDXX,
                        Y = param.RettangoloDXY,
                        Interactive = true,
                        GraphicDOFEnable = CogRectangleDOFConstants.All,
                        Color = CogColorConstants.Cyan,
                        LineWidthInScreenPixels = 5
                    };

                    //se sono in wizard il rettangolo è interattivo, ovvero posso trascinarlo e ridimensionarlo, altrimenti è fisso
                    if (isWizard)
                        workingList.AddInteractiveGraphics(rectDX);
                    else
                        workingList.AddStaticGraphics(rectDX);

                    //imposto ROI ed eseguo
                    blobTool.Region = rectDX;
                    blobTool.Run();

                    //se non trovo blobs vuol dire che non è presente acetato
                    ret2 = blobTool.Results.GetBlobIDs(true).Length == 0;

                    double areaTot2 = 0;
                    //limit = 0;
                    foreach (CogBlobResult blobResult in blobTool.Results.GetBlobs())
                    {
                        areaTot2 += blobResult.Area;

                        if (isWizard)
                        {
                            //mostro una bounding box per ogni blob trovato se sono in wizard
                            CogRectangleAffine rect = blobResult.GetBoundingBox(CogBlobAxisConstants.PixelAligned);
                            rect.Color = CogColorConstants.Cyan;
                            workingList.AddStaticGraphics(rect);
                        }
                        //else
                        //{
                        //    //limito in numero di blob raffigurati in live per evitare lag
                        //    limit++;
                        //    if (limit > 4)
                        //        break;
                        //    CogRectangleAffine rect = blobResult.GetBoundingBox(CogBlobAxisConstants.PixelAligned);
                        //    rect.Color = CogColorConstants.Red;
                        //    workingList.AddStaticGraphics(rect);
                        //}
                    }

                    //non funziona???
                    res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_ACETATO_AREA_2"), areaTot2), ret2 ? CogColorConstants.Green : CogColorConstants.Red));

                    res.Result2 = ret2;
                }
            }
            catch (System.Exception ex)
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

        #endregion

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

                /*
                 * POSSIBILE IMPLEMENTAZIONE ROI DINAMICA (NON FUNZIONA PER ADESSO)
                //IGreenTool tool1 = streamCAM1.Tools["Classify"] as IGreenTool;

                //if(tool1.RegionOfInterest is IManualRegionOfInterest)
                //{
                //    (tool1.RegionOfInterest as IManualRegionOfInterest).Offset = new Point(0, 0);
                //    (tool1.RegionOfInterest as IManualRegionOfInterest).Size = new Size(image.Width, image.Height);
                //    (tool1.RegionOfInterest as IManualRegionOfInterest).SplittingGrid = new Size(5, 3);
                //}

                //IGreenTool tool2 = streamCAM2.Tools["Classify"] as IGreenTool;

                //if (tool2.RegionOfInterest is IManualRegionOfInterest)
                //{
                //    (tool2.RegionOfInterest as IManualRegionOfInterest).Offset = new Point(0, 0);
                //    (tool2.RegionOfInterest as IManualRegionOfInterest).Size = new Size(image.Width, image.Height);
                //    (tool2.RegionOfInterest as IManualRegionOfInterest).SplittingGrid = new Size(5, 3);
                //}
                */

                //processo l'immagine con il green tool CLassify
                using (IImage iimage = new FormsImage(image.ToBitmap()))
                {
                    if (idCamera == 1)
                        sample = streamCAM1.Tools["Classify"].Process(iimage);
                    else if (idCamera == 2)
                        sample = streamCAM2.Tools["Classify"].Process(iimage);
                }

                res.Success = true;
                ret = true;

                //dato che la ROI del GreenTool Classify è una griglia 5x3, avrò 15 GreenView da valutare
                //--Posizioni--
                //0   1   2   3   4
                //5   6   7   8   9
                //10  11  12  13  14
                //----
                IGreenView greenView = null;
                for (int i = 0; i < sample.Markings["Classify"].Views.Count; i++)
                {
                    greenView = sample.Markings["Classify"].Views[i] as IGreenView;

                    //se la view ha una score minore del threshold impostato nel wizard, il risultato viene scartato a priori
                    if (greenView.BestTag.Score < (param.CertaintyThreshold / 100))
                    {
                        res.Success = false;
                        ret = false;
                        res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_UNCERTAIN"), i, greenView.BestTag.Score));
                    }
                    //nelle posizioni 0, 5 e 10 (quelle del lato sinistro) devono esserci dei Raffaello
                    else if (i == 0 || i == 5 || i == 10)
                    {
                        if (greenView.BestTag.Name != "Raffaello_OK")
                        {
                            res.Success = false;
                            ret = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH"), i, "RAFFAELLO"));
                            break;
                        }
                    }
                    //nelle posizioni 4, 9 e 14 (quelle del lato destro) devono esserci dei Rondnoir
                    else if (i == 4 || i == 9 || i == 14)
                    {
                        if (greenView.BestTag.Name != "Rondnoir_OK")
                        {
                            res.Success = false;
                            ret = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH"), i, "RONDNOIR"));
                            break;
                        }
                    }
                    //in tutte le altre devono esserci dei Rocher
                    else
                    {
                        if (greenView.BestTag.Name != "Rocher_OK")
                        {
                            res.Success = false;
                            ret = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH"), i, "ROCHER"));
                            break;
                        }
                    }
                }

                //res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_OK")), ret ? CogColorConstants.Green : CogColorConstants.Red));

                //if (!ret)
                //    res.TestiRagioneScarto.Add(linguaManager.GetTranslation("MSG_ERRORE_DL"));

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

        #endregion

        protected void DisposeBase()
        {
        }

    }
}