using System;
using System.Threading;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Utilities
{
    public static class WaitManager
    {
        private static DBL.LinguaManager linguaManager = null;

        private static FormWait splashForm = null;
        private static bool isOpen = false;

        public static void SetLinguaManager(DBL.LinguaManager linguaManager)
        {
            WaitManager.linguaManager = linguaManager;
        }

        public static void OpenWaitForm(string msg)
        {
            Thread splashThread = new Thread(new ThreadStart(
            delegate
            {
                splashForm = new FormWait(msg, WaitManager.linguaManager);
                Application.Run(splashForm);
            }
            ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            isOpen = true;
            Thread.Sleep(50);
        }

        public static void CloseWaitForm()
        {
            splashForm?.Invoke(new Action(() =>
            {
                splashForm?.Close();
                splashForm = null;
                isOpen = false;
            }));
        }

    }
}
