using Cognex.VisionPro;
using System;
using System.Collections;
using System.Diagnostics;

namespace QVLEGSCOG2362.Algoritmi
{
    public class AlgoritmoBase
    {

        protected const string COLORE_ANN_OK = "green";
        protected const string COLORE_ANN_KO = "red";

        protected int idCamera = -1;
        protected int idStazione = -1;
        protected DataType.Impostazioni impostazioni = null;
        protected DataType.ImpostazioniCamera impostazioniCamera = null;
        protected DBL.LinguaManager linguaManager = null;

        protected DataType.ParametriAlgoritmo parametri = null;



        public AlgoritmoBase(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            this.idCamera = idCamera;
            this.idStazione = idStazione;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;

            switch (idCamera)
            {
                case 0:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera1;
                    break;
                case 1:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera2;
                    break;
                case 2:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera3;
                    break;
                case 3:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera4;
                    break;
                case 4:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera5;
                    break;
                case 5:
                    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera6;
                    break;
            }

        }

        public virtual void SetParametri(DataType.ParametriAlgoritmo param)
        {
            this.parametri = param;
        }


        public DataType.TipoCamera GetTipoCamera()
        {
            return this.impostazioniCamera.TipoCamera;
        }


        protected void AddTestiOutAlgoritmi(DataType.ElaborateResult res, ref Utilities.ObjectToDisplay workingList)
        {
            try
            {
                for (int i = 0; i < res.TestiOutAlgoritmi.Count; i++)
                {
                    workingList.AddStaticGraphics(res.TestiOutAlgoritmi[i].Item1, res.TestiOutAlgoritmi[i].Item2, 60 + (i * 20), 10, 16, true);
                }
            }
            catch (Exception) { }
        }

        protected void AddTestiRagioneScarto(DataType.ElaborateResult res, ref Utilities.ObjectToDisplay workingList)
        {
            try
            {
                for (int i = 0; i < res.TestiRagioneScarto.Count; i++)
                {
                    workingList.AddStaticGraphics(res.TestiRagioneScarto[i], CogColorConstants.Red, 60 + (i * 20), 10, 16, true);
                }
            }
            catch (Exception) { }
        }

        protected double CalibraFrom_mm2ToPx(double val)
        {
            return Math.Round(val * this.impostazioniCamera.KConvPX_mm * this.impostazioniCamera.KConvPX_mm, 1);
        }

        protected double CalibraFrom_mmToPx(double val)
        {
            return Math.Round(val * this.impostazioniCamera.KConvPX_mm, 1);
        }

        protected double CalibraFromPxTo_mm2(double val)
        {
            return Math.Round(val / this.impostazioniCamera.KConvPX_mm / this.impostazioniCamera.KConvPX_mm, 1);
        }

        protected double CalibraFromPxTo_mm(double val)
        {
            return Math.Round(val / this.impostazioniCamera.KConvPX_mm, 1);
        }

        protected double CalibraFromPxTo_mm_W(double val)
        {
            return Math.Round(val / this.impostazioniCamera.KConvPX_mm_W, 1);
        }

        protected double CalibraFromPxTo_mm_H(double val)
        {
            return Math.Round(val / this.impostazioniCamera.KConvPX_mm_H, 1);
        }



        protected delegate bool TestWizardBaseDelegate(ClassInputAlgoritmi inputAlg, ref DataType.ElaborateResult res, ref ArrayList workingList);

        protected void TestWizardAcqBase(ICogImage image, TestWizardBaseDelegate foo, out Utilities.ObjectToDisplay workingList, out DataType.ElaborateResult res)
        {
            Stopwatch sw = Stopwatch.StartNew();

            workingList = new Utilities.ObjectToDisplay();
            res = new DataType.ElaborateResult(this.parametri.Template.IsCircle);

            ClassInputAlgoritmi inputAlg = null;
            //HRegion regionMain = null;

            try
            {
                // oggetti da visualizzare
                workingList.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));

                //if (this.hClassLUTTappeto == null && impostazioniCamera.TipoCamera != DataType.TipoCamera.LatoAltezza)
                //{
                //    res.Success = false;
                //    res.TestiRagioneScarto.Add("MSG_GMM_KO");
                //}
                //else if (this.parametri == null)
                //{
                //    res.Success = false;
                //    res.TestiRagioneScarto.Add("MSG_PARAMETRI_KO");
                //}
                //else
                //{
                //    regionMain = new HRegion();
                //    regionMain.GenRectangle1(this.parametri.RoiMain.Row1, this.parametri.RoiMain.Column1, this.parametri.RoiMain.Row2, this.parametri.RoiMain.Column2);

                //    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                //    if (impostazioniCamera.TipoCamera == DataType.TipoCamera.Alto)
                //        inputAlg = CreaClassInputAlgoritmiAlto(this.parametri, image, regionMain);
                //    else if (impostazioniCamera.TipoCamera == DataType.TipoCamera.Lato)
                //        inputAlg = CreaClassInputAlgoritmiLato(this.parametri, image, regionMain);
                //    else if (impostazioniCamera.TipoCamera == DataType.TipoCamera.LatoAltezza)
                //        inputAlg = CreaClassInputAlgoritmiLatoAltezza(this.parametri, image, regionMain);

