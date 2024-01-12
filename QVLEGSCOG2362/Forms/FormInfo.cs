using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormInfo : Form
    {
        public FormInfo(DBL.LinguaManager linguaManager)
        {
            InitializeComponent();
             
            lblBusinessName.Text = linguaManager.GetTranslation("BUSINESS_NAME");
            lblOfficePhoneNumber.Text = linguaManager.GetTranslation("OFFICE_PHONE_NUMBER");
            lblAddress.Text = linguaManager.GetTranslation("ADDRESS");
            lblEmail.Text = linguaManager.GetTranslation("EMAIL");
            BtnCancel.Text = linguaManager.GetTranslation("EXIT");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
