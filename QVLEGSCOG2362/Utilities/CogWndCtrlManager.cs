using Cognex.VisionPro;
using QVLEGSCOG2362.DataType;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Utilities
{
    public class CogWndCtrlManager
    {

        public CogRecordDisplay cogRecordDisplay { get { return ucCogWndCtrlManager.GetCogRecordDisplay(); } }

        private Panel panel = null;

        private Impostazioni config = null;

        private UCCogWndCtrlManager ucCogWndCtrlManager = null;

        public CogWndCtrlManager(Panel panel, Impostazioni config) : this(panel, true, true, config) { }

        public CogWndCtrlManager(Panel panel, bool enableMiddleMoveScroll, bool showMenu, Impostazioni config) : this(panel, true, true, true, config) { }

        public CogWndCtrlManager(Panel panel, bool enableMiddleMoveScroll, bool showMenu, bool showStringMessage, Impostazioni config)
        {
            this.panel = panel;

            ucCogWndCtrlManager = new UCCogWndCtrlManager();
            ucCogWndCtrlManager.Init(enableMiddleMoveScroll, showMenu, showStringMessage, config);
            panel.Controls.Add(this.ucCogWndCtrlManager);

            ucCogWndCtrlManager.Dock = DockStyle.Fill;

            ucCogWndCtrlManager.Dock = DockStyle.None;
            ucCogWndCtrlManager.Size = new Size(panel.Width, panel.Height);
            ucCogWndCtrlManager.Location = new Point(0, 0);
            ucCogWndCtrlManager.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        public void GetSetupOutputCamera(out ObjectToDisplay iconicVarList, out DataType.ElaborateResult result)
        {
            ucCogWndCtrlManager.GetSetupOutputCamera(out iconicVarList, out result);
        }


        public void DisplayModelGraphics(ICogImage image)
        {
            ucCogWndCtrlManager.DisplayModelGraphics(image);
        }

        public void DisplaySetupOutputCamera(ObjectToDisplay iconicVarList, DataType.ElaborateResult result)
        {
            ucCogWndCtrlManager.DisplaySetupOutputCamera(iconicVarList, result);
        }


        public ICogImage GetImage()
        {
            return ucCogWndCtrlManager.GetImage();
        }

    }
}