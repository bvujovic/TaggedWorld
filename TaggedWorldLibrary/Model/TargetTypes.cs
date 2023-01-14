using System;

namespace TaggedWorldLibrary.Model
{
    public static class TargetTypes
    {
        public static string File => nameof(File);
        // Mozda ce biti korisno
        //public static string WebDriveFile => nameof(WebDriveFile);
        //public static string OneDriveFile => nameof(OneDriveFile);
        public static string Folder => nameof(Folder);
        public static string Link => nameof(Link);
        public static string Doc => nameof(Doc);
    }
}
