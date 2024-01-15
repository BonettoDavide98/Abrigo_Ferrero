using System;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaEditRicettaCam : UserControl
    {

        private Class.AppManager appManager = null;
        private string idFormato = null;
        private DataType.Impostazioni impostazioni = null;
        private DataType.ImpostazioniCamera impostazioniCamera = null;

        private int idCamera = -1;
        private bool isFirst = false;
        private Algoritmi.AlgoritmoWizard algoritmoWizard = null;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaEditRicettaCam()
        {
            InitializeComponent();
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, int idCamera, bool isFirst, Utilities.SimpleDirtyTracker simpleDirtyTracker, DBL.LinguaManager linguaManager, object repaintLock)
        {
            this.appManager = appManager;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;
            this.idCamera = idCamera;
            this.isFirst = isFirst;

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
                //case 3:
                //    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera4;
                //    break;
                //case 4:
                //    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera5;
                //    break;
                //case 5:
                //    this.impostazioniCamera = this.impostazioni.ImpostazioniCamera6;
                //    break;
            }

            string fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", string.Format("ImgPosCam{0}.jpg", idCamera + 1));
            if (System.IO.File.Exists(fileName))
            {
                pictureBox1.BackgroundImage = new Bitmap(fileName);
            }

            fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", "BeltDir.jpg");
            if (System.IO.File.Exists(fileName))
            {
                pictureBox2.BackgroundImage = new Bitmap(fileName);
            }

            int cnt = 1;

            ucEditExpoGain1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);
            ucEditAlgAcetato1.Init(cnt++, appManager, idCamera, this.impostazioni, simpleDirtyTracker, linguaManager, repaintLock);

            ucEditExpoGain1.OnComplete += Uc_OnComplete;
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblDirNastro.Text = linguaManager.GetTranslation("LBL_DIR_NASTRO");

            ucEditExpoGain1.Translate(linguaManager);
            ucEditAlgAcetato1.Translate(linguaManager);
        }

        public void CaricaRicetta(string idFormato)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                this.idFormato = idFormato;

                this.algoritmoWizard?.Dispose();
                int idStazione = this.appManager.GetIdStazione();
                this.algoritmoWizard = new Algoritmi.AlgoritmoWizard(this.idCamera, idStazione, this.impostazioni, this.linguaManager);

                HideAllControls();

                DataType.ParametriAlgoritmo parametri = DBL.FormatoManager.ReadParametriAlgoritmo(idFormato, this.idCamera);
                if (parametri == null)
                    parametri = new DataType.ParametriAlgoritmo();

                System.Diagnostics.Debug.WriteLine(string.Format("  - 1 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                this.algoritmoWizard.LoadFiles(idFormato);

                System.Diagnostics.Debug.WriteLine(string.Format("  - 2 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                this.algoritmoWizard.SetAlgoritmoParam(parametri);

                System.Diagnostics.Debug.WriteLine(string.Format("  - 3 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                ucEditExpoGain1.SetAlgoritmo(idFormato, this.algoritmoWizard);

                System.Diagnostics.Debug.WriteLine(string.Format("  - 4 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                ucEditAlgAcetato1.SetAlgoritmo(this.algoritmoWizard);

                // ------------------------------------------------------
                if (parametri.Template != null)
                {
                    ucEditExpoGain1.Visible = true;

                    if (this.impostazioniCamera.TipoCamera == DataType.TipoCamera.Acetato)
                    {
                        ucEditAlgAcetato1.Visible = true;
                    }
                    else if (this.impostazioniCamera.TipoCamera == DataType.TipoCamera.DL)
                    {
                        ucEditAlgAcetato1.Visible = false;
                    }

                    SetDimGrigliaControlli();
                }
                System.Diagnostics.Debug.WriteLine(string.Format("  - 5 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void HideAllControls()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.Visible = false;
            }
        }

        private void SetDimGrigliaControlli()
        {
            int cnt = 0;
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c.Visible)
                    cnt++;
            }

            tableLayoutPanel1.Size = new Size(tableLayoutPanel1.Width, (cnt * 70) + 5);
        }

        public void Salva()
        {
            try
            {
                this.algoritmoWizard.SaveFiles(idFormato);

                DBL.FormatoManager.WriteParametriAlgoritmo(this.idFormato, this.idCamera, this.algoritmoWizard.GetAlgoritmoParam());
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void Uc_OnComplete(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}