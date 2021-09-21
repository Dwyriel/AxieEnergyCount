using System;
using System.IO;
using System.Windows.Forms;

namespace AxieEnergyCount
{
    static class LogAndErrors
    {
        public static void ShowErrorTextWithExceptionMessage(string text, Exception exception, bool saveToFile = false)
        {
            if (saveToFile)
                SaveErrorLogToFile(exception.Message);
            MessageBox.Show(text + Environment.NewLine + Environment.NewLine + "Error Message:" + Environment.NewLine + exception.Message, "Error");
        }

        public static void ShowErrorText(string text, bool saveToFile = false)
        {
            if (saveToFile)
                SaveErrorLogToFile(text);
            MessageBox.Show(text, "Error");
        }

        public static void SaveErrorLogToFile(string Message)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\log.txt", true);
                streamWriter.WriteLine("[" + DateTime.Now + "] " + Message);
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch { }
        }
    }
}
