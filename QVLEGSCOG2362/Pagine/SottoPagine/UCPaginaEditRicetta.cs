using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine
{
    public partial class UCPaginaEditRicetta : UserControl
    {

        private Class.AppManager appManager = null;
        private Action<bool, bool> actionCaricaRicetta = null;
        private Action actionGoHome = null;
        private Utilities.SimpleDirtyTracker simpleDirtyTracker = null;

        public UCPaginaEditRicetta()
        {
            InitializeComponent();

            this.simpleDirtyTracker = new Utilities.SimpleDirtyTracker(null);
        }

        public void Init(Class.AppManager appManager, DataType.Impostazioni impostazioni, Action<bool, bool> actionCaricaRicetta, Action actionGoHome, DBL.LinguaManager linguaManager, object repaintLock)
        {
            try
            {
                this.appManager = appManager;
                this.actionCaricaRicetta = actionCaricaRicetta;
                this.actionGoHome = actionGoHome;

                ucPaginaEditRicettaCam1.Init(appManager, impostazioni, appManager.CamereId[0], true, this.simpleDirtyTracker, linguaManager, repaintLock);

                int numCamere = this.appManager.GetNumCamere();
                if (numCamere > 1)
                    ucPaginaEditRicettaCam2.Init(appManager, impostazioni, appManager.CamereId[1], false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (numCamere > 2)
                    ucPaginaEditRicettaCam3.Init(appManager, impostazioni, appManager.CamereId[2], false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (numCamere > 3)
                    ucPaginaEditRicettaCam4.Init(appManager, impostazioni, appManager.CamereId[3], false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (numCamere > 4)
                    ucPaginaEditRicettaCam5.Init(appManager, impostazioni, appManager.CamereId[4], false, this.simpleDirtyTracker, linguaManager, repaintLock);
                if (numCamere > 5)
                    ucPaginaEditRicettaCam6.Init(appManager, impostazioni, appManager.CamereId[5], false, this.simpleDirtyTracker, linguaManager, repaintLock);

                if (numCamere == 1)
                {
                    flowLayoutPanelBtnCam.Visible = false;
                }

                if (numCamere < 2)
                    btnCam2.Visible = false;

                if (numCamere < 3)
                    btnCam3.Visible = false;

                if (numCamere < 4)
                    btnCam4.Visible = false;

                if (numCamere < 5)
                    btnCam5.Visible = false;

                if (numCamere < 6)
                    btnCam6.Visible = false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Translate(DBL.LinguaManager linguaManager)
        {
            lblTitolo.Text = linguaManager.GetTranslation("LBL_FRM_EDIT_FORMATO");

            btnCam1.Text = linguaManager.GetTranslation("BTN_CAM_1");
            btnCam2.Text = linguaManager.GetTranslation("BTN_CAM_2");
            btnCam3.Text = linguaManager.GetTranslation("BTN_CAM_3");
            btnCam4.Text = linguaManager.GetTranslation("BTN_CAM_4");
            btnCam5.Text = linguaManager.GetTranslation("BTN_CAM_5");
            btnCam6.Text = linguaManager.GetTranslation("BTN_CAM_6");

            btnSave.Text = linguaManager.GetTranslation("BTN_SALVA");
            btnAnnulla.Text = linguaManager.GetTranslation("BTN_ANNULLA");

            ucPaginaEditRicettaCam1.Translate(linguaManager);

            int numCamere = this.appManager.GetNumCamere();
            if (numCamere > 1)
                ucPaginaEditRicettaCam2.Translate(linguaManager);
            if (numCamere > 2)
                ucPaginaEditRicettaCam3.Translate(linguaManager);
            if (numCamere > 3)
                ucPaginaEditRicettaCam4.Translate(linguaManager);
            if (numCamere > 4)
                ucPaginaEditRicettaCam5.Translate(linguaManager);
            if (numCamere > 5)
                ucPaginaEditRicettaCam6.Translate(linguaManager);

        }

        public void CaricaRicetta(string idFormato)
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                ucPaginaEditRicettaCam1.CaricaRicetta(idFormato);
                System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 1 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();

                int numCamere = this.appManager.GetNumCamere();
                if (numCamere > 1)
                {
                    ucPaginaEditRicettaCam2.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 2 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (numCamere > 2)
                {
                    ucPaginaEditRicettaCam3.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 3 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (numCamere > 3)
                {
                    ucPaginaEditRicettaCam4.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 4 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (numCamere > 4)
                {
                    ucPaginaEditRicettaCam5.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 5 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                if (numCamere > 5)
                {
                    ucPaginaEditRicettaCam6.CaricaRicetta(idFormato);
                    System.Diagnostics.Debug.WriteLine(string.Format("T CaricaRicetta 6 = {0} ms", sw.ElapsedMilliseconds)); sw.Restart();
                }
                System.Diagnostics.Debug.WriteLine("-----------------------------------------------------------------------");

                this.simpleDirtyTracker.SetAsClean();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ResetBackColorBtnCam()
        {
            btnCam1.BackColor = System.Drawing.Color.Gainsboro;
            btnCam2.BackColor = System.Drawing.Color.Gainsboro;
            btnCam3.BackColor = System.Drawing.Color.Gainsboro;
            btnCam4.BackColor = System.Drawing.Color.Gainsboro;
            btnCam5.BackColor = System.Drawing.Color.Gainsboro;
            btnCam6.BackColor = System.Drawing.Color.Gainsboro;
        }

        public bool IsDirty()
        {
            return this.simpleDirtyTracker.IsDirty;
        }


        public void Save()
        {
            Utilities.WaitManager.OpenWaitForm("LBL_WAIT_SALVATAGGIO");
            try
            {
                ucPaginaEditRicettaCam1.Salva();

                int numCamere = this.appManager.GetNumCamere();
                if (numCamere > 1)
                    ucPaginaEditRicettaCam2.Salva();
                if (numCamere > 2)
                    ucPaginaEditRicettaCam3.Salva();
                if (numCamere > 3)
                    ucPaginaEditRicettaCam4.Salva();
                if (numCamere > 4)
                    ucPaginaEditRicettaCam5.Salva();
                if (numCamere > 5)
                    ucPaginaEditRicettaCam6.Salva();

                this.simpleDirtyTracker.SetAsClean();

                this.actionCaricaRicetta?.Invoke(true, false);

                actionGoHome?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Utilities.WaitManager.CloseWaitForm();
            }
        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*
            // values
            TabControl tabCtrl = (TabControl)sender;

            //BackColor
            //Color[] color = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Magenta, Color.MediumBlue, Color.Pink };

            //e.Graphics.FillRectangle(new SolidBrush(color[e.Index]), e.Bounds);
            //tabCtrl.TabPages[e.Index].BackColor = color[e.Index];

            Brush fontBrush = Brushes.Black;
            string title = tabCtrl.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            int indent = 3;
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + indent, e.Bounds.Width, e.Bounds.Height - indent);

            // draw title
            Font f = new Font("Microsoft Sans Serif", 12);
            e.Graphics.DrawString(title, f, fontBrush, rect, sf);

            // draw image if available
            if (tabCtrl.TabPages[e.Index].ImageIndex >= 0)
            {
                Image img = tabCtrl.ImageList.Images[tabCtrl.TabPages[e.Index].ImageIndex];
                float _x = (rect.X + rect.Width) - img.Width - indent;
                float _y = ((rect.Height - img.Height) / 2.0f) + rect.Y;
                e.Graphics.DrawImage(img, _x, _y);
            }
            */
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            try
            {
                //ucPaginaEditRicettaCam1.RicaricaRicetta();

                //if (Class.AppManager.NUM_CAMERE > 1)
                //{
                //    ucPaginaEditRicettaCam2.RicaricaRicetta();
                //    ucPaginaEditRicettaCam3.RicaricaRicetta();
                //    ucPaginaEditRicettaCam4.RicaricaRicetta();
                //    ucPaginaEditRicettaCam5.RicaricaRicetta();
                //}

                this.simpleDirtyTracker.SetAsClean();

                actionGoHome?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void btnCam1_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam1.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCamera1;
        }

        private void btnCam2_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam2.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCamera2;
        }

        private void btnCam3_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam3.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCamera3;
        }

        private void btnCam4_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam4.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCamera4;
        }

        private void btnCam5_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam5.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCamera5;
        }

        private void btnCam6_Click(object sender, EventArgs e)
        {
            ResetBackColorBtnCam();
            btnCam6.BackColor = System.Drawing.Color.DarkGray;
            tabControlMain.SelectedTab = tabPageCamera6;
        }

    }
}