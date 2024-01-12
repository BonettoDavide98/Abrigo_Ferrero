using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat4Dettaglio : UserControl
    {

        public class ObjCmb
        {
            public string Colonna { get; set; }
            public string Descrizione { get; set; }
        }

        private int idStazione = -1;
        private DBL.LinguaManager linguaManager = null;

        //private DataTable dt = null;

        public UCPaginaViewStat4Dettaglio()
        {
            InitializeComponent();
        }

        public void Init(int idStazione, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.idStazione = idStazione;
                this.linguaManager = linguaManager;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblFiltroFrom.Text = linguaManager.GetTranslation("LBL_FILTRO_FROM");
            lblFiltroTo.Text = linguaManager.GetTranslation("LBL_FILTRO_TO");
            btnCerca.Text = linguaManager.GetTranslation("BTN_CERCA");
            btnExport.Text = linguaManager.GetTranslation("BTN_EXPORT");
        }

        private void RefreshGrafico(DateTime from, DateTime to)
        {
            try
            {
                DataTable dt = DBL.StatisticheManager.GetDatiGraficoTipoScarto(this.idStazione, from, to);
                MostraGrafico(dt, chartTurnoPrecedente);
            }
            catch (Exception ex)
            {
                //TODO MessageBox.Show(ex.ToString());
            }
        }

        private void Export(DataTable dt, string fileName)
        {
            try
            {
                DataTable ret = new DataTable();
                ret.Columns.Add(new DataColumn("Data", typeof(DateTime)));
                ret.Columns.Add(new DataColumn("Ora", typeof(int)));


                string content = string.Empty;

                DateTime prevData = DateTime.MinValue;
                int prevOra = -1;

                DataRow lastRow = null;

                foreach (DataRow item in dt.Rows)
                {
                    string chiave = (string)item["Chiave"];
                    int valore = (int)item["Valore"];
                    DateTime data = (DateTime)item["Data"];
                    int ora = (int)item["Ora"];

                    if (prevData != data || prevOra != ora)
                    {
                        lastRow = ret.Rows.Add();

                        lastRow["Data"] = data;
                        lastRow["Ora"] = ora;

                        prevData = data;
                        prevOra = ora;
                    }

                    if (!ret.Columns.Contains(chiave))
                    {
                        ret.Columns.Add(new DataColumn(chiave, typeof(int)));
                    }

                    if (lastRow != null)
                    {
                        lastRow[chiave] = valore;
                    }

                    //string nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + chiave);

                    //content += string.Format("{0};{1};{2};{3}\n\r", nomeColonna, valore, data.ToString("yyyy/MM/dd"), ora);
                }


                foreach (DataColumn item in ret.Columns)
                {
                    string nomeColonna = "";

                    if (item.ColumnName == "Data")
                        nomeColonna = "Date";
                    else if (item.ColumnName == "Ora")
                        nomeColonna = "Time";
                    else
                        nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + item.ColumnName);

                    content += nomeColonna + ";";
                }

                content += "\n\r";

                foreach (DataRow item in ret.Rows)
                {

                    foreach (DataColumn item2 in ret.Columns)
                    {
                        string val = "";

                        if (item2.ColumnName == "Data")
                            val = ((DateTime)item[item2.ColumnName]).ToString("yyyy/MM/dd");

                        else
                            val = ((int)item[item2.ColumnName]).ToString();

                        content += val + ";";
                    }

                    content += "\n\r";
                    //content += string.Format("{0};{1};{2};{3}\n\r", nomeColonna, valore, data.ToString("yyyy/MM/dd"), ora);
                }


                System.IO.File.WriteAllText(fileName, content);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void ExportOK(DataTable dt, string fileName)
        {
            try
            {
                string content = string.Empty;

                foreach (DataRow item in dt.Rows)
                {
                    string chiave = (string)item["Chiave"];
                    int valore = (int)item["Valore"];
                    DateTime data = (DateTime)item["Data"];
                    int ora = (int)item["Ora"];

                    string nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + chiave);

                    content += string.Format("{0};{1};{2};{3}\n\r", nomeColonna, valore, data.ToString("yyyy/MM/dd"), ora);
                }

                System.IO.File.WriteAllText(fileName, content);
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void MostraGrafico(DataTable dt, Chart chart)
        {
            try
            {
                Color[] colors = new Color[]
                {
                    Color.Green,
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

                foreach (DataRow item in dt.Rows)
                {
                    string chiave = (string)item["Chiave"];
                    int valore = (int)item["Valore"];

                    string nomeColonna = this.linguaManager.GetTranslation("LBL_GRAFICO_" + chiave);
                    if (valore > 0)
                    {
                        int idx = chart.Series[0].Points.AddXY(nomeColonna, valore);
                        chart.Series[0].Points[idx].Color = colors[idx];

                        chart.Series[0].Points[idx].Label = nomeColonna + ": " + valore;
                    }

                }
                chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            }
            catch (Exception ex) { }
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from = new DateTime(dtFromData.Value.Year, dtFromData.Value.Month, dtFromData.Value.Day, dtFromTempo.Value.Hour, dtFromTempo.Value.Minute, 0);
                DateTime to = new DateTime(dtToData.Value.Year, dtToData.Value.Month, dtToData.Value.Day, dtToTempo.Value.Hour, dtToTempo.Value.Minute, 0);
                if (from < to)
                {
                    RefreshGrafico(from, to);
                    btnExport.Enabled = true;
                }
                else
                {
                    MessageBox.Show(linguaManager.GetTranslation("MSG_FILTRI_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Image|*.csv";
                    sfd.Title = "Export";
                    sfd.FileName = string.Format("{0}.csv", DateTime.Now.ToString("yyyyMMdd_HH_mm_ss.fff"));
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DateTime from = new DateTime(dtFromData.Value.Year, dtFromData.Value.Month, dtFromData.Value.Day, dtFromTempo.Value.Hour, dtFromTempo.Value.Minute, 0);
                        DateTime to = new DateTime(dtToData.Value.Year, dtToData.Value.Month, dtToData.Value.Day, dtToTempo.Value.Hour, dtToTempo.Value.Minute, 0);
                        if (from < to)
                        {
                            DataTable dt = DBL.StatisticheManager.GetDatiGraficoTipoScartoExport(this.idStazione, from, to);
                            Export(dt, sfd.FileName);
                        }
                        else
                        {
                            MessageBox.Show(linguaManager.GetTranslation("MSG_FILTRI_KO"), linguaManager.GetTranslation("MSG_ATTENZIONE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

    }
}