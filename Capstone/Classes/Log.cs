using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public static class Log
    {
        public static void WriteLog(string logEntry)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} {logEntry}");
                }
            }
            catch (Exception)
            {

            }

        }

        public static void LogAnError(string reason)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("error.txt", true))
                {
                    sw.WriteLine($"{DateTime.UtcNow} {reason} local time {DateTime.Now}");
                }
            }
            catch (Exception)
            {
            }
        }

    }
}
