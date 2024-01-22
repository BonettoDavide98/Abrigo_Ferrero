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
        //protected static ViDi2.Runtime.IControl control = null;
        //protected static IWorkspace workspace = null;
        //protected static IStream streamCAM1 = null;
        //protected static IStream streamCAM2 = null;
        protected static IGreenTool greenTool1 = null;
        protected static IGreenTool greenTool2 = null;

        public Algoritmo(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {
            //singleton
            //non posso avere più di un istanza di queste variabili, quindi istanzio una sola volta
            //non posso trasformare questo costruttore in un costruttore statico dato che il workspace dipende dalla classe non statica impostazioni
            if (greenTool1 == null || greenTool2 == null)
            {
                ViDi2.Runtime.IControl control = new ViDi2.Runtime.Local.Control();
                IWorkspace workspace = control.Workspaces.Add("Ferrero_Abrigo_GRID_FAST", impostazioni.PathDatiBase + @"\ViDi_SUITE_RUNTIMES\Ferrero_Abrigo_GRID_FAST.vrws");
                IStream streamCAM1 = workspace.Streams["CAM1"];
                IStream streamCAM2 = workspace.Streams["CAM2"];

                greenTool1 = streamCAM1.Tools["Classify"] as IGreenTool;
                greenTool2 = streamCAM2.Tools["Classify"] as IGreenTool;
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
                    //creo un rettangolo a partire dai parametri in AcetatoParam; questo rettangolo verrà usato come ROI per il vassoio sinistro
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
                    res.Result1 = blobTool.Results.GetBlobIDs(true).Length == 0;

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
                        //codice per rappresentare i blob al di fuori del wizard
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
                    res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_ACETATO_AREA_1"), areaTot1), res.Result1 ? CogColorConstants.Green : CogColorConstants.Red));
                    
                    //VASSOIO DX
                    //creo un rettangolo a partire dai parametri in AcetatoParam; questo rettangolo verrà usato come ROI per il vassoio destro
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
                    res.Result2 = blobTool.Results.GetBlobIDs(true).Length == 0;

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
                        //codice per rappresentare i blob al di fuori del wizard
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
                    res.TestiOutAlgoritmi.Add(new Tuple<string, CogColorConstants>(string.Format(linguaManager.GetTranslation("MSG_OUT_ACETATO_AREA_2"), areaTot2), res.Result2 ? CogColorConstants.Green : CogColorConstants.Red));
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

            return res.Result1 && res.Result2;
        }

        #endregion

        #region DL

        protected bool TestDL(ClassInputAlgoritmi inputAlg, DataType.DLParam param, bool isWizard, ref DataType.ElaborateResult res, ref Utilities.ObjectToDisplay workingList)
        {
            IGreenTool greenTool = null;
            IManualRegionOfInterest ROI = null;
            ISample sample = null;
            IGreenView greenView = null;

            try
            {
                workingList.SetImage(inputAlg.Img.CopyBase(CogImageCopyModeConstants.CopyPixels));

                if (idCamera == 1)
                {
                    ROI = greenTool1.RegionOfInterest as IManualRegionOfInterest;
                    greenTool = greenTool1;
                }
                else if (idCamera == 2)
                {
                    ROI = greenTool2.RegionOfInterest as IManualRegionOfInterest;
                    greenTool = greenTool2;
                }

                //l'offset è a partire dall'angolo in alto a sinistra
                ROI.Offset = new Point(param.OffsetX, param.OffsetY);
                ROI.Size = new Size(param.CellWidth, param.CellHeight);

                //se si è nel wizard mostro il rettangolo trascinabile per definire la griglia
                if(isWizard)
                {
                    CogRectangle interactiveRectangle = new CogRectangle()
                    {
                        Width = param.RettangoloWidth,
                        Height = param.RettangoloHeight,
                        X = param.OffsetX,
                        Y = param.OffsetY,
                        LineWidthInScreenPixels = 2,
                        Interactive = true,
                        GraphicDOFEnable = CogRectangleDOFConstants.All,
                        Color = CogColorConstants.Cyan
                    };

                    workingList.AddInteractiveGraphics(interactiveRectangle);
                }

                //processo l'immagine con il green tool CLassify
                using (IImage iimage = new FormsImage(inputAlg.Img.ToBitmap()))
                {
                    res.Success = true;

                    //dato che la confezione è una griglia 5x3, avrò 15 GreenView da valutare
                    //--Posizioni--
                    //0   1   2   3   4
                    //5   6   7   8   9
                    //10  11  12  13  14
                    //----
                    
                    for (int i = 0; i < param.Rows * param.Columns; i++)
                    {
                        //calcolo l'offset (da in alto a sinistra) attuale
                        ROI.Offset = new Point((i % param.Columns) * param.CellWidth + param.OffsetX, (i / param.Columns) * param.CellHeight + param.OffsetY);

                        CogRectangle rect = new CogRectangle()
                        {
                            Width = param.CellWidth - 2,
                            Height = param.CellHeight - 2,
                            X = ROI.Offset.X,
                            Y = ROI.Offset.Y,
                            LineWidthInScreenPixels = 5
                        };

                        //processo l'immagine con la ROI corrente
                        sample = greenTool.Process(iimage);

                        //prendo sempre la view 0 siccome la mia ROI conterrà sempre un solo elemento (1x1)
                        greenView = sample.Markings["Classify"].Views[0] as IGreenView;

                        //se la view ha una score minore del threshold impostato nel wizard, il risultato viene scartato a priori
                        if (greenView.BestTag.Score < (param.CertaintyThreshold / 100))
                        {
                            res.Success = false;
                            res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_UNCERTAIN"), i, greenView.BestTag.Score));
                            rect.Color = CogColorConstants.Red;
                        }
                        //nelle posizioni 0, 5 e 10 (quelle del lato sinistro) devono esserci dei Raffaello
                        else if (i % param.Columns == 0)
                        {
                            if (greenView.BestTag.Name != "Raffaello_OK")
                            {
                                res.Success = false;
                                res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH"), i, "RAFFAELLO"));
                                rect.Color = CogColorConstants.Red;
                            } else
                            {
                                rect.Color = CogColorConstants.White;
                            }
                        }
                        //nelle posizioni 4, 9 e 14 (quelle del lato destro) devono esserci dei Rondnoir
                        else if (i % param.Columns == 4)
                        {
                            if (greenView.BestTag.Name != "Rondnoir_OK")
                            {
                                res.Success = false;
                                res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH"), i, "RONDNOIR"));
                                rect.Color = CogColorConstants.Red;
                            } else
                            {
                                rect.Color = CogColorConstants.Black;
                            }
                        }
                        //in tutte le altre devono esserci dei Rocher
                        else
                        {
                            if (greenView.BestTag.Name != "Rocher_OK")
                            {
                                res.Success = false;
                                res.TestiRagioneScarto.Add(string.Format(linguaManager.GetTranslation("MSG_OUT_DL_MISMATCH"), i, "ROCHER"));
                                rect.Color = CogColorConstants.Red;
                            } else
                            {
                                rect.Color = CogColorConstants.Yellow;
                            }
                        }

                        workingList.AddStaticGraphics(rect);
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

            return res.Success;
        }

        #endregion

        protected void DisposeBase()
        {
        }

    }
}