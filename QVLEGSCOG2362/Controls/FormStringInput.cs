using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormStringInput : Form
    {

        public string Testo = string.Empty;
        private string testoInit = string.Empty;

        private UCTastieraMaiuscola UCMai = null;
        private UCTastieraNumerica UCNum = null;
        private UCTastieraMinuscola UCMin = null;

        private bool finito = false;
        private int selectionStart;


        public FormStringInput(string testoIniziale, int selectionStart, bool useSystemPasswordChar)
        {
            InitializeComponent();

            txtScritto.UseSystemPasswordChar = useSystemPasswordChar;
            txtScritto.Text = testoIniziale;
            txtScritto.SelectionStart = selectionStart;
            this.selectionStart = selectionStart;
            testoInit = testoIniziale;
            UCMai = new UCTastieraMaiuscola();
            UCNum = new UCTastieraNumerica();
            UCMin = new UCTastieraMinuscola();

            panel.Controls.Add(UCMin);
            UCMai.Dock = DockStyle.Fill;

            panel.Controls.Add(UCMin);
            UCNum.Dock = DockStyle.Fill;

            UCMin.OnChangeLayoutMai += OnChangeLayoutMai;
            UCMin.OnChangeLayoutNum += OnChangeLayoutNum;
            UCMin.OnCloseTastiera += OnCloseTastiera;
            UCMin.OnDeleteChar += OnDeleteChar;
            UCMin.OnWriteChar += OnWriteChar;
        }

        private void OnChangeLayoutNum(object sender, StringEventArgs valore)
        {
            try
            {
                //Tolgo gli eventi
                foreach (var item in panel.Controls)
                {
                    if (item is UCTastieraMinuscola)
                    {
                        UCMin.OnChangeLayoutMai -= OnChangeLayoutMai;
                        UCMin.OnChangeLayoutNum -= OnChangeLayoutNum;
                        UCMin.OnCloseTastiera -= OnCloseTastiera;
                        UCMin.OnDeleteChar -= OnDeleteChar;
                        UCMin.OnWriteChar -= OnWriteChar;
                    }
                    else if (item is UCTastieraMaiuscola)
                    {
                        UCMai.OnChangeLayoutNum -= OnChangeLayoutNum;
                        UCMai.OnChangeLayoutMin -= OnChangeLayoutMin;
                        UCMai.OnCloseTastiera -= OnCloseTastiera;
                        UCMai.OnDeleteChar -= OnDeleteChar;
                        UCMai.OnWriteChar -= OnWriteChar;
                    }
                }
                panel.Controls.Clear();
                panel.Controls.Add(UCNum);
                UCNum.Dock = DockStyle.Fill;

                UCNum.OnChangeLayoutMin += OnChangeLayoutMin;
                UCNum.OnChangeLayoutMai += OnChangeLayoutMai;
                UCNum.OnCloseTastiera += OnCloseTastiera;
                UCNum.OnDeleteChar += OnDeleteChar;
                UCNum.OnWriteChar += OnWriteChar;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OnChangeLayoutMin(object sender, StringEventArgs valore)
        {
            try
            {
                //Tolgo gli eventi
                foreach (var item in panel.Controls)
                {
                    if (item is UCTastieraNumerica)
                    {
                        UCNum.OnChangeLayoutMin -= OnChangeLayoutMin;
                        UCNum.OnChangeLayoutMai -= OnChangeLayoutMai;
                        UCNum.OnCloseTastiera -= OnCloseTastiera;
                        UCNum.OnDeleteChar -= OnDeleteChar;
                        UCNum.OnWriteChar -= OnWriteChar;
                    }
                    else if (item is UCTastieraMaiuscola)
                    {
                        UCMai.OnChangeLayoutNum -= OnChangeLayoutNum;
                        UCMai.OnChangeLayoutMin -= OnChangeLayoutMin;
                        UCMai.OnCloseTastiera -= OnCloseTastiera;
                        UCMai.OnDeleteChar -= OnDeleteChar;
                        UCMai.OnWriteChar -= OnWriteChar;
                    }
                }
                panel.Controls.Clear();
                panel.Controls.Add(UCMin);
                UCNum.Dock = DockStyle.Fill;

                UCMin.OnChangeLayoutMai += OnChangeLayoutMai;
                UCMin.OnChangeLayoutNum += OnChangeLayoutNum;
                UCMin.OnCloseTastiera += OnCloseTastiera;
                UCMin.OnDeleteChar += OnDeleteChar;
                UCMin.OnWriteChar += OnWriteChar;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OnChangeLayoutMai(object sender, StringEventArgs valore)
        {
            try
            {
                //Tolgo gli eventi
                foreach (var item in panel.Controls)
                {
                    if (item is UCTastieraMinuscola)
                    {
                        UCMin.OnChangeLayoutMai -= OnChangeLayoutMai;
                        UCMin.OnChangeLayoutNum -= OnChangeLayoutNum;
                        UCMin.OnCloseTastiera -= OnCloseTastiera;
                        UCMin.OnDeleteChar -= OnDeleteChar;
                        UCMin.OnWriteChar -= OnWriteChar;
                    }
                    else if (item is UCTastieraNumerica)
                    {
                        UCNum.OnChangeLayoutMin -= OnChangeLayoutMin;
                        UCNum.OnChangeLayoutMai -= OnChangeLayoutMai;
                        UCNum.OnCloseTastiera -= OnCloseTastiera;
                        UCNum.OnDeleteChar -= OnDeleteChar;
                        UCNum.OnWriteChar -= OnWriteChar;
                    }
                }

                panel.Controls.Clear();
                panel.Controls.Add(UCMai);
                UCNum.Dock = DockStyle.Fill;

                UCMai.OnChangeLayoutNum += OnChangeLayoutNum;
                UCMai.OnChangeLayoutMin += OnChangeLayoutMin;
                UCMai.OnCloseTastiera += OnCloseTastiera;
                UCMai.OnDeleteChar += OnDeleteChar;
                UCMai.OnWriteChar += OnWriteChar;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OnCloseTastiera(object sender, StringEventArgs valore)
        {
            try
            {
                Testo = txtScritto.Text;
                finito = true;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OnDeleteChar(object sender, StringEventArgs valore)
        {
            try
            {
                if (txtScritto.Text.Length > 0)
                {
                    this.selectionStart = this.selectionStart - 1;

                    if (this.selectionStart >= 0)
                        txtScritto.Text = txtScritto.Text.Remove(this.selectionStart, 1);
                }

                if (this.selectionStart < 0)
                    this.selectionStart = 0;
                txtScritto.SelectionStart = this.selectionStart;


                //if (txtScritto.Text.Length > 0)
                //  txtScritto.Text = txtScritto.Text.Substring(0, txtScritto.Text.Length - 1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void OnWriteChar(object sender, StringEventArgs valore)
        {
            try
            {
                //txtScritto.Text.Substring(txtScritto.SelectionStart, (txtScritto.Text.Length - txtScritto.SelectionStart - 1));

                txtScritto.Text = txtScritto.Text.Insert(txtScritto.SelectionStart, valore.Value);
                this.selectionStart = txtScritto.SelectionStart = this.selectionStart + 1;
                //txtScritto.Text += valore.Value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Tastiera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!finito)
                Testo = testoInit;
        }

        private void txtScritto_Click(object sender, EventArgs e)
        {
            try
            {
                this.selectionStart = txtScritto.SelectionStart;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
