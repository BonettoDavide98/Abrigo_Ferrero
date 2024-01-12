using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormSplash : Form
    {

        public FormSplash(DataType.Impostazioni impostazioni)
        {
            InitializeComponent();

            try
            {
                string fileName = System.IO.Path.Combine(impostazioni.PathDatiBase, "RES", "img_logo.png");
                if (System.IO.File.Exists(fileName))
                {
                    pictureBox1.BackgroundImage = new Bitmap(fileName);
                }


                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        private void btnAvvio_Click(object sender, System.EventArgs e)
        {
            btnAvvio.Enabled = false;
            btnConfigurazione.Enabled = false;
        }

        private void btnConfigurazione_Click(object sender, System.EventArgs e)
        {
            //btnAvvio.Enabled = false;
            //btnConfigurazione.Enabled = false;
            //timer1.Enabled = false;
            //FormConfigurazione frm = new FormConfigurazione();
            //frm.ShowDialog();

            //Application.Restart(); 
        }

    }
}
