using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class FormNumericInput : Form
    {

        private decimal min;
        private decimal max;
        private int decimalNum;
        private string toStringFormat;
        private bool firstKey = true;

        public decimal Value
        {
            get
            {
                if (lblValue.Text.Length > 12)
                    lblValue.Text = lblValue.Text.Substring(0, 12);
                if (lblValue.Text == ".")
                    lblValue.Text = "0.";
                if (lblValue.Text != "" && lblValue.Text != "-")
                {
                    String val = lblValue.Text.Replace(",", ".").Replace("-.", "-0.");
                    return decimal.Parse(val, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
                }
                else return 0;
            }
        }

        public FormNumericInput(decimal min, decimal max, decimal val, int decimalNum)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.min = min;
            this.max = max;
            toStringFormat = "0";
            if (decimalNum != 0)
            {
                toStringFormat = "0.";
                for (int i = 0; i < decimalNum; i++)
                    toStringFormat += "0";
            }
            lblMinValue.Text = min.ToString(toStringFormat);
            lblMaxValue.Text = max.ToString(toStringFormat);
            lblValue.Text = val.ToString(toStringFormat);
            this.decimalNum = decimalNum;
        }

        private void BtnEsc_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            if (firstKey)
            {
                firstKey = false;
                lblValue.Text = "";
            }
            if (lblValue.Text == "0")
                lblValue.Text = "";
            lblValue.Text += ((Button)sender).Text;
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!lblValue.Text.Contains(".") && !lblValue.Text.Contains(","))
            {
                lblValue.Text += ".";
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (firstKey)
            {
                firstKey = false;
                lblValue.Text = "";
            }
            if (lblValue.Text != "")
            {
                lblValue.Text = lblValue.Text.Remove(lblValue.Text.Length - 1);
                if (lblValue.Text == "-")
                    lblValue.Text = "";
            }
        }

        private void BtnNegative_Click(object sender, EventArgs e)
        {
            if (!lblValue.Text.Contains("-"))
                lblValue.Text = "-" + lblValue.Text;
            else
                lblValue.Text = lblValue.Text.Remove(0, 1);
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (Value >= min && max >= Value)
                DialogResult = DialogResult.OK;
        }

        private void lblValue_Change(object sender, EventArgs e)
        {
            lblMinValue.BackColor = Value >= min ? Color.Lime : Color.Red;
            lblMinValue.ForeColor = Value >= min ? Color.Black : Color.White;
            lblMaxValue.BackColor = Value <= max ? Color.Lime : Color.Red;
            lblMaxValue.ForeColor = Value <= max ? Color.Black : Color.White;
        }

        private void FormNumericInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (firstKey)
            {
                firstKey = false;
                lblValue.Text = "";
            }
            if (lblValue.Text == "0")
                lblValue.Text = "";

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                lblValue.Text += e.KeyChar;
            if (e.KeyChar == '-')
                BtnNegative_Click(this, null);
            if (e.KeyChar == (char)8)
                BtnBack_Click(this, null);
            if (e.KeyChar == '.' || e.KeyChar == ',')
                BtnDot_Click(this, null);
        }

        private void BtnEsc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

    }
}
