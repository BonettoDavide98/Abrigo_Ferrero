using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCTastieraMinuscola : UserControl
    {
        public event EventHandler<StringEventArgs> OnChangeLayoutMai = null;
        public event EventHandler<StringEventArgs> OnChangeLayoutNum = null;
        public event EventHandler<StringEventArgs> OnCloseTastiera = null;
        public event EventHandler<StringEventArgs> OnDeleteChar = null;
        public event EventHandler<StringEventArgs> OnWriteChar = null;

        public UCTastieraMinuscola()
        {
            InitializeComponent();
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            OnDeleteChar?.Invoke(this, data);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            OnCloseTastiera?.Invoke(this, data);

        }

        private void btnLayoutNumeri_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            OnChangeLayoutNum?.Invoke(this, data);

        }

        private void btnLayoutMaiuscole_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            OnChangeLayoutMai?.Invoke(this, data);

        }

        private void onAnyButtonClick(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = ((Button)sender).Text;

            OnWriteChar?.Invoke(this, data);
        }
    }
}