                //    res.Success = foo(inputAlg, ref res, ref workingList);
                //}
            }
            catch (Exception)
            {
            }
            finally
            {
                workingList.AddStaticGraphics(res.Success ? "OK" : "KO", res.Success ? CogColorConstants.Green : CogColorConstants.Red, 10, 10, 30);

                AddTestiOutAlgoritmi(res, ref workingList);

                res.ElapsedTime = sw.ElapsedMilliseconds;

                inputAlg?.Dispose();
                //regionMain?.Dispose();
            }
        }

        protected void TestWizardAcetatoBase(ICogImage image, TestWizardBaseDelegate foo, out Utilities.ObjectToDisplay workingList, out DataType.ElaborateResult res)
        {
            Stopwatch sw = Stopwatch.StartNew();

            workingList = new Utilities.ObjectToDisplay();
            res = new DataType.ElaborateResult(this.parametri.Template.IsCircle);

            ClassInputAlgoritmi inputAlg = null;
            //HRegion regionMain = null;

            try
            {
                // oggetti da visualizzare
                workingList.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));

                //if (this.hClassLUTTappeto == null)
                //{
                //    res.Success = false;
                //    res.TestiRagioneScarto.Add("MSG_GMM_KO");
                //}
                //else if (this.parametri == null)
                //{
                //    res.Success = false;
                //    res.TestiRagioneScarto.Add("MSG_PARAMETRI_KO");
                //}
                //else
                //{
                //    regionMain = new HRegion();
                //    regionMain.GenRectangle1(this.parametri.RoiMain.Row1, this.parametri.RoiMain.Column1, this.parametri.RoiMain.Row2, this.parametri.RoiMain.Column2);

                //    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                //    inputAlg = CreaClassInputAlgoritmiAlto(this.parametri, image, regionMain);

                //    if (Centraggio(image, inputAlg.RegionBiscotto, regionMain, this.parametri.AllineamentoParam, false, out double row, out double col, out double angle, ref res, ref workingList))
                //    {
                //        workingList.Add(new Utilities.ObjectToDisplay(inputAlg.RegionBiscotto.Clone(), "green", 2) { DrawMode = "margin" });

                //        inputAlg.Row = row;
                //        inputAlg.Col = col;
                //        inputAlg.Angle = angle;

                //        res.Success = foo(inputAlg, ref res, ref workingList);
                //    }
                //    else
                //    {
                //        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(linguaManager.GetTranslation("MSG_CENTRAGGIO_KO"), "red"));
                //    }
                //}
            }
            catch (Exception)
            {
            }
            finally
            {
                workingList.AddStaticGraphics(res.Success ? "OK" : "KO", res.Success ? CogColorConstants.Green : CogColorConstants.Red, 10, 10, 30);

                AddTestiOutAlgoritmi(res, ref workingList);

                res.ElapsedTime = sw.ElapsedMilliseconds;

                inputAlg?.Dispose();
                //regionMain?.Dispose();
            }
        }

        protected void TestWizardDLBase(ICogImage image, TestWizardBaseDelegate foo, out Utilities.ObjectToDisplay workingList, out DataType.ElaborateResult res)
        {
            Stopwatch sw = Stopwatch.StartNew();

            workingList = new Utilities.ObjectToDisplay();
            res = new DataType.ElaborateResult(this.parametri.Template.IsCircle);

            ClassInputAlgoritmi inputAlg = null;
            //HRegion regionMain = null;

            try
            {
                // oggetti da visualizzare
                workingList.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));

                //if (this.hClassLUTTappeto == null)
                //{
                //    res.Success = false;
                //    res.TestiRagioneScarto.Add("MSG_GMM_KO");
                //}
                //else if (this.parametri == null)
                //{
                //    res.Success = false;
                //    res.TestiRagioneScarto.Add("MSG_PARAMETRI_KO");
                //}
                //else
                //{
                //    regionMain = new HRegion();
                //    regionMain.GenRectangle1(this.parametri.RoiMain.Row1, this.parametri.RoiMain.Column1, this.parametri.RoiMain.Row2, this.parametri.RoiMain.Column2);

                //    workingList.Add(new Utilities.ObjectToDisplay(regionMain.Clone(), "blue", 2) { DrawMode = "margin" });

                //    inputAlg = CreaClassInputAlgoritmiAlto(this.parametri, image, regionMain);

                //    if (Centraggio(image, inputAlg.RegionBiscotto, regionMain, this.parametri.AllineamentoParam, false, out double row, out double col, out double angle, ref res, ref workingList))
                //    {
                //        workingList.Add(new Utilities.ObjectToDisplay(inputAlg.RegionBiscotto.Clone(), "green", 2) { DrawMode = "margin" });

                //        inputAlg.Row = row;
                //        inputAlg.Col = col;
                //        inputAlg.Angle = angle;

                //        res.Success = foo(inputAlg, ref res, ref workingList);
                //    }
                //    else
                //    {
                //        res.TestiOutAlgoritmi.Add(new Tuple<string, string>(linguaManager.GetTranslation("MSG_CENTRAGGIO_KO"), "red"));
                //    }
                //}
            }
            catch (Exception)
            {
            }
            finally
            {
                workingList.AddStaticGraphics(res.Success ? "OK" : "KO", res.Success ? CogColorConstants.Green : CogColorConstants.Red, 10, 10, 30);

                AddTestiOutAlgoritmi(res, ref workingList);

                res.ElapsedTime = sw.ElapsedMilliseconds;

                inputAlg?.Dispose();
                //regionMain?.Dispose();
            }
        }


        public class ClassInputAlgoritmi : IDisposable
        {

            public DataType.TemplateFormato Template { get; set; }


            public ClassInputAlgoritmi()
            {
            }

            private bool disposed = false;

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
                    }
                    // Free your own state (unmanaged objects).
                    // Set large fields to null.
                    disposed = true;
                }
            }

            // Use C# destructor syntax for finalization code.
            ~ClassInputAlgoritmi()
            {
                // Simply call Dispose(false).
                Dispose(false);
            }

        }

    }
}