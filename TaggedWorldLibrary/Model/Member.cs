using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaggedWorldLibrary.Model
{
    /// <summary>
    /// Clanstvo korisnika u grupi.
    /// </summary>
    public class Member
    {
        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public Group Group { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public bool IsAdministrator { get; set; } = false;

        public override string ToString()
             => $"{User} @ {Group}";
    }
}
