using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    static class Program
    {

        public static FormSplash splashForm;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if _Simulazione
            MessageBox.Show("SIMULAZIONE ATTIVA", "ATTENZIONE");
#endif

            Class.ExceptionManager.Init();

            //DB
            DBL.ImpostazioniManager.ConnectionString = Properties.Settings.Default.ConnectionString;
            DBL.FormatoManager.ConnectionString = Properties.Settings.Default.ConnectionString;
            DBL.StatisticheManager.ConnectionString = Properties.Settings.Default.ConnectionString;
            DBL.GestioneTurniManager.ConnectionString = Properties.Settings.Default.ConnectionString;
            DBL.UtenteProvider.ConnectionString = Properties.Settings.Default.ConnectionString;

            //CONTROLLO DONGLE HALCON
            try
            {
                //TODO : 
                //HalconDotNet.HSystem.SetSystem("width", 2000);
                //HalconDotNet.HSystem.SetSystem("height", 2000);
                //HalconDotNet.HSystem.SetSystem("thread_num", 4);
                //HalconDotNet.HSystem.SetSystem("clip_region", "false");
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
                MessageBox.Show("DONGLE NOT PRESENT.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            //GCSettings.LatencyMode = GCLatencyMode.LowLatency;

            //CONTROLLO CONNESSIONE SQL SERVER
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                Class.ExceptionManager.AddException(ex);
                MessageBox.Show("ERROR CHECK DB CONNECTION.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (args.Length == 0)
            {
                //CONTROllO E CREAZIONE PATH BASE
                DataType.Impostazioni impostazioni = null;
                try
                {
                    impostazioni = DBL.ImpostazioniManager.ReadImpostazioni();

                    if (!string.IsNullOrWhiteSpace(impostazioni.PathDatiBase))
                    {
                        if (!System.IO.Directory.Exists(impostazioni.PathDatiBase))
                        {
                            MessageBox.Show($"BASE DATA PATH DOES NOT EXIST.\n\rPath : {impostazioni?.PathDatiBase}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("BASE DATA PATH NOT SPECIFIED.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    Class.ExceptionManager.AddException(ex);
                    MessageBox.Show($"ERROR CHECK BASE DATA PATH.\n\rPath : {impostazioni?.PathDatiBase}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ////show splash
                Thread splashThread = new Thread(new ThreadStart(
                    delegate
                    {
                        splashForm = new FormSplash(impostazioni);
                        Application.Run(splashForm);
                    }
                    ));

                splashThread.SetApartmentState(ApartmentState.STA);
                splashThread.Start();

                //verifico che non ci sia già un applicazione avviata se c'è la killo
                int nProcessID = Process.GetCurrentProcess().Id;

                string exeName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);
                foreach (var process in Process.GetProcessesByName(exeName))
                    if (process.Id != nProcessID)
                        process.Kill();

                //MainForm mainForm = new MainForm();
                //mainForm.Load += mainForm_Load;

                FormPrincipale mainForm = new FormPrincipale();
                mainForm.Load += mainForm_Load;

                Application.Run(mainForm);
            }
            else if (args[0].ToUpper().Equals("CONFIG"))
            {
                Application.Run(new FormImpostazioni());
            }
        }

        static void mainForm_Load(object sender, EventArgs e)
        {
            //close splash
            if (splashForm == null)
            {
                return;
            }

            splashForm.Invoke(new Action(splashForm.Close));
            splashForm.Dispose();
            splashForm = null;
        }

    }
}