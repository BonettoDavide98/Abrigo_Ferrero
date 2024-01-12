using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FrmGestioneTurni : Form
    {

        private List<DataType.Definizione_Turni> listaTurni = null;
        private DBL.LinguaManager linguaManager;

        public FrmGestioneTurni(DBL.LinguaManager linguaManager)
        {
            InitializeComponent();
            this.linguaManager = linguaManager;

            this.Text = this.linguaManager.GetTranslation("BTN_GESTIONE_TURNI");
            btnAggiungi.Text = this.linguaManager.GetTranslation("BTN_ADD");
            btnElimina.Text = this.linguaManager.GetTranslation("BTN_DELETE");
            btnModifica.Text = this.linguaManager.GetTranslation("BTN_EDIT");

            this.turniDataGridView.Columns[0].HeaderText = this.linguaManager.GetTranslation("LBL_NOMETURNO");
            this.turniDataGridView.Columns[1].HeaderText = this.linguaManager.GetTranslation("LBL_INIZIO_TURNO");
            this.turniDataGridView.Columns[2].HeaderText = this.linguaManager.GetTranslation("LBL_FINE_TURNO");
            this.turniDataGridView.Columns[3].HeaderText = this.linguaManager.GetTranslation("LBL_GIORNO");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                listaTurni = new List<DataType.Definizione_Turni>();

                RefreshDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefreshDgv()
        {
            if (listaTurni.Count > 0)
                listaTurni.Clear();

            listaTurni = DBL.GestioneTurniManager.ReadAllOrariTurni(Properties.Settings.Default.ConnectionString);

            orariTurniBindingSource.DataSource = listaTurni;
            orariTurniBindingSource.ResetBindings(true);
            turniDataGridView.Refresh();

        }

        private void btnAggiungi_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAggiungiModificaTurno frm = new FrmAggiungiModificaTurno(true, null, this.linguaManager);
                frm.ShowDialog();

                if (!frm.Ok)
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_ERROR_TURNI"));

                RefreshDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (turniDataGridView.SelectedRows.Count == 1)
                {
                    DataType.Definizione_Turni f = (DataType.Definizione_Turni)turniDataGridView.SelectedRows[0].DataBoundItem;

                    FrmAggiungiModificaTurno frm = new FrmAggiungiModificaTurno(false, f, this.linguaManager);
                    frm.ShowDialog();

                    if (!frm.Ok)
                        MessageBox.Show(this.linguaManager.GetTranslation("MSG_ERROR_TURNI"));

                    RefreshDgv();
                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_SELECT_ROW"), this.linguaManager.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (turniDataGridView.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show(this.linguaManager.GetTranslation("MSG_DELETE_TURNO_QUESTION"), this.linguaManager.GetTranslation("MSG_DELETE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataType.Definizione_Turni f = (DataType.Definizione_Turni)turniDataGridView.SelectedRows[0].DataBoundItem;

                        DBL.GestioneTurniManager.DeleteDefinizioneTurni(Properties.Settings.Default.ConnectionString, f.NomeTurno);
                        RefreshDgv();
                    }
                }
                else
                    MessageBox.Show(this.linguaManager.GetTranslation("MSG_SELECT_ROW"), this.linguaManager.GetTranslation("MSG_ERRORE"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
