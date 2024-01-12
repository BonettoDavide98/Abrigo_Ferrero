using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat1Dettaglio : UserControl
    {

        private int idStazione = -1;
        private DBL.LinguaManager linguaManager = null;

        public UCPaginaViewStat1Dettaglio()
        {
            InitializeComponent();
        }

        public void Init(int idStazione, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.idStazione = idStazione;
                this.linguaManager = linguaManager;

                RefreshGrafico();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTurnoPrecedente.Text = linguaManager.GetTranslation("LBL_TURNO_PRECEDENTE");
            lblTurnoAttuale.Text = linguaManager.GetTranslation("LBL_TURNO_ATTUALE");
            lblUltimaOra.Text = linguaManager.GetTranslation("LBL_ULTIMA_ORA");
        }

        public void RefreshGrafico()
        {
            try
            {
                DataTable dtTurnoPrecedente = DBL.StatisticheManager.GetDatiGraficoTipoScartoTurnoPrecedente(this.idStazione);
                MostraGrafico(dtTurnoPrecedente, chartTurnoPrecedente);
                DataTable dtTurnoAttuale = DBL.StatisticheManager.GetDatiGraficoTipoScartoTurnoAttuale(this.idStazione);
                MostraGrafico(dtTurnoAttuale, chartTurnoAttuale);
                DataTable dtUltimaOra = DBL.StatisticheManager.GetDatiGraficoTipoScartoUltimaOra(this.idStazione);
                MostraGrafico(dtUltimaOra, chartUltimaOra);
            }
            catch (Exception ex)
            {
                //TODO MessageBox.Show(ex.ToString());
            }
        }

        private void MostraGrafico(DataTable dt, Chart chart)
        {
            try
            {
                Color[] colors = new Color[]
                {
                    Color.Red,
                    Color.Khaki,
                    Color.Magenta,
                    Color.Orange,
                    Color.Yellow,
                    Color.Blue,
                    Color.Cyan,
                    Color.LightSteelBlue,
                    Color.Beige,
                    Color.LightSlateGray,
                    Color.DeepPink,
                    Color.Peru,
                    Color.DimGray,
                };

                chart.Series[0].Points.Clear();
                chart.Series[0].IsXValueIndexed = true;
                chart.ChartAreas[0].AxisX.Interval = 1;

                foreach (DataRow item in dt.Rows)
                {
                    string chiave = (string)item["Chiave"];
                    int valore = (int)item["Valore"];

                    string nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + chiave);
                    if (valore > 0)
                    {
                        int idx = chart.Series[0].Points.AddXY(nomeColonna, valore);
                        chart.Series[0].Points[idx].Color = colors[idx];
                        chart.Series[0].Points[idx].LegendText = chiave;

                        chart.Series[0].Points[idx].Label = nomeColonna + ": " + valore;
                    }
                }
                chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            }
            catch (Exception ex) { }
        }

    }
}