using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QVLEGSCOG2362
{
    public partial class UCEditSoglia : UserControl
    {

        private string key = string.Empty;
        private Algoritmi.AlgoritmoLavoro algoritmo = null;
        private VerticalLineAnnotation vaMinimo = null;
        private VerticalLineAnnotation vaMassimo = null;

        private const int maxNumIntervalli = 40;

        public UCEditSoglia()
        {
            InitializeComponent();
            AddChangeEvent();
        }

        public void Init(string descrizione, Algoritmi.AlgoritmoLavoro algoritmo, DBL.LinguaManager linguaManager)
        {
            this.key = descrizione;
            this.algoritmo = algoritmo;

            lblDescrizione.Text = linguaManager.GetTranslation("LBL_D_" + descrizione);

            chart1.Annotations.Clear();
            ChartArea CA = chart1.ChartAreas[0];

            chart1.Series["Series1"]["PixelPointWidth"] = "5";

            //CA.AxisX.Maximum = 10000;
            //CA.AxisX.Minimum = 0;

            double[] soglie = algoritmo.GetSoglieByKey(this.key);

            // the vertical line
            vaMinimo = new VerticalLineAnnotation();
            vaMinimo.AxisX = CA.AxisX;
            vaMinimo.AllowMoving = true;
            vaMinimo.IsInfinitive = true;
            vaMinimo.ClipToChartArea = CA.Name;
            vaMinimo.Name = "vaSogliaMin";
            vaMinimo.LineColor = Color.Red;
            vaMinimo.LineWidth = 5;         // use your numbers!
            vaMinimo.X = soglie[0];

            chart1.Annotations.Add(vaMinimo);

            if (soglie.Length > 1)
            {
                // the vertical line
                vaMassimo = new VerticalLineAnnotation();
                vaMassimo.AxisX = CA.AxisX;
                vaMassimo.AllowMoving = true;
                vaMassimo.IsInfinitive = true;
                vaMassimo.ClipToChartArea = CA.Name;
                vaMassimo.Name = "vaSogliaMax";
                vaMassimo.LineColor = Color.Green;
                vaMassimo.LineWidth = 5;         // use your numbers!
                vaMassimo.X = soglie[1];

                chart1.Annotations.Add(vaMassimo);
            }
            else
            {
                vaMassimo = null;
            }

            AggiornaGrafica();
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            if (!string.IsNullOrWhiteSpace(this.key))
                lblDescrizione.Text = linguaManager.GetTranslation("LBL_D_" + this.key);
        }


        public void DrawData(Dictionary<int, int> valori)
        {
            Series s1 = chart1.Series[0];
            s1.ChartType = SeriesChartType.Column;

            s1.Points.Clear();

            if (valori.Count > 0)
            {
                double b = Algoritmi.AlgoritmoLavoro.GetBucketByKey(this.key);

                ChartArea CA = chart1.ChartAreas[0];

                double min = valori.Keys.Min() * b;
                double max = valori.Keys.Max() * b;

                if (min > vaMinimo.X)
                {
                    min = vaMinimo.X;
                }

                if (max < vaMinimo.X)
                {
                    max = vaMinimo.X;
                }

                if (vaMassimo != null)
                {
                    if (min > vaMassimo.X)
                    {
                        min = vaMassimo.X;
                    }
                }

                if (vaMassimo != null)
                {
                    if (max < vaMassimo.X)
                    {
                        max = vaMassimo.X;
                    }

                    if (max < vaMassimo.X)
                    {
                        max = vaMassimo.X;
                    }
                }

                min -= 2 * b;
                max += 2 * b;

                CA.AxisX.Maximum = ((int)(max / b) + 1) * b;
                CA.AxisX.Minimum = ((int)(min / b) - 1) * b;

                double diff = CA.AxisX.Maximum - CA.AxisX.Minimum;
                double interval = Math.Round((diff / maxNumIntervalli), 1);

                CA.AxisX.Interval = interval;
                CA.AxisX.IntervalOffset = (-CA.AxisX.Minimum) % CA.AxisX.Interval;

                foreach (var v in valori)
                {
                    s1.Points.AddXY(v.Key * b, v.Value);
                }

                foreach (var item in s1.Points)
                {
                    item.ToolTip = Math.Round(item.XValue, 3).ToString();
                }
            }
        }

        public void SaveData()
        {
            try
            {
                double[] soglie = null;

                if (vaMassimo == null)
                {
                    soglie = new double[] { vaMinimo.X };
                }
                else
                {
                    soglie = new double[] { vaMinimo.X, vaMassimo.X };
                }

                this.algoritmo.SetSoglieByKey(this.key, soglie);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AggiornaGrafica()
        {
            RemoveChangeEvent();
            try
            {
                nudMin.Value = (decimal)vaMinimo.X;

                if (vaMassimo != null)
                {
                    nudMax.Visible = true;
                    nudMax.Value = (decimal)vaMassimo.X;
                }
                else
                {
                    nudMax.Visible = false;
                }
            }
            finally
            {
                AddChangeEvent();
            }
        }

        private void AddChangeEvent()
        {
            nudMin.ValueChanged += nud_ValueChanged;
            nudMax.ValueChanged += nud_ValueChanged;
        }

        private void RemoveChangeEvent()
        {
            nudMin.ValueChanged -= nud_ValueChanged;
            nudMax.ValueChanged -= nud_ValueChanged;
        }

        private void chart1_AnnotationPositionChanged(object sender, EventArgs e)
        {
            ChartArea CA = chart1.ChartAreas[0];
            VerticalLineAnnotation lineAnnotation = sender as VerticalLineAnnotation;

            if (lineAnnotation.X < CA.AxisX.Minimum)
                lineAnnotation.X = CA.AxisX.Minimum;

            if (lineAnnotation.X > CA.AxisX.Maximum)
                lineAnnotation.X = CA.AxisX.Maximum;

            //VA.X = (int)(VA.X + 0.5);
            //RA.X = VA.X - RA.Width / 2;
        }

        private void chart1_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {
            /*
            // move the rectangle with the line
            if (sender == VA) RA.X = VA.X - RA.Width / 2;

            // display the current Y-value
            int pt1 = (int)e.NewLocationX;
            double step = (S1.Points[pt1 + 1].YValues[0] - S1.Points[pt1].YValues[0]);
            double deltaX = e.NewLocationX - S1.Points[pt1].XValue;
            double val = S1.Points[pt1].YValues[0] + step * deltaX;
            //chart1.Titles[0].Text = String.Format("X = {0:0.00}   Y = {1:0.00}", e.NewLocationX, val);
            RA.Text = String.Format("{0:0.00}", val);
            chart1.Update();
            */

            AggiornaGrafica();
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                vaMinimo.X = (double)nudMin.Value;
                if (vaMassimo != null)
                    vaMassimo.X = (double)nudMax.Value;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}