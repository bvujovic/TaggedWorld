﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.Utils;
using TaggedWorldLibrary.Model;

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

        /// <summary>Pokretanje/prikazivanje target-a.</summary>
        public static void OpenTarget(Target target)
        {
            var typeTag = target.GetTypeTag();
            if (typeTag == null)
                return;
            // otvaranje/pokretanje veb linkova
            if (typeTag == Tags.TypeLink)
            {
                GoToLink(target.Content);
                return;
            }
            // otvaranje posebnih foldera (projekti u VS, VSC...)
            if (typeTag == Tags.TypeFolder)
            {
                // Visual Studio projekat
                var files = Directory.GetFiles(target.Content, "*.sln");
                if (files.Length == 1)
                {
                    StartProcess(files.First());
                    return;
                }
                // Visual Studio Code projekat
                files = Directory.GetFiles(target.Content, "platformio.ini");
                if (files.Length == 1)
                {
                    StartProcess("code", target.Content);
                    return;
                }
            }
            // podrazumevano pokretanje fajlova i foldera
            if (typeTag == Tags.TypeFile || typeTag == Tags.TypeFolder)
                StartProcess(target.Content);
        }

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

        /// <summary>Da li se needle sadrzi u haystack (case insensitive)</summary>
        public static bool StrContains(string haystack, string needle)
        {
            return haystack.Contains(needle, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>Da li se bilo koji string iz kolekcije needles sadrzi u haystack-u (case insensitive)</summary>
        public static bool StrContains(string haystack, IEnumerable<string> needles)
        {
            foreach (var needle in needles)
                if (StrContains(haystack, needle))
                    return true;
            return false;
        }

        /// <summary>Da li je bilo koji string iz prve kolekcije jednak sa bilo kojim stringom iz druge kolekcije (case insensitive)</summary>
        public static bool StrFind(IEnumerable<string> strings1, IEnumerable<string> strings2)
        {
            foreach (var s1 in strings1)
                foreach (var s2 in strings2)
                    if (string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase))
                        return true;
            return false;
        }

        public static Color NewTargetsToColor(int n)
        {
            if (n <= 0)
                return SystemColors.Control;
            if (n <= 6)
                return Color.FromArgb((n - 1) * 50, 250, 0);
            if (n <= 10)
                return Color.FromArgb(250, 250 - (n - 6) * 50, 0);
            return Color.Red;
        }

        //TODO dodati unit test projekat koji testira neke od metoda iz ove klase (uopste: test WinForm projekta)
    }
}
