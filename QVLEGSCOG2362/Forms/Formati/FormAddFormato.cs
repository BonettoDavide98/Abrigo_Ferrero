using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormAddFormato : Form
    {

        private int numCamere = -1;
        private DataType.Impostazioni impostazioni = null;
        private DBL.LinguaManager linguaManager = null;

        public FormAddFormato(int numCamere, DataType.Impostazioni impostazioni, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.numCamere = numCamere;
            this.impostazioni = impostazioni;
            this.linguaManager = linguaManager;

            this.Text = linguaManager.GetTranslation("LBL_FRM_ADD_FORMATO");
            lblId.Text = linguaManager.GetTranslation("LBL_ID");
            lblDescrizione.Text = linguaManager.GetTranslation("LBL_DESCRIZIONE");
            rbTemplate1.Text = linguaManager.GetTranslation("LBL_TEMPLATE_1");
            rbTemplate2.Text = linguaManager.GetTranslation("LBL_TEMPLATE_2");
            rbModoSingolo.Text = linguaManager.GetTranslation("LBL_MODO_SINGOLO");
            rbModoScatola.Text = linguaManager.GetTranslation("LBL_MODO_SCATOLA");
            btnSalva.Text = linguaManager.GetTranslation("BTN_SALVA");
            btnAnnulla.Text = linguaManager.GetTranslation("BTN_ANNULLA");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                if (impostazioni.AbilitaSceltaModo == false)
                {
                    this.Height -= tbModo.Height;
                    tbModo.Visible = false;
                }
            }
            catch (Exception) { }
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

        private string GetTemplateName()
        {
            if (rbTemplate1.Checked)
            {
                return DataType.TemplateFormato.Template1.Name;
            }
            else if (rbTemplate2.Checked)
            {
                return DataType.TemplateFormato.Template2.Name;
            }
            else
            {
                return null;
            }
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
                    DataType.Formato f = new DataType.Formato();

                    f.IdFormato = txtId.Text;
                    f.DescrizioneFormato = txtDescrizione.Text;

                    DataType.ParametriAlgoritmo par = new DataType.ParametriAlgoritmo()
                    {
                        TemplateName = GetTemplateName()
                    };

                    DBL.FormatoManager.AddNewFormato(f);
                    for (int i = 0; i < this.numCamere; i++)
                    {
                        string pathMaster = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "GMM_MASTER", (i + 1).ToString());
                        string pathDest = System.IO.Path.Combine(this.impostazioni.PathDatiBase, "RICETTE", f.IdFormato, "GMM", (i + 1).ToString());

                        Utilities.CommonUtility.DirectoryCopy(pathMaster, pathDest, true);

                        DBL.FormatoManager.WriteParametriAlgoritmo(f.IdFormato, i, par);
                    }

                    this.DialogResult = DialogResult.OK;
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
