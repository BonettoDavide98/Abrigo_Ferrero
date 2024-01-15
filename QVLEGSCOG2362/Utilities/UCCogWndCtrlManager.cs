using Cognex.VisionPro;
using QVLEGSCOG2362.DataType;
using QVLEGSCOG2362.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCCogWndCtrlManager : UserControl
    {

        private Impostazioni config = null;

        private int prevW, prevH = 0;

        private bool enableMiddleMoveScroll;

        private bool showAnnotations = true;

        //private bool resizeDone = false;

        public UCCogWndCtrlManager()
        {
            InitializeComponent();
        }

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            btnOpenMenu.Visible = false;
            panelMenu.Visible = true;
        }



        public void Init(bool enableMiddleMoveScroll, bool showMenu, bool showStringMessage, Impostazioni config)
        {
            this.config = config;

            this.enableMiddleMoveScroll = enableMiddleMoveScroll;

            btnOpenMenu.BringToFront();
            panelMenu.BringToFront();

            btnOpenMenu.Visible = showMenu;

            //CheckForResize(null);
            if (showMenu)
                SetMoveVisible(false);
        }

        private ObjectToDisplay iconicVarListMemo = null;
        private DataType.ElaborateResult resultMemo = null;


        //private void CheckForResize(ObjectToDisplay otd)
        //{
        //    if (otd != null)
        //    {
        //        ICogImage image = otd.GetImage();
        //        if (image != null)
        //        {
        //            int w = 1280, h = 1024;

        //            if (image != null)
        //            {
        //                h = image.Height;
        //                w = image.Width;
        //            }

        //            if (!(prevW == w && prevH == h) || this.resize)
        //            {
        //                this.resize = false;
        //                this.cogRecordDisplay1.BeginInvoke(new MethodInvoker(() => { FitImage(w, h); }));
        //            }
        //        }
        //    }
        //}

        public void GetSetupOutputCamera(out ObjectToDisplay objectToDisplay, out DataType.ElaborateResult result)
        {
            objectToDisplay = iconicVarListMemo.Clone();
            result = this.resultMemo;
        }

        public void DisplayModelGraphics(ICogImage image)
        {
            ObjectToDisplay otd = new ObjectToDisplay();

            otd.SetImage(image);

            DisplaySetupOutputCamera(otd, null);
        }

        public void DisplaySetupOutputCamera(ObjectToDisplay otd, DataType.ElaborateResult result)
        {
            this.iconicVarListMemo = otd;
            this.resultMemo = result;

            //CheckForResize(otd);
            if (!showAnnotations)
                otd.ClearStaticGraphics();

            CommonUtility.DisplayRegolazioni(otd, cogRecordDisplay1);

            if (result != null)
                CommonUtility.DisplayResult(result, cogRecordDisplay1);
        }

        //private void hWindowControl_MouseEnter(object sender, EventArgs e)
        //{
        //    this.hWindowControl.Focus();
        //}

        private void FitImage(int w, int h)
        {
            try
            {
                prevW = w;
                prevH = h;

                Rectangle result = new Rectangle();
                Size imageSize = new Size(w, h);
                float ratio = Math.Min((float)this.panel.ClientSize.Width / (float)imageSize.Width, (float)this.panel.ClientSize.Height / (float)imageSize.Height);
                result.Width = (int)(imageSize.Width * ratio);
                result.Height = (int)(imageSize.Height * ratio);
                result.X = (this.panel.ClientSize.Width - result.Width) / 2;
                result.Y = (this.panel.ClientSize.Height - result.Height) / 2;

                //Debug.WriteLine($"result.X = {result.X}, result.Y = {result.Y}");

                this.cogRecordDisplay1.Width = result.Width;
                this.cogRecordDisplay1.Height = result.Height;

                this.cogRecordDisplay1.Location = new Point(result.X, result.Y);
                //this.resizeDone = true;
            }
            catch (Exception) { }
        }

        public ICogImage GetImage()
        {
            ICogImage ret = null;
            if (iconicVarListMemo != null && iconicVarListMemo.GetImage() != null)
            {
                ICogImage image = iconicVarListMemo.GetImage();
                if (image != null)
                    ret = image.CopyBase(CogImageCopyModeConstants.CopyPixels);

                ((IDisposable)image)?.Dispose();
            }
            return ret;
        }

        private void btnZoomPiu_Click(object sender, EventArgs e)
        {
            try
            {
                cogRecordDisplay1.Zoom = cogRecordDisplay1.Zoom * 2;
            }
            catch
            {

            }
        }

        private void btnZoomMeno_Click(object sender, EventArgs e)
        {
            try
            {
                cogRecordDisplay1.Zoom = cogRecordDisplay1.Zoom / 2;
            }
            catch
            {

            }
        }

        private void btnResetZoom_Click(object sender, EventArgs e)
        {
            try
            {
                cogRecordDisplay1.Fit();
            }
            catch
            {

            }
        }

        private void chbMuovi_CheckedChanged(object sender, EventArgs e)
        {
            //if (chbMuovi.Checked)
            //{
            //    this.Muovi();
            //}
            //else
            //{
            //    this.NessunaModalita();
            //}
        }

        private void btnChiudi_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            btnOpenMenu.Visible = true;
        }

        private void chbAnnotazioni_CheckedChanged(object sender, EventArgs e)
        {
            showAnnotations = chbAnnotazioni.Checked;

            if(!chbAnnotazioni.Checked)
                cogRecordDisplay1.StaticGraphics.Clear();
            //this.mView.ShowOnlyImages = !chbAnnotazioni.Checked;
            //this.mView.repaint();

        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
            //panelMenu.Visible = false;
            //btnOpenMenu.Visible = true;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            ICogImage img = null;
            try
            {
                img = GetImage();
                if (img != null)
                {
                    DateTime d = DateTime.Now;

                    string path = System.IO.Path.Combine(this.config.PathDatiBase, "IMG_SAVE", "MANUAL");

                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(path);

                    string fileName = System.IO.Path.Combine(path, string.Format("{0}.tif", d.ToString("yyyyMMdd HH mm ss.fff")));

                    img.ToBitmap().Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                }
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                ((IDisposable)img)?.Dispose();
            }
        }

        private void SetMoveVisible(bool state)
        {
            if (state)
            {
                chbMuovi.Visible = true;
            }
            else
            {
                chbMuovi.Checked = true;
                chbMuovi.Visible = false;
            }
        }

        public CogRecordDisplay GetCogRecordDisplay()
        {
            return cogRecordDisplay1;
        }

    }
}
