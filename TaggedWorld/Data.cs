using System;
using System.Collections.Generic;
using System.Linq;

namespace TaggedWorld
{
    public class Data
    {
        public IEnumerable<Target> AllTargets { get; private set; } = default!;

        public Data()
        {
            //B
            //AllTargets = new HashSet<Target>
            //{
            //    new Target("www.sososvetisava.edu.rs"
            //    , "link", "posao", "skola", "umka"),
            //    new Target("https://portal.azure.com/#home"
            //    , "link", "programiranje", "azure", "c#", "vs", "visual-studio", "cloud"),
            //    new Target("https://azure.microsoft.com/en-in/free/free-account-faq/"
            //    , "link", "programiranje", "azure", "c#", "vs", "visual-studio", "cloud", "besplatno", "faq"),
            //    new Target("https://github.com/bvujovic/"
            //    , "link", "programiranje", "arduino", "posao", "faks"),
            //    new Target("https://raf.edu.rs/studije/master-studije/softversko-inzenjerstvo/155-raf/studijski-programi/softversko-inzenjerstvo-master-studije/2793-plan-studija"
            //    , "link", "raf", "faks", "predmeti", "plan-studija"),
            //    new Target("https://www.nbs.rs/sr_RS/finansijsko_trziste/medjubankarsko-devizno-trziste/kursna-lista/zvanicni-srednji-kurs-dinara/index.html"
            //    , "link", "pare", "kurs", "nbs"),
            //    new Target("https://online.mtsbanka.rs/webapp/Identity/Login"
            //    , "link", "pare", "mts", "banka", "racun"),
            //    new Target("https://online.bancaintesa.rs/Retail/Home/Login"
            //    , "link", "pare", "intesa", "banka", "racun"),
            //    new Target("http://www.hidmet.gov.rs/latin/prognoza/stanica.php?mp_id=13274&nor=da"
            //    , "link", "vreme", "prognoza", "rhmz", "5-dana"),
            //    new Target("https://www.b92.net/"
            //    , "link", "vesti", "portal"),
            //    new Target("http://192.168.0.20/"
            //    , "link", "daljinski", "arduino", "esp8266", "projekat", "svetlo"),
            //    new Target("https://www.aliexpress.com/"
            //    , "link", "kupovina", "ali", "aliexpress", "arduino", "elektronika", "kinezi", "majice"),

            //    new Target(@"c:\Users\bvnet\Downloads\Slike\Kajak_2021-05-01\"
            //    , "folder", "slike", "kajak", "panta", "dunav"),
            //    new Target(@"c:\Users\bvnet\OneDrive\x\"
            //    , "folder", "posao", "skola", "faks", "onedrive", "sososvetisava"),
            //    new Target(@"d:\Glavni\TempDownloads\_muzika\"
            //    , "folder", "muzika", "mp3", "zabava"),
            //    new Target(@"c:\Users\bvnet\Documents\PlatformIO\Projects\ESP_IR_TV\"
            //    , "folder", "visual-studio-code", "vsc", "programiranje", "arduino", "projekat", "esp-ir-tv", "daljinski", "svetlo"),
            //    new Target(@"c:\Users\bvnet\Source\repos\JISP\"
            //    , "folder", "visual-studio", "vs", "programiranje", "c#", "projekat", "jisp"),
            //    new Target(@"c:\Users\bvnet\Source\repos\_RAF\_F\TaggedWorld\"
            //    , "folder", "visual-studio", "vs", "programiranje", "c#", "projekat", "raf", "faks", "tagged-world", "tags"),
            //    new Target(@"c:\Users\bvnet\OneDrive\x\RAF\"
            //    , "folder", "raf"),
            //    new Target(@"c:\Users\bvnet\Source\repos\_RAF\"
            //    , "folder", "raf", "projekat", "vs", "visual-studio"),

            //    new Target(@"c:\Users\bvnet\OneDrive\Documents\Planiranje\Plan za 2022.docx"
            //    , "fajl", "dokument", "plan", "2022"),
            //    new Target(@"c:\Users\bvnet\OneDrive\Documents\Planiranje\Plan za 2021.docx"
            //    , "fajl", "dokument", "plan", "2021"),
            //    new Target(@"c:\Users\bvnet\Documents\Pare.xlsm"
            //    , "fajl", "tabele", "pare", "racun", "banka", "garancije", "staz"),
            //    new Target(@"C:\Program Files\Microsoft Office\root\Office16\ONENOTE.EXE"
            //    , "fajl", "one-note", "todo", "office", "spisak"),
            //};
        }

        public void AddTarget(Target target)
        {
            if (AllTargets is HashSet<Target> hs)
                hs.Add(target);
        }

        public void RemoveTarget(Target target)
        {
            if (AllTargets is HashSet<Target> hs && hs.Contains(target))
                hs.Remove(target);
        }

        /// <summary>Ucitavanje targeta iz tekst fajla cija je putanja prosledjena.</summary>
        public void LoadTestTargets(string path)
        {
            AllTargets = new HashSet<Target>();
            using var sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                var address = sr.ReadLine();
                // prazni redovi se samo preskacu - mogu biti zgodni za odvajanje sekcija u text fajlu sa mnogo targeta
                if (string.IsNullOrEmpty(address))
                    continue;
                var strTags = sr.ReadLine();
                if (strTags == null)
                    break;
                var tags = strTags.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var t = new Target(address, tags);
                AddTarget(t);
            }
            sr.Close();
            ExtractAllTags();
        }

        /// <summary>Cuvanje targeta u tekst fajl cija je putanja prosledjena.</summary>
        public void SaveTestTargets(string path)
        {
            using var sw = new StreamWriter(path);
            foreach (var target in AllTargets)
            {
                sw.WriteLine(target.Address);
                sw.WriteLine(string.Join(", ", target.Tags));
            }
        }

        /// <summary>Pronalazenje svih tagova koji se nalaze u kolekciji AllTargets.</summary>
        private void ExtractAllTags()
        {
            var tags = new HashSet<Tag>();
            foreach (var target in AllTargets)
                foreach (var tag in target.Tags)
                    tags.Add(tag);
            AllTags = tags;
        }

        public IEnumerable<Tag> AllTags { get; private set; } = default!;
    }
}
