using Cognex.VisionPro;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCLogSingolo : UserControl
    {

        // Event fires when the MouseClick event fires for the UC or any of its child controls.
        public event EventHandler<EventArgs> WasClicked;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (CanSelect)
                {
                    this.BorderStyle = IsSelected ? BorderStyle.Fixed3D : BorderStyle.None;
                    groupBox1.BackColor = IsSelected ? Color.Red : SystemColors.Control;
                }
            }
        }

        public bool CanSelect { get; set; } = true;

        private object repaintLock = null;
        private Utilities.CogWndCtrlManager hWndCtrlManager = null;

        public UCLogSingolo()
        {
            InitializeComponent();

            // Register the MouseClick event with the UC's surface.
            this.MouseClick += Control_MouseClick;
            // Register MouseClick with all child controls.
            //foreach (Control control in Controls)
            //{
            //    control.MouseClick += Control_MouseClick;
            //}

            groupBox1.MouseClick += Control_MouseClick;
            tableLayoutPanel1.MouseClick += Control_MouseClick;
            label1.MouseClick += Control_MouseClick;
            panelImage.MouseClick += Control_MouseClick;
        }

        public void Init(DataType.Impostazioni impostazioni, object repaintLock)
        {
            this.repaintLock = repaintLock;
            this.hWndCtrlManager = new Utilities.CogWndCtrlManager(panelImage, false, false, false);
            //this.hWndCtrlManager.cogRecordDisplay.HMouseDown += HWindowControl_HMouseDown;
        }

        //private void HWindowControl_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e)
        //{
        //    Control_MouseClick(sender, null);
        //}

        public void SetData(Utilities.ObjectToDisplay iconicVarList, DataType.ElaborateResult result, DateTime ts)
        {
            groupBox1.Text = ts.ToString();

            this.hWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, result);

            VisualizzaTesti(label1, result);
        }

        private void VisualizzaTesti(Label lbl, DataType.ElaborateResult res)
        {
            try
            {
                lbl.Text = string.Empty;

                if (res != null)
                    for (int i = 0; i < res.TestiRagioneScarto.Count; i++)
                    {
                        lbl.Text += res.TestiRagioneScarto[i] + "\n\r";
                    }
            }
            catch (Exception) { }
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            var wasClicked = WasClicked;
            if (wasClicked != null)
            {
                WasClicked(this, EventArgs.Empty);
            }

            // Select this UC on click.
            IsSelected = true;

        }

        public ICogImage GetImage()
        {
            return hWndCtrlManager.GetImage();
        }

    }
}