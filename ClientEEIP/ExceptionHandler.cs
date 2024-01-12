namespace ClientEEIP
{
    class ExceptionHandler
    {
        public static void HandleException(System.Exception ex)
        {
            //System.Windows.Forms.MessageBox.Show(ex.ToString());
            System.Console.WriteLine(ex.ToString());
            return;
        }
    }
}
