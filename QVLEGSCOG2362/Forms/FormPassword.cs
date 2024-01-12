using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormPassword : Form
    {

        DataType.Impostazioni impostazioni;

        public FormPassword(DataType.Impostazioni impostazioni)
        {
            InitializeComponent();
            this.impostazioni = impostazioni;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == impostazioni.Password)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Password errata.", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            FormStringInput f = new FormStringInput(txtPass.Text, 0, true);
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtPass.Text = f.Testo;
            }
        }

    }
}