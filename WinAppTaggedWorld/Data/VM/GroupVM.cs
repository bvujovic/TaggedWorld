using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Data.VM
{
    /// <summary>Podaci o grupi korisnika sa dodatnim svojstvima za prikaz u tabeli forme FrmGroups.</summary>
    public class GroupVM : Group
    {
        /// <summary>Da li je ulogovani korisnik clan grupe.</summary>
        public bool AmIaMember { get; set; } = false;

        //B
        ///// <summary>Da li je ulogovani korisnik administrator grupe.</summary>
        //public bool Admin { get; set; }
    }
}
