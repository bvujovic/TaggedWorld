using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaggedWorldLibrary
{
    /// <summary>
    /// Group - Target
    /// </summary>
    public class Sharing
    {
        public DateTime SharedDate { get; set; }

        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public Group Group { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public Target Target { get; set; }
        [ForeignKey(nameof(Target))]
        public int TargetId { get; set; }

        public override string ToString()
            => $"{Target} $ on {Group}";
    }
}
