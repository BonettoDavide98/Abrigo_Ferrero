using System;
using System.Data;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewStat3Dettaglio : UserControl
    {

        private int idStazione = -1;
        private DataType.Impostazioni impostazioni = null;

        private double perScartoTurnoPrecedente = 0;
        private double perScartoTurnoAttuale = 0;
        private double perScartoUltimaOra = 0;


        public UCPaginaViewStat3Dettaglio()
        {
            InitializeComponent();
        }

        public void Init(int idStazione, DataType.Impostazioni impostazioni)
        {
            try
            {
                this.idStazione = idStazione;
                this.impostazioni = impostazioni;

                if (!(this.impostazioni.ImpostazioniCamera1.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera1.Attiva))
                {
                    lblCamDescr1.Visible = false;
                    lblPercTurnoPrecedenteCam1.Visible = false;
                    lblPercTurnoAttualeCam1.Visible = false;
                    lblPercUltimaOraCam1.Visible = false;
                }

                if (!(this.impostazioni.ImpostazioniCamera2.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera2.Attiva))
                {
                    lblCamDescr2.Visible = false;
                    lblPercTurnoPrecedenteCam2.Visible = false;
                    lblPercTurnoAttualeCam2.Visible = false;
                    lblPercUltimaOraCam2.Visible = false;
                }

                if (!(this.impostazioni.ImpostazioniCamera3.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera3.Attiva))
                {
                    lblCamDescr3.Visible = false;
                    lblPercTurnoPrecedenteCam3.Visible = false;
                    lblPercTurnoAttualeCam3.Visible = false;
                    lblPercUltimaOraCam3.Visible = false;
                }

                if (!(this.impostazioni.ImpostazioniCamera4.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera4.Attiva))
                {
                    lblCamDescr4.Visible = false;
                    lblPercTurnoPrecedenteCam4.Visible = false;
                    lblPercTurnoAttualeCam4.Visible = false;
                    lblPercUltimaOraCam4.Visible = false;
                }

                if (!(this.impostazioni.ImpostazioniCamera5.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera5.Attiva))
                {
                    lblCamDescr5.Visible = false;
                    lblPercTurnoPrecedenteCam5.Visible = false;
                    lblPercTurnoAttualeCam5.Visible = false;
                    lblPercUltimaOraCam5.Visible = false;
                }

                if (!(this.impostazioni.ImpostazioniCamera6.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera6.Attiva))
                {
                    lblCamDescr6.Visible = false;
                    lblPercTurnoPrecedenteCam6.Visible = false;
                    lblPercTurnoAttualeCam6.Visible = false;
                    lblPercUltimaOraCam6.Visible = false;
                }

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

            lblTot.Text = linguaManager.GetTranslation("LBL_TOT");
            lblCamDescr1.Text = linguaManager.GetTranslation("LBL_CAM_1");
            lblCamDescr2.Text = linguaManager.GetTranslation("LBL_CAM_2");
            lblCamDescr3.Text = linguaManager.GetTranslation("LBL_CAM_3");
            lblCamDescr4.Text = linguaManager.GetTranslation("LBL_CAM_4");
            lblCamDescr5.Text = linguaManager.GetTranslation("LBL_CAM_5");
            lblCamDescr6.Text = linguaManager.GetTranslation("LBL_CAM_6");
        }

        public void RefreshGrafico()
        {
            try
            {
                //TOT
                DataTable dtTurnoPrecedente = DBL.StatisticheManager.GetDatiContatoriTurnoPrecedente(this.idStazione);
                DataTable dtTurnoAttuale = DBL.StatisticheManager.GetDatiContatoriTurnoAttuale(this.idStazione);
                DataTable dtUltimaOra = DBL.StatisticheManager.GetDatiContatoriUltimaOra(this.idStazione);

                this.perScartoTurnoPrecedente = GetPercScarto(dtTurnoPrecedente, "ALG_KO");
                this.perScartoTurnoAttuale = GetPercScarto(dtTurnoAttuale, "ALG_KO");
                this.perScartoUltimaOra = GetPercScarto(dtUltimaOra, "ALG_KO");

                DisplayPerc(lblPercTurnoPrecedente, perScartoTurnoPrecedente);
                DisplayPerc(lblPercTurnoAttuale, perScartoTurnoAttuale);
                DisplayPerc(lblPercUltimaOra, perScartoUltimaOra);

                double perScartoTurnoPrecedenteCam = 0;
                double perScartoTurnoAttualeCam = 0;
                double perScartoUltimaOraCam = 0;

                //CAM 1
                if (this.impostazioni.ImpostazioniCamera1.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera1.Attiva)
                {
                    perScartoTurnoPrecedenteCam = GetPercScarto(dtTurnoPrecedente, "CNT_KO_CAM1");
                    perScartoTurnoAttualeCam = GetPercScarto(dtTurnoAttuale, "CNT_KO_CAM1");
                    perScartoUltimaOraCam = GetPercScarto(dtUltimaOra, "CNT_KO_CAM1");

                    DisplayPerc(lblPercTurnoPrecedenteCam1, perScartoTurnoPrecedenteCam);
                    DisplayPerc(lblPercTurnoAttualeCam1, perScartoTurnoAttualeCam);
                    DisplayPerc(lblPercUltimaOraCam1, perScartoUltimaOraCam);
                }


                //CAM 2
                if (this.impostazioni.ImpostazioniCamera2.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera2.Attiva)
                {
                    perScartoTurnoPrecedenteCam = GetPercScarto(dtTurnoPrecedente, "CNT_KO_CAM2");
                    perScartoTurnoAttualeCam = GetPercScarto(dtTurnoAttuale, "CNT_KO_CAM2");
                    perScartoUltimaOraCam = GetPercScarto(dtUltimaOra, "CNT_KO_CAM2");

                    DisplayPerc(lblPercTurnoPrecedenteCam2, perScartoTurnoPrecedenteCam);
                    DisplayPerc(lblPercTurnoAttualeCam2, perScartoTurnoAttualeCam);
                    DisplayPerc(lblPercUltimaOraCam2, perScartoUltimaOraCam);
                }

                //CAM 3
                if (this.impostazioni.ImpostazioniCamera3.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera3.Attiva)
                {
                    perScartoTurnoPrecedenteCam = GetPercScarto(dtTurnoPrecedente, "CNT_KO_CAM3");
                    perScartoTurnoAttualeCam = GetPercScarto(dtTurnoAttuale, "CNT_KO_CAM3");
                    perScartoUltimaOraCam = GetPercScarto(dtUltimaOra, "CNT_KO_CAM3");

                    DisplayPerc(lblPercTurnoPrecedenteCam3, perScartoTurnoPrecedenteCam);
                    DisplayPerc(lblPercTurnoAttualeCam3, perScartoTurnoAttualeCam);
                    DisplayPerc(lblPercUltimaOraCam3, perScartoUltimaOraCam);
                }

                //CAM 4
                if (this.impostazioni.ImpostazioniCamera4.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera4.Attiva)
                {
                    perScartoTurnoPrecedenteCam = GetPercScarto(dtTurnoPrecedente, "CNT_KO_CAM4");
                    perScartoTurnoAttualeCam = GetPercScarto(dtTurnoAttuale, "CNT_KO_CAM4");
                    perScartoUltimaOraCam = GetPercScarto(dtUltimaOra, "CNT_KO_CAM4");

                    DisplayPerc(lblPercTurnoPrecedenteCam4, perScartoTurnoPrecedenteCam);
                    DisplayPerc(lblPercTurnoAttualeCam4, perScartoTurnoAttualeCam);
                    DisplayPerc(lblPercUltimaOraCam4, perScartoUltimaOraCam);
                }

                //CAM 5
                if (this.impostazioni.ImpostazioniCamera5.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera5.Attiva)
                {
                    perScartoTurnoPrecedenteCam = GetPercScarto(dtTurnoPrecedente, "CNT_KO_CAM5");
                    perScartoTurnoAttualeCam = GetPercScarto(dtTurnoAttuale, "CNT_KO_CAM5");
                    perScartoUltimaOraCam = GetPercScarto(dtUltimaOra, "CNT_KO_CAM5");

                    DisplayPerc(lblPercTurnoPrecedenteCam5, perScartoTurnoPrecedenteCam);
                    DisplayPerc(lblPercTurnoAttualeCam5, perScartoTurnoAttualeCam);
                    DisplayPerc(lblPercUltimaOraCam5, perScartoUltimaOraCam);
                }

                //CAM 6
                if (this.impostazioni.ImpostazioniCamera6.IdStazione == this.idStazione && this.impostazioni.ImpostazioniCamera6.Attiva)
                {
                    perScartoTurnoPrecedenteCam = GetPercScarto(dtTurnoPrecedente, "CNT_KO_CAM6");
                    perScartoTurnoAttualeCam = GetPercScarto(dtTurnoAttuale, "CNT_KO_CAM6");
                    perScartoUltimaOraCam = GetPercScarto(dtUltimaOra, "CNT_KO_CAM6");

                    DisplayPerc(lblPercTurnoPrecedenteCam6, perScartoTurnoPrecedenteCam);
                    DisplayPerc(lblPercTurnoAttualeCam6, perScartoTurnoAttualeCam);
                    DisplayPerc(lblPercUltimaOraCam6, perScartoUltimaOraCam);
                }
            }
            catch (Exception ex)
            {
                //TODO MessageBox.Show(ex.ToString());
            }
        }

        private void DisplayPerc(Label label, double perc)
        {
            label.Text = string.Format("{0:0.00}%", perc);

            if (perc > impostazioni.SogliaPercScatoRosso)
                label.BackColor = System.Drawing.Color.Red;
            else if (perc > impostazioni.SogliaPercScatoGiallo)
                label.BackColor = System.Drawing.Color.Yellow;
            else
                label.BackColor = System.Drawing.Color.Green;
        }

        private double GetPercScarto(DataTable dt, string colonna)
        {
            double ret = 0;
            try
            {
                double tot = -1;
                double ko = -1;

                foreach (DataRow item in dt.Rows)
                {
                    string chiave = (string)item["Chiave"];

                    if (chiave == "TOT")
                    {
                        tot = (int)item["Valore"];
                    }
                    else if (chiave == colonna)
                    {
                        ko = (int)item["Valore"];
                    }
                }

                if (ko > 0 && tot > 0)
                {
                    ret = (ko / tot) * 100.0;
                }
            }
            catch (Exception) { }
            return ret;
        }

        public void GetPercScarto(out double perScartoTurnoPrecedente, out double perScartoTurnoAttuale, out double perScartoUltimaOra)
        {
            perScartoTurnoPrecedente = this.perScartoTurnoPrecedente;
            perScartoTurnoAttuale = this.perScartoTurnoAttuale;
            perScartoUltimaOra = this.perScartoUltimaOra;
        }

    }
}
