using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCTastieraMaiuscola : UserControl
    {
        public event EventHandler<StringEventArgs> OnChangeLayoutMin = null;
        public event EventHandler<StringEventArgs> OnChangeLayoutNum = null;
        public event EventHandler<StringEventArgs> OnCloseTastiera = null;
        public event EventHandler<StringEventArgs> OnDeleteChar = null;
        public event EventHandler<StringEventArgs> OnWriteChar = null;

        public UCTastieraMaiuscola()
        {
            InitializeComponent();
        }

        private void btnChangeMinuscole_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            //chiamo evento cambia layout min
            OnChangeLayoutMin?.Invoke(this, data);
        }

        private void btnChangeNumeri_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            //chiamo evento cambia layput num
            OnChangeLayoutNum?.Invoke(this, data);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            //chiamo evento chiudi tastiera
            OnCloseTastiera?.Invoke(this, data);

        }

        private void buttonCanc_Click(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = "";
            //chiamo evento cancella una lettera
            OnDeleteChar?.Invoke(this, data);
        }

        private void onAnyButtonClick(object sender, EventArgs e)
        {
            var data = new StringEventArgs();
            data.Value = ((Button)sender).Text;
            OnWriteChar?.Invoke(this, data);
        }
    }
}
