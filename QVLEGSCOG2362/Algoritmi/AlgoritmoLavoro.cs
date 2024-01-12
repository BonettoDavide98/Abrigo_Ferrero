using Cognex.VisionPro;
using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace QVLEGSCOG2362.Algoritmi
{
    public class AlgoritmoLavoro : Algoritmo, IDisposable
    {

        #region Variabili Private

        private bool disposed = false;

        private DataType.ParametriAlgoritmo parametri = null;
        private string idFormato = null;

        private DateTime dataRiferimentoTurno = DateTime.MinValue;
        private int nomeTurno = -1;

        private DataType.TipoAlgoritmo tipoAlgoritmo = DataType.TipoAlgoritmo.Normale;

        private bool caricamentoParametri = false;

        #endregion Variabili Private



        public AlgoritmoLavoro(int idCamera, int idStazione, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager) : base(idCamera, idStazione, impostazioni, linguaManager)
        {

        }

        public void SetDatiTurno(DateTime dataRiferimentoTurno, int nomeTurno)
        {
            this.dataRiferimentoTurno = dataRiferimentoTurno;
            this.nomeTurno = nomeTurno;
        }

        public void LoadFiles(string idFormato)
        {
            this.idFormato = idFormato;
        }


        public void SetCaricamentoParametri(bool v)
        {
            caricamentoParametri = v;
        }

        public void SetAlgoritmoParam(DataType.ParametriAlgoritmo param)
        {
            this.parametri = param;
            if (this.parametri != null)
            {
                this.parametri.Template = DataType.TemplateFormato.GetTemplateByName(this.parametri.TemplateName);
            }
        }

        public DataType.ParametriAlgoritmo GetAlgoritmoParam()
        {
            return this.parametri;
        }

        public void SetTipoAlgoritmo(DataType.TipoAlgoritmo tipoAlgoritmo)
        {
            this.tipoAlgoritmo = tipoAlgoritmo;
        }


        public void AlgoritmoLavoroFunction(ICogImage image, out Utilities.ObjectToDisplay iconicList, out DataType.ElaborateResult result)
        {
            iconicList = null;
            result = null;

            if (base.impostazioniCamera.TipoCamera == DataType.TipoCamera.Acetato)
                AlgoritmoLavoroFunctionAcetato(image, out iconicList, out result);
            else if (base.impostazioniCamera.TipoCamera == DataType.TipoCamera.DL)
                AlgoritmoLavoroFunctionDL(image, out iconicList, out result);
        }

        public void AlgoritmoLavoroFunctionAcetato(ICogImage image, out Utilities.ObjectToDisplay iconicList, out DataType.ElaborateResult result)
        {
            Utilities.ObjectToDisplay workingList = new Utilities.ObjectToDisplay();
            DataType.ElaborateResult res = new DataType.ElaborateResult(this.parametri == null ? null : this.parametri.Template?.IsCircle) { Success = true, Result1 = true, Result2 = true };
            res.StatisticheObj.IdStazione = this.idStazione;
            res.StatisticheObj.IdCamera = this.idCamera;
            res.StatisticheObj.IdFormato = this.idFormato;
            res.StatisticheObj.DataRiferimentoTurno = this.dataRiferimentoTurno;
            res.StatisticheObj.NomeTurno = this.nomeTurno;

            StringBuilder sbTempi = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();

            ClassInputAlgoritmi inputAlg = null;
            //HRegion regionMain = null;

            try
            {
                workingList.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));

                if (caricamentoParametri)
                {
                    //Se sto caricando i parametri do OK
                    res.Success = true;
                }
                else
                {

                }
            }
            catch (Exception)
            {
                res.Success = false;
                //throw;
            }
            finally
            {
                if (res.Success == false && res.Result1 == true && res.Result2 == true)
                {
                    res.Result1 = true;
                    res.Result2 = res.Success;
                }

                //workingList.Add(new Utilities.ObjectToDisplay(res.Success ? "OK" : "KO", res.Success ? COLORE_ANN_OK : COLORE_ANN_KO, 10, 10, 30));

                AddTestiRagioneScarto(res, ref workingList);

                res.DescrizioneTempi = sbTempi.ToString();

                res.StatisticheObj.AddObjContatore("ALG_OK", res.Success);
                res.StatisticheObj.AddObjContatore($"CNT_KO_CAM{this.idCamera + 1}", !res.Success);

                iconicList = workingList;
                result = res;

                inputAlg?.Dispose();
                //regionMain?.Dispose();
            }
        }

        public void AlgoritmoLavoroFunctionDL(ICogImage image, out Utilities.ObjectToDisplay iconicList, out DataType.ElaborateResult result)
        {
            Utilities.ObjectToDisplay workingList = new Utilities.ObjectToDisplay();
            DataType.ElaborateResult res = new DataType.ElaborateResult(this.parametri == null ? null : this.parametri.Template?.IsCircle) { Success = true };
            res.StatisticheObj.IdStazione = this.idStazione;
            res.StatisticheObj.IdCamera = this.idCamera;
            res.StatisticheObj.IdFormato = this.idFormato;
            res.StatisticheObj.DataRiferimentoTurno = this.dataRiferimentoTurno;
            res.StatisticheObj.NomeTurno = this.nomeTurno;

            StringBuilder sbTempi = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();

            ClassInputAlgoritmi inputAlg = null;

            //DISPLAY
            //HRegion regionMain = null;

            try
            {
                workingList.SetImage(image.CopyBase(CogImageCopyModeConstants.CopyPixels));

                if (caricamentoParametri)
                {
                    //Se sto caricando i parametri do OK
                    res.Success = true;
                }
                else
                {

                }
            }
            catch (Exception)
            {
                res.Success = false;
                //throw;
            }
            finally
            {
                //workingList.Add(new Utilities.ObjectToDisplay(res.Success ? "OK" : "KO", res.Success ? COLORE_ANN_OK : COLORE_ANN_KO, 10, 10, 30));
                res.DescrizioneTempi = sbTempi.ToString();

                AddTestiRagioneScarto(res, ref workingList);

                res.StatisticheObj.AddObjContatore("ALG_OK", res.Success);
                res.StatisticheObj.AddObjContatore($"CNT_KO_CAM{this.idCamera + 1}", !res.Success);

                iconicList = workingList;
                result = res;

                inputAlg?.Dispose();
                //regionMain?.Dispose();
            }
        }


        public static string[] GetAllKey()
        {
            return new string[] {
                 "TEST_INTEGRITA_AREA"
                , "TEST_INTEGRITA_DELTA"
                , "TEST_DIMENSIONE_DIAMETRO"
                , "TEST_DIMENSIONE_CIRCOLARITA"
                , "TEST_DIMENSIONE_W"
                , "TEST_DIMENSIONE_H"
                , "TEST_DISEGNI_PRESENZA_AREA"
                , "TEST_DISEGNI_MACCHIE_GROSSE_AREA_MAX"
                , "TEST_COLORE_DIST"
                , "TEST_COLORE_DIST_2"
                , "TEST_COLORE_2_AREA"
                , "TEST_SBORDAMENTO_AREA_MAX"
                , "TEST_DIMENSIONE_LATO_W"
                , "TEST_DIMENSIONE_LATO_H"
                , "TEST_CREPE_LEN"
                , "TEST_RAKE_DELTA_V"
                , "TEST_RAKE_DIMENSIONE_LATO_V_0"
                , "TEST_RAKE_DIMENSIONE_LATO_V_1"
                , "TEST_RAKE_DIMENSIONE_LATO_V_2"
                , "TEST_RAKE_DIMENSIONE_LATO_V_3"
                , "TEST_RAKE_DIMENSIONE_LATO_V_4"
                , "TEST_RAKE_DELTA_H"
                , "TEST_RAKE_DIMENSIONE_LATO_H_0"
                , "TEST_RAKE_DIMENSIONE_LATO_H_1"
                , "TEST_RAKE_DIMENSIONE_LATO_H_2"
                , "TEST_RAKE_DIMENSIONE_LATO_H_3"
                , "TEST_RAKE_DIMENSIONE_LATO_H_4"
                , "TEST_DIMENSIONE_ALTEZZA"
                , "TEST_BUCHI_LATO_3D_AREA_MAX"
            };
        }

        public static double GetBucketByKey(string key)
        {
            double ret = -1;

            switch (key)
            {
                // TOP
                case "TEST_INTEGRITA_AREA":
                case "TEST_DISEGNI_MACCHIE_GROSSE_AREA_MAX":
                case "TEST_DISEGNI_PRESENZA_AREA":
                case "TEST_BUCHI_LATO_3D_AREA_MAX":
                    ret = 0.5;
                    break;

                case "TEST_INTEGRITA_DELTA":
                case "TEST_DIMENSIONE_DIAMETRO":
                case "TEST_DIMENSIONE_W":
                case "TEST_DIMENSIONE_H":
                case "TEST_COLORE_DIST":
                case "TEST_COLORE_DIST_2":
                case "TEST_COLORE_AREA_SCURO":
                case "TEST_COLORE_AREA_SCURO_2":
                case "TEST_COLORE_AREA_2_SCURO":
                case "TEST_COLORE_AREA_2_SCURO_2":
                case "TEST_COLORE_PERC_CHIARO":
                case "TEST_COLORE_PERC_CHIARO_2":
                case "TEST_COLORE_2_AREA":
                case "TEST_DIMENSIONE_LATO_W":
                case "TEST_DIMENSIONE_LATO_H":
                case "TEST_CREPE_LEN":
                case "TEST_RAKE_DELTA_V":
                case "TEST_RAKE_DIMENSIONE_LATO_V_0":
                case "TEST_RAKE_DIMENSIONE_LATO_V_1":
                case "TEST_RAKE_DIMENSIONE_LATO_V_2":
                case "TEST_RAKE_DIMENSIONE_LATO_V_3":
                case "TEST_RAKE_DIMENSIONE_LATO_V_4":
                case "TEST_RAKE_DELTA_H":
                case "TEST_RAKE_DIMENSIONE_LATO_H_0":
                case "TEST_RAKE_DIMENSIONE_LATO_H_1":
                case "TEST_RAKE_DIMENSIONE_LATO_H_2":
                case "TEST_RAKE_DIMENSIONE_LATO_H_3":
                case "TEST_RAKE_DIMENSIONE_LATO_H_4":
                case "TEST_DIMENSIONE_ALTEZZA":
                    ret = 0.5;
                    break;

                case "TEST_DIMENSIONE_CIRCOLARITA":
                    ret = 0.1;
                    break;

                // LATO
                case "TEST_SBORDAMENTO_AREA_MAX":
                    ret = 0.5;
                    break;

                //3D
                case "TEST_TOP_3D_AREA_CENTRO":
                case "TEST_TOP_3D_AREA_DISALLINEAMENTO":
                    ret = 0.5;
                    break;

                default:
                    throw new Exception("SOGLIA INESISTENTE");
                    break;
            }

            return ret;
        }

        public double[] GetSoglieByKey(string key)
        {
            double[] ret = null;

            if (this.parametri != null)
            {
                switch (key)
                {
                    default:
                        throw new Exception("SOGLIA INESISTENTE");
                        break;

                }
            }

            return ret;
        }

        public void SetSoglieByKey(string key, double[] soglie)
        {
            if (this.parametri != null)
            {
                switch (key)
                {
                    default:
                        throw new Exception("SOGLIA INESISTENTE");
                        break;
                }
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
                    base.DisposeBase();
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.
        ~AlgoritmoLavoro()
        {
            // Simply call Dispose(false).
            Dispose(false);
        }

    }
}