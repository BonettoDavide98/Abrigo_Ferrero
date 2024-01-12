using System;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCTabControl : TabControl
    {
            
        public bool HideTab { get; set; } = true;

        public UCTabControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Intercept any key combinations that would change the active tab.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool changeTabKeyCombination =
                (e.Control
                    && (e.KeyCode == Keys.Tab
                        || e.KeyCode == Keys.Next
                        || e.KeyCode == Keys.Prior));

            if (!changeTabKeyCombination)
            {
                base.OnKeyDown(e);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode && this.HideTab)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }
    }
}
