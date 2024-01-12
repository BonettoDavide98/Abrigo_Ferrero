using System;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCNumericUpDown : UserControl
    {

        private const int NUM_ITER_DOUBLE_CLICK = 9;
        private const int MS_DOUBLE_CLICK = 200;

        private System.Timers.Timer timerPiu;
        private System.Timers.Timer timerMeno;

        public event EventHandler ValueChanged;

        private DateTime lastClick = DateTime.MinValue;

        public decimal Value
        {
            get { return nud.Value; }
            set
            {
                if (value > nud.Maximum)
                    nud.Value = nud.Maximum;
                else if (value < nud.Minimum)
                    nud.Value = nud.Minimum;
                else
                    nud.Value = value;
            }
        }

        public decimal Increment
        {
            get { return nud.Increment; }
            set { nud.Increment = value; }
        }

        public decimal Maximum
        {
            get { return nud.Maximum; }
            set { nud.Maximum = value; }
        }

        public decimal Minimum
        {
            get { return nud.Minimum; }
            set { nud.Minimum = value; }
        }

        public int DecimalPlaces
        {
            get { return nud.DecimalPlaces; }
            set { nud.DecimalPlaces = value; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return nud.TextAlign; }
            set { nud.TextAlign = value; }
        }


        public UCNumericUpDown()
        {
            InitializeComponent();

            // nascondo le freccie
            nud.Controls[0].Visible = false;
            nud.Controls[1].Width += nud.Controls[0].Width;

            nud.Paint += (object sender, PaintEventArgs e) =>
            {
                e.Graphics.Clear(SystemColors.Window);
            };

            timerPiu = new System.Timers.Timer();
            timerPiu.Interval = 200;
            timerPiu.Elapsed += timerPiu_Elapsed;

            timerMeno = new System.Timers.Timer();
            timerMeno.Interval = 200;
            timerMeno.Elapsed += timerMeno_Elapsed;
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            EventHandler eh = ValueChanged;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        private void SetNewVal(decimal newValue)
        {
            if (newValue > Maximum)
            {
                newValue = Maximum;
            }

            if (newValue < Minimum)
            {
                newValue = Minimum;
            }

            this.Value = newValue;
        }


        private void btnPiu_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - this.lastClick).TotalMilliseconds < MS_DOUBLE_CLICK)
            {
                SetNewVal(this.Value + NUM_ITER_DOUBLE_CLICK * this.Increment);
            }
            else
            {
                nud.UpButton();
            }
            this.lastClick = DateTime.Now;
        }

        private void btnPiu_MouseDown(object sender, MouseEventArgs e)
        {
            timerPiu.Interval = 500;
            timerPiu.Start();
        }

        private void btnPiu_MouseUp(object sender, MouseEventArgs e)
        {
            timerPiu.Stop();
        }




        private void btnMeno_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - this.lastClick).TotalMilliseconds < MS_DOUBLE_CLICK)
            {
                SetNewVal(this.Value - NUM_ITER_DOUBLE_CLICK * this.Increment);
            }
            else
            {
                nud.DownButton();
            }
            this.lastClick = DateTime.Now;

        }

        private void btnMeno_MouseDown(object sender, MouseEventArgs e)
        {
            timerMeno.Interval = 500;
            timerMeno.Start();
        }

        private void btnMeno_MouseUp(object sender, MouseEventArgs e)
        {
            timerMeno.Stop();
        }


        private void timerPiu_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() => nud.UpButton()));
            timerPiu.Interval = 200;
        }

        private void timerMeno_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new Action(() => nud.DownButton()));
            timerMeno.Interval = 200;
        }

        private void nud_Enter(object sender, EventArgs e)
        {
            //Utilities.KeyBoardOsk.showKeypad(this.Handle);
        }

        private void nud_Click(object sender, EventArgs e)
        {
            //Utilities.KeyBoardOsk.showKeypad(this.Handle); 
            FormNumericInput f = new FormNumericInput(this.Minimum, this.Maximum, this.Value, this.DecimalPlaces);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Value = Math.Round(f.Value, this.DecimalPlaces);
                ValueChanged?.Invoke(this, null);
            }
        }

    }
}