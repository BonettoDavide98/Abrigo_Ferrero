using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace QVLEGSCOG2362.Class
{
    public static class ExceptionManager
    {

        private static string FILE_NAME = @"./HandledExceptionLog.txt";

        private static object ExceptionQueueLock = new object();
        private static Queue<Exception> ExceptionQueue = new Queue<Exception>();

        private static Assembly _parentAssembly = null;

        //static ExceptionManager()
        //{
        //    FILE_NAME = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "HandledExceptionLog.txt");
        //}

        public static void Init()
        {
            FILE_NAME = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "HandledExceptionLog.txt");

            // pulisco il file di log delle eccezioni gestite
            using (System.IO.File.Create(FILE_NAME)) { }

            if (Assembly.GetEntryAssembly() == null)
                _parentAssembly = Assembly.GetCallingAssembly();
            else
                _parentAssembly = Assembly.GetEntryAssembly();
        }

        public static void AddException(Exception ex)
        {
            try
            {
                lock (ExceptionQueueLock)
                {
                    ExceptionQueue.Enqueue(ex);

                    Console.WriteLine(ex.ToString());

                    StringBuilder builder = new StringBuilder();

                    builder.Append(Environment.NewLine);

                    builder.Append("Date and Time: ");
                    builder.Append(DateTime.Now);

                    builder.Append(Environment.NewLine);

                    builder.Append(ex.ToString());

                    string text = builder.ToString();

                    System.IO.File.AppendAllText(FILE_NAME, text);
                }
            }
            catch (Exception) { }
        }

        public static Exception GetException()
        {
            Exception ex = null;
            lock (ExceptionQueueLock)
            {
                if (ExceptionQueue.Count > 0)
                {
                    ex = ExceptionQueue.Dequeue();
                }
            }
            return ex;
        }

    }
}