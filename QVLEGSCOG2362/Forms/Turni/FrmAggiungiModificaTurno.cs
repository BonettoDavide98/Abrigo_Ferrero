using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FrmAggiungiModificaTurno : Form
    {

        private bool isNewOrario;
        private DataType.Definizione_Turni orarioToEdit;

        public bool Ok = false;
        private DBL.LinguaManager linguaManager;

        public FrmAggiungiModificaTurno(bool isNewOrario, DataType.Definizione_Turni orarioToEdit, DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            this.linguaManager = linguaManager;
            this.isNewOrario = isNewOrario;
            this.orarioToEdit = orarioToEdit;

            this.Text = this.linguaManager.GetTranslation("LBL_TITOLO_NEW_TURNO");
            lblID.Text = this.linguaManager.GetTranslation("LBL_NOMETURNO");
            lblInizio.Text = this.linguaManager.GetTranslation("LBL_INIZIO_TURNO");
            lblFine.Text = this.linguaManager.GetTranslation("LBL_FINE_TURNO");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                if (isNewOrario)
                    txtID.Text = (DBL.GestioneTurniManager.GetMaxIdOrariTurni(Properties.Settings.Default.ConnectionString) + 1).ToString();
                else
                {
                    txtID.Text = orarioToEdit.NomeTurno.ToString();

                    dateTimePickerInizio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, orarioToEdit.OraInizioTurno.Hours, orarioToEdit.OraInizioTurno.Minutes, orarioToEdit.OraInizioTurno.Seconds);
                    dateTimePickerFine.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, orarioToEdit.OraFineTurno.Hours, orarioToEdit.OraFineTurno.Minutes, orarioToEdit.OraFineTurno.Seconds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool ControllaCampi()
        {
            if (txtID.Text.Trim().Length > 0)
                return true;
            return false;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControllaCampi())
                {
                    if (isNewOrario)
                        orarioToEdit = new DataType.Definizione_Turni();

                    orarioToEdit.NomeTurno = Convert.ToInt16(txtID.Text);
                    orarioToEdit.OraInizioTurno = new TimeSpan(dateTimePickerInizio.Value.Hour, dateTimePickerInizio.Value.Minute, dateTimePickerInizio.Value.Second);
                    orarioToEdit.OraFineTurno = new TimeSpan(dateTimePickerFine.Value.Hour, dateTimePickerFine.Value.Minute, dateTimePickerFine.Value.Second);

                    Ok = DBL.GestioneTurniManager.InsertUpdateDefinizioneTurni(Properties.Settings.Default.ConnectionString, orarioToEdit);

                    this.Close();
                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_RIEMPIRE_CAMPI"), this.linguaManager.GetTranslation("MSG_ATTENTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Ok = true;
            this.Close();
        }

    }
}
