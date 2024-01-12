using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaViewSoglieCam : UserControl
    {

        private object objLock = new object();

        private Class.AppManager appManager = null;
        private DataType.Impostazioni impostazioni = null;
        private Dictionary<string, UCEditSoglia> ucEdit = new Dictionary<string, UCEditSoglia>();

        private int idCamera = 0;
        private string idFormato = string.Empty;

        private bool updateScreen = false;

        public UCPaginaViewSoglieCam()
        {
            InitializeComponent();

            // cambio la dimensione per far vedere solo una riga
            flpMenu.Size = new System.Drawing.Size(flpMenu.Size.Width, 65);

            try
            {
                Dictionary<string, TableLayoutPanel> testTlp = new Dictionary<string, TableLayoutPanel>();
                testTlp.Add("TEST_INTEGRITA_AREA", tlpPageIntegrita);
                testTlp.Add("TEST_INTEGRITA_DELTA", tlpPageIntegrita);
                testTlp.Add("TEST_DIMENSIONE_DIAMETRO", tlpPageDimensione);
                testTlp.Add("TEST_DIMENSIONE_CIRCOLARITA", tlpPageDimensione);
                testTlp.Add("TEST_DIMENSIONE_W", tlpPageDimensione);
                testTlp.Add("TEST_DIMENSIONE_H", tlpPageDimensione);
                testTlp.Add("TEST_DISEGNI_PRESENZA_AREA", tlpPageDisegni);
                testTlp.Add("TEST_DISEGNI_MACCHIE_GROSSE_AREA_MAX", tlpPageDisegni);
                testTlp.Add("TEST_COLORE_DIST", tlpPageColore);
                testTlp.Add("TEST_COLORE_DIST_2", tlpPageColore);
                testTlp.Add("TEST_COLORE_2_AREA", tlpPageColore2);
                testTlp.Add("TEST_SBORDAMENTO_AREA_MAX", tlpPageSbordamento);
                testTlp.Add("TEST_DIMENSIONE_LATO_W", tlpPageDimensioneLato);
                testTlp.Add("TEST_DIMENSIONE_LATO_H", tlpPageDimensioneLato);
                testTlp.Add("TEST_CREPE_LEN", tlpPageCrepe);
                testTlp.Add("TEST_RAKE_DELTA_V", tlpPageRakeV);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_V_0", tlpPageRakeV);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_V_1", tlpPageRakeV);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_V_2", tlpPageRakeV);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_V_3", tlpPageRakeV);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_V_4", tlpPageRakeV);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_H_0", tlpPageRakeH);
                testTlp.Add("TEST_RAKE_DELTA_H", tlpPageRakeH);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_H_1", tlpPageRakeH);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_H_2", tlpPageRakeH);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_H_3", tlpPageRakeH);
                testTlp.Add("TEST_RAKE_DIMENSIONE_LATO_H_4", tlpPageRakeH);
                testTlp.Add("TEST_TOP_3D_AREA_CENTRO", tlpPageTop3D);
                testTlp.Add("TEST_TOP_3D_AREA_DISALLINEAMENTO", tlpPageTop3D);
                testTlp.Add("TEST_BUCHI_LATO_3D_AREA_MAX", tlpPageBuchiLato3D);
                testTlp.Add("TEST_DIMENSIONE_ALTEZZA", tlpPageTopLatoAltezza);

                foreach (var item in testTlp)
                {
                    TableLayoutPanel tlp = item.Value;
                    tlp.RowCount += 1;
                    tlp.RowStyles.Insert(tlp.RowCount - 2, new RowStyle(SizeType.AutoSize, 0));

                    UCEditSoglia uc = new UCEditSoglia();
                    uc.Size = new System.Drawing.Size(1520, 150);
                    uc.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                    tlp.Controls.Add(uc, 0, tlp.RowCount - 2);

                    tlp.Size = new System.Drawing.Size(1550, tlp.RowCount * 150 + 50);

                    uc.Visible = false;

                    ucEdit.Add(item.Key, uc);
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, int idCamera, string idFormato, DBL.LinguaManager linguaManager)
        {
            try
            {
                this.appManager = appManager;
                this.impostazioni = impostazioni;
                this.idCamera = idCamera;
                this.idFormato = idFormato;

                Algoritmi.AlgoritmoLavoro algoritmo = this.appManager.GetAlgoritmo(idCamera);
                DataType.ParametriAlgoritmo parametri = algoritmo.GetAlgoritmoParam();

                btnPageIntegrita.Visible = false;
                btnPageDimensione.Visible = false;
                btnPageDisegni.Visible = false;
                btnPageCrepe.Visible = false;
                btnPageColore.Visible = false;
                btnPageColore2.Visible = false;
                btnPageSbordamento.Visible = false;
                btnPageDimensioneLato.Visible = false;
                btnPageRakeH.Visible = false;
                btnPageRakeV.Visible = false;
                btnPageTop3D.Visible = false;
                btnPageBuchiLato3D.Visible = false;
                btnPageTopLatoAltezza.Visible = false;

                TabPage nextSelected = null;


                //ucEdit.Clear();

                if (parametri.Template != null)
                {

                    foreach (var item in ucEdit)
                    {
                        item.Value.Init(item.Key, algoritmo, linguaManager);
                        item.Value.Visible = false;
                    }


                    ////// TOP
                    //if (parametri.Template.AlgIntegritaEnable && parametri.IntegritaParam.AbilitaControllo)
                    //{

                    //    btnPageIntegrita.Visible = true;

                    //    if (nextSelected == null) nextSelected = tabPageIntegrita;
                    //}

                    //if (parametri.Template.AlgDimensioniEnable && parametri.DimensioneParam.AbilitaControllo)
                    //{
                    //    btnPageDimensione.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageDimensione;
                    //}

                    //if (parametri.Template.AlgDisegniEnable && parametri.DisegniParam.AbilitaControllo)
                    //{
                    //    btnPageDisegni.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageDisegni;
                    //}

                    //if (parametri.Template.AlgCrepeEnable && parametri.CrepeParam.AbilitaControllo)
                    //{
                    //    btnPageCrepe.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageCrepe;
                    //}

                    //if (parametri.Template.AlgColoreEnable && parametri.ColoreParam.AbilitaControllo)
                    //{
                    //    btnPageColore.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageColore;
                    //}

                    //if (parametri.Template.AlgColore2Enable && parametri.Colore2Param.AbilitaControllo)
                    //{
                    //    btnPageColore2.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageColore2;
                    //}

                    ////// LATO
                    //if (parametri.Template.AlgSbordamentoEnable && parametri.SbordamentoParam.AbilitaControllo)
                    //{
                    //    btnPageSbordamento.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageSbordamento;
                    //}

                    //if (parametri.Template.AlgDimensioniLatoEnable && parametri.DimensioneLatoParam.AbilitaControllo)
                    //{
                    //    btnPageDimensioneLato.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageDimensioneLato;
                    //}

                    //if (parametri.Template.AlgRakeDimensioniLatoEnable && parametri.RakeDimensioneLatoParam.AbilitaControllo)
                    //{
                    //    if (parametri.RakeDimensioneLatoParam.ListMisuraRakeDescrittoreHor?.Count > 0)
                    //    {
                    //        btnPageRakeH.Visible = true;
                    //        if (nextSelected == null) nextSelected = tabPageRakeH;
                    //    }
                    //}

                    //if (parametri.Template.AlgRakeDimensioniLatoEnable && parametri.RakeDimensioneLatoParam.AbilitaControllo)
                    //{
                    //    if (parametri.RakeDimensioneLatoParam.ListMisuraRakeDescrittoreVert?.Count > 0)
                    //    {
                    //        btnPageRakeV.Visible = true;
                    //        if (nextSelected == null) nextSelected = tabPageRakeV;
                    //    }
                    //}

                    ////// 3D
                    //if (parametri.Template.AlgControlloTop3DEnable && parametri.ControlloTop3DParam.AbilitaControllo)
                    //{
                    //    btnPageTop3D.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageTop3D;
                    //}

                    //if (parametri.Template.AlgBuchiLato3DEnable && parametri.BuchiLato3DParam.AbilitaControllo)
                    //{
                    //    btnPageBuchiLato3D.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageBuchiLato3D;
                    //}

                    ////// TOP LATO
                    //if (parametri.Template.AlgAltezzaEnable && parametri.AltezzaParam.AbilitaControllo)
                    //{
                    //    btnPageTopLatoAltezza.Visible = true;
                    //    if (nextSelected == null) nextSelected = tabPageTopLatoAltezza;
                    //}
                }

                if (nextSelected == null)
                {
                    nextSelected = tabPageNN;
                }

                ucTabControl1.SelectedTab = nextSelected;

                //timerUpdateGrafici.Enabled = true;
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            btnPageIntegrita.Text = linguaManager.GetTranslation("BTN_INTEGRITA");
            btnPageDisegni.Text = linguaManager.GetTranslation("BTN_DISEGNI");
            btnPageCrepe.Text = linguaManager.GetTranslation("BTN_CREPE");
            btnPageDimensione.Text = linguaManager.GetTranslation("BTN_DIMENSIONE");
            btnPageColore.Text = linguaManager.GetTranslation("BTN_COLORE");
            btnPageColore2.Text = linguaManager.GetTranslation("BTN_COLORE_2");
            btnPageSbordamento.Text = linguaManager.GetTranslation("BTN_SBORDAMENTO");
            btnPageDimensioneLato.Text = linguaManager.GetTranslation("BTN_DIMENSIONE");
            btnPageRakeH.Text = linguaManager.GetTranslation("BTN_RAKE_H");
            btnPageRakeV.Text = linguaManager.GetTranslation("BTN_RAKE_V");
            label1.Text = linguaManager.GetTranslation("LBL_NN_SOGLIE");
            btnPageTop3D.Text = linguaManager.GetTranslation("BTN_TOP_3D");
            btnPageBuchiLato3D.Text = linguaManager.GetTranslation("BTN_BUCHI_LATO_3D");
            btnPageTopLatoAltezza.Text = linguaManager.GetTranslation("BTN_TOP_LATO_ALTEZZA");

            foreach (var item in this.ucEdit)
            {
                item.Value.Translate(linguaManager);
            }
        }


        public void Save()
        {
            try
            {
                foreach (var item in this.ucEdit)
                {
                    if (item.Value.Visible)
                        item.Value.SaveData();
                }

                Algoritmi.AlgoritmoLavoro algoritmo = this.appManager.GetAlgoritmo(idCamera);

                if (Class.LoginLogoutManager.GetUserLoggedStato() <= DataType.Livello.LivelloUtente.Amministratore)
                {
                    // Utente con livello alto salva su db
                    string basePath = System.IO.Path.Combine(impostazioni.PathDatiBase, "RICETTE", this.idFormato, "GMM", (idCamera + 1).ToString());
                    DBL.FormatoManager.WriteParametriAlgoritmo(this.idFormato, this.idCamera, algoritmo.GetAlgoritmoParam());
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
            }
        }

        public void Reset()
        {
            lock (objLock)
            {
                Class.GraficiSoglieManager graficiSoglieManager = this.appManager.GetGraficiSoglieManager(idCamera);
                graficiSoglieManager?.ClearData();

                foreach (var item in ucEdit)
                {
                    item.Value.DrawData(new Dictionary<int, int>());
                }
            }
        }

        public void StopUpdate()
        {
            updateScreen = false;
            timerUpdateGrafici.Enabled = false;
        }

        public void StartUpdate()
        {
            timerUpdateGrafici.Interval = 100;
            updateScreen = true;
            timerUpdateGrafici.Enabled = true;
        }


        private void timerUpdateGrafici_Tick(object sender, EventArgs e)
        {
            //timerUpdateGrafici.Enabled = false;
            try
            {
                lock (objLock)
                {
                    Class.GraficiSoglieManager graficiSoglieManager = this.appManager.GetGraficiSoglieManager(idCamera);
                    Dictionary<string, Dictionary<int, int>> valori = graficiSoglieManager.GetData();

                    foreach (var item in valori)
                    {
                        if (ucEdit.ContainsKey(item.Key))
                        {
                            UCEditSoglia uc = ucEdit[item.Key];
                            uc.DrawData(item.Value);
                            uc.Visible = true;
                        }
                        else
                        {
                            //MANCA SULLA FORM
                            //AGGIUNGERE
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                timerUpdateGrafici.Interval = 20000;
                //timerUpdateGrafici.Enabled = true;
            }
        }


        private void btnPageIntegrita_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageIntegrita;
        }

        private void btnPageDisegni_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageDisegni;
        }

        private void btnPageCrepe_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageCrepe;
        }

        private void btnPageDimensione_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageDimensione;
        }

        private void btnPageColore_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageColore;
        }

        private void btnPageColore2_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageColore2;
        }

        private void btnPageSbordamento_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageSbordamento;
        }

        private void btnPageDimensioneLato_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageDimensioneLato;
        }

        private void btnPageRakeH_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageRakeH;
        }

        private void btnPageRakeV_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageRakeV;
        }

        private void btnPageTopLatoAltezza_Click(object sender, EventArgs e)
        {
            ucTabControl1.SelectedTab = tabPageTopLatoAltezza;
        }
    }
}