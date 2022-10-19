using System;
using System.Collections.Generic;
using System.Linq;

namespace WinAppTaggedWorld.Classes
{
    public static class Utils
    {
        public const string AppName = "Tagged World";

        /// <summary>Prikazuje modalni MessageBox.</summary>
        public static DialogResult Mbox(string text, string title = AppName)
            => MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>Prikazuje modalni MessageBox sa prikazom greške (Exception-a).</summary>
        public static DialogResult Mbox(Exception ex, string title = AppName)
        {
            var msg = ex.Message;
            if (ex.InnerException != null)
                msg += Environment.NewLine + ex.InnerException.Message;
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>Prikazuje modalni MessageBox sa Yes/No pitanjem.</summary>
        public static DialogResult MboxYesNo(string question, string title = AppName)
        {
            return MessageBox.Show
                (question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>Prikazuje modalni MessageBox sa Yes/No/Cancel pitanjem.</summary>
        public static DialogResult MboxYesNoCancel(string question, string title = AppName)
        {
            return MessageBox.Show
                (question, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public const string DatumFormat = "yyyy-MM-dd";
        public const string DatumVremeFormat = "yyyy-MM-dd HH:mm";





        /// <summary>Pokretanje procesa/fajla/foldera.</summary>
        private static void StartProcess(string fileName, string? argument = null)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.UseShellExecute = true;
                if (argument != null)
                    process.StartInfo.Arguments = argument;
                process.Start();
            }
            catch (Exception ex) { Mbox(ex); }
        }

        /// <summary>Pokretanje prosledjenog linka u browser-u.</summary>
        public static void GoToLink(string url)
        {
            //* "chrome.exe" vs "msedge.exe";
            StartProcess("chrome.exe", url);
        }

        /// <summary>Da li je prosledjeni string - veb link.</summary>
        public static bool IsItLink(string str)
            => str.StartsWith("http") || str.StartsWith("www.");
    }
}
