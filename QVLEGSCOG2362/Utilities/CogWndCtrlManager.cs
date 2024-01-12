using Cognex.VisionPro;
using System.Drawing;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Utilities
{
    public class CogWndCtrlManager
    {

        public CogRecordDisplay cogRecordDisplay { get { return ucCogWndCtrlManager.GetCogRecordDisplay(); } }

        private Panel panel = null;

        private UCCogWndCtrlManager ucCogWndCtrlManager = null;

        public CogWndCtrlManager(Panel panel) : this(panel, true, true) { }

        public CogWndCtrlManager(Panel panel, bool enableMiddleMoveScroll, bool showMenu) : this(panel, true, true, true) { }

        public CogWndCtrlManager(Panel panel, bool enableMiddleMoveScroll, bool showMenu, bool showStringMessage)
        {
            this.panel = panel;

            ucCogWndCtrlManager = new UCCogWndCtrlManager();
            ucCogWndCtrlManager.Init(enableMiddleMoveScroll, showMenu, showStringMessage);
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