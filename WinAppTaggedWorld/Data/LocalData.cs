using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Data
{
    public class LocalData
    {
        private readonly HashSet<Target> targets = new();
        public IEnumerable<Target> Targets => targets;

        private readonly HashSet<string> tags = new();
        public IEnumerable<string> Tags => tags;

        private static readonly LocalData localData = new();

        private LocalData() { }

        public static LocalData GetInstance()
        {
            return localData;
        }
    }
}
