using System;
using System.Collections.Generic;
using System.Linq;

namespace TaggedWorld
{
    public class Data
    {
        public List<Target> AllTargets { get; private set; }
        public Data()
        {
            AllTargets = new List<Target>
            {
                new Target("www.sososvetisava.edu.rs"
                , "link", "posao", "skola", "umka"),
                new Target("https://github.com/bvujovic/"
                , "link", "programiranje", "arduino", "posao", "faks"),
                new Target("https://raf.edu.rs/studije/master-studije/softversko-inzenjerstvo/155-raf/studijski-programi/softversko-inzenjerstvo-master-studije/2793-plan-studija"
                , "link", "raf", "faks", "predmeti", "plan-studija"),
                new Target("https://www.nbs.rs/sr_RS/finansijsko_trziste/medjubankarsko-devizno-trziste/kursna-lista/zvanicni-srednji-kurs-dinara/index.html"
                , "link", "pare", "kurs", "nbs"),
                new Target("http://www.hidmet.gov.rs/latin/prognoza/stanica.php?mp_id=13274&nor=da"
                , "link", "vreme", "prognoza", "rhmz", "5-dana"),
                new Target("https://www.b92.net/"
                , "link", "vesti", "portal"),
                new Target("http://192.168.0.20/"
                , "link", "daljinski", "arduino", "esp8266", "projekat", "svetlo"),
                new Target("https://www.aliexpress.com/"
                , "link", "kupovina", "ali", "aliexpress", "arduino", "elektronika", "kinezi", "majice"),

                new Target(@"c:\Users\bvnet\Downloads\Slike\Kajak_2021-05-01\"
                , "folder", "slike", "kajak", "panta", "dunav"),
                new Target(@"c:\Users\bvnet\OneDrive\x\"
                , "folder", "posao", "skola", "faks", "onedrive", "sososvetisava"),
                new Target(@"d:\Glavni\TempDownloads\_muzika\"
                , "folder", "muzika", "mp3", "zabava"),
                new Target(@"c:\Users\bvnet\Source\repos\JISP\"
                , "folder", "visual-studio", "vs", "programiranje", "c#", "projekat", "jisp"),
                new Target(@"c:\Users\bvnet\Source\repos\_RAF\_F\TaggedWorld\"
                , "folder", "visual-studio", "vs", "programiranje", "c#", "projekat", "raf", "faks", "tagged-world", "tags"),

                new Target(@"c:\Users\bvnet\OneDrive\Documents\Planiranje\Plan za 2022.docx"
                , "fajl", "dokument", "plan", "2022"),
                new Target(@"c:\Users\bvnet\OneDrive\Documents\Planiranje\Plan za 2021.docx"
                , "fajl", "dokument", "plan", "2021"),
                new Target(@"c:\Users\bvnet\Documents\Pare.xlsm"
                , "fajl", "tabele", "pare", "racun", "banka", "garancije", "staz"),
            };
        }
    }
}
