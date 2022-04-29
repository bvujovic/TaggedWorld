using System;
using TaggedWorld;

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

        public static void OpenTarget(Target target)
        {
            var typeTag = target.GetTypeTag();
            if (typeTag == null)
                return;
            if (typeTag.Name == Tag.TypeLink)
                GoToLink(target.Address);
            if (typeTag.Name == Tag.TypeFile || typeTag.Name == Tag.TypeFolder)
                StartProcess(target.Address);
        }

        private static void StartProcess(string fileName)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch (Exception ex) { Mbox(ex); }
        }

        /// <summary>Pokretanje prosledjenog linka u browser-u.</summary>
        public static void GoToLink(string url)
        {
            //* var process = Data.AppData.Browser == "Chrome" ? "chrome.exe" : "msedge.exe";
            //B var process = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            // StartProcess("chrome.exe");
            // try { System.Diagnostics.Process.Start(process, url); }
            StartProcess(url);
        }

        /// <summary>Da li je prosledjeni string - veb link.</summary>
        public static bool IsItLink(string str)
            => str.StartsWith("http");
    }
}
