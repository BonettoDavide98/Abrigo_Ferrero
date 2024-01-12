using System;
using System.Threading.Tasks;

namespace QVLEGSCOG2362.Class
{
    public class LoginLogoutManager
    {

        private static DataType.Utente _currentUserLogged;
        private static string _lastMotivoLogout;

        public static event EventHandler<DataType.Utente> OnLogin;
        public static event EventHandler<LogoutParams> OnLogout;

        private static bool bypassLogin = false;

        public static void Init(bool bypassLogin)
        {
            LoginLogoutManager.bypassLogin = bypassLogin;
        }

        public static DataType.Utente CurrentUserLogged
        {
            get { return _currentUserLogged; }
            set
            {
                DataType.Utente _currentUserLoggedPrev = _currentUserLogged;
                _currentUserLogged = value;

                if (value == null)
                {
                    if (OnLogout != null)
                        OnLogout(new LoginLogoutManager(), new LogoutParams(_currentUserLoggedPrev, _lastMotivoLogout)); // Prima di settarlo, lo passo nell'evento per far sapere chi si sta sloggando
                }

                if (value != null)
                {
                    if (OnLogin != null)
                        OnLogin(new LoginLogoutManager(), _currentUserLogged); // Dopo averlo settato, lo passo all'evento per far sapere chi si è loggato
                }
            }
        }

        public static bool UserLogged(out DataType.Livello.LivelloUtente livelloUtente)
        {
            bool result = UserLogged();
            livelloUtente = GetUserLoggedStato();

            return result;
        }

        public static bool UserLogged()
        {
            return CurrentUserLogged != null;
        }

        public static DataType.Livello.LivelloUtente GetUserLoggedStato()
        {
            if (bypassLogin)
                return DataType.Livello.LivelloUtente.Amministratore;
            else
                return CurrentUserLogged == null ? DataType.Livello.LivelloUtente.NotLogged : CurrentUserLogged.LivelloUtente;
        }

        public static DataType.Utente GetUserLogged()
        {
            return CurrentUserLogged;
        }

        public static void Logout(string motivoLogout)
        {
            if (CurrentUserLogged != null)
            {
                if (CurrentUserLogged.LivelloUtente != DataType.Livello.LivelloUtente.Amministratore)//se mi loggo come ES non faccio il countdown
                {
                    _lastMotivoLogout = motivoLogout;
                    CurrentUserLogged = null;
                }
            }
        }

        public static void Login(DataType.Utente user, int minLogout)
        {
            if (user != null)
            {
                _lastMotivoLogout = String.Empty;
                CurrentUserLogged = user;

                if (user.LivelloUtente != DataType.Livello.LivelloUtente.Amministratore)//se mi loggo come ES non faccio il countdown
                    StartCountdown(minLogout);
            }
        }

        // Attenzione: NON fare logout e subito dopo login in uno spazio di tempo sotto al secondo, in quanto il task non si accorgerebbe del cambio user e non si fermerebbe (ne partirebbero 2 in parallelo)
        private static void StartCountdown(int minLogout)
        {
            Task t = Task.Run(() =>
            {
                int minutiLogout = minLogout;
                TimeSpan timeStartTask = DateTime.Now.TimeOfDay;

                while (true)
                {
                    if (!UserLogged())
                        break;

                    try
                    {
                        if (DateTime.Now.TimeOfDay.Subtract(timeStartTask).TotalMinutes >= minutiLogout)
                        {
                            Logout("Tempo scaduto.");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                        Logout("Errore task countdown tempo: " + ex.ToString());
                    }
                    finally
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            });
        }

        public class LogoutParams
        {
            public DataType.Utente UtenteDoingLogout { get; set; }
            public string MotivoLogout { get; set; }

            public LogoutParams() { }

            public LogoutParams(DataType.Utente utenteDoingLogout, string motivoLogout)
            {
                this.UtenteDoingLogout = utenteDoingLogout;
                this.MotivoLogout = motivoLogout;
            }
        }

    }
}
