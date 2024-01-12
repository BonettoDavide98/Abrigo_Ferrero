using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormCopiaFormato : Form
    {

        private int numCamere = -1;
        private DataType.Impostazioni impostazioni = null;
        private string idFormato = null;
        private DBL.LinguaManager linguaManager = null;

        public FormCopiaFormato(int numCamere, DataType.Impostazioni impostazioni, string idFormato, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.numCamere = numCamere;
            this.impostazioni = impostazioni;
            this.idFormato = idFormato;
            this.linguaManager = linguaManager;

            this.Text = linguaManager.GetTranslation("LBL_FRM_COPY_FORMATO");
            lblId.Text = linguaManager.GetTranslation("LBL_ID");
            lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE");
            btnSalva.Text = linguaManager.GetTranslation("BTN_SALVA");
            btnAnnulla.Text = linguaManager.GetTranslation("BTN_ANNULLA");
        }

        private bool ValidateForm()
        {
            bool ret = true;

            string id = txtId.Text;

            ret = !DBL.FormatoManager.EsisteFormato(id);
            if (!ret)
                MessageBox.Show(linguaManager.GetTranslation("MSG_ID_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (string.IsNullOrWhiteSpace(txtDescrizione.Text))
            {
                ret = false;
                MessageBox.Show(linguaManager.GetTranslation("MSG_DESCRIZIONE_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ret;
        }

        #region Eventi form

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    try
                    {
                        DataType.Formato f = new DataType.Formato();

                        f.IdFormato = txtId.Text;
                        f.DescrizioneFormato = txtDescrizione.Text;

                        DBL.FormatoManager.AddNewFormato(f);
                        for (int i = 0; i < this.numCamere; i++)
                        {
                            DataType.ParametriAlgoritmo par = DBL.FormatoManager.ReadParametriAlgoritmo(this.idFormato, i);
                            DBL.FormatoManager.WriteParametriAlgoritmo(f.IdFormato, i, par);
                        }

                        string pathMaster = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "RICETTE", this.idFormato);
                        string pathDest = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "RICETTE", f.IdFormato);

                        Utilities.CommonUtility.DirectoryCopy(pathMaster, pathDest, true);

                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception)
                    {
                        // ERRORE DURANTE LA COPIA
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            //Utilities.KeyBoardOsk.showKeypad(this.Handle);
            FormStringInput f = new FormStringInput(txtId.Text, 0, false);
            if (f.ShowDialog() == DialogResult.OK)
                txtId.Text = f.Testo;
        }


        private void txt_DescrizioneEnter(object sender, EventArgs e)
        {
            FormStringInput f = new FormStringInput(txtDescrizione.Text, 0, false);
            if (f.ShowDialog() == DialogResult.OK)
                txtDescrizione.Text = f.Testo;
        }


        #endregion Eventi form

    }
}
