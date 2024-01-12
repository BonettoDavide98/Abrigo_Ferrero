using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormImpostazioni : Form
    {

        private DBL.LinguaManager linguaManager = null;

        public FormImpostazioni()
        {
            InitializeComponent();

            DataType.Impostazioni impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();

            propertyGrid1.SelectedObject = impostazioni;

            try
            {
                this.linguaManager = new DBL.LinguaManager(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "lng"));
                this.linguaManager.ChangeLanguage(impostazioni.Lingua1);

                this.Text = linguaManager.GetTranslation("FRM_IMPOSTAZIONI");
                btnUtenti.Text = linguaManager.GetTranslation("BTN_UTENTI");
                btnTurni.Text = linguaManager.GetTranslation("BTN_TURNI");
                btnSalva.Text = linguaManager.GetTranslation("BTN_SALVA");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUtenti_Click(object sender, EventArgs e)
        {
            try
            {
                DataType.Impostazioni impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();
                FrmGestioneUtenti frm = new FrmGestioneUtenti(impostazioni, this.linguaManager);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTurni_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGestioneTurni frm = new FrmGestioneTurni(this.linguaManager);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            DataType.Impostazioni impostazioni = propertyGrid1.SelectedObject as DataType.Impostazioni;

            DBL.ImpostazioniManager.WriteImpostazioni(impostazioni);

            this.Close();
        }

    }
}