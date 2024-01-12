using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormWait : Form
    {
        public FormWait(string msg,DBL.LinguaManager linguaManager)
        {
            InitializeComponent();

            label1.Text = linguaManager.GetTranslation(msg);
        }
    }
}
