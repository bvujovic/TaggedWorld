using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaggedWorldLibrary.Model
{
    /// <summary>
    /// Group - Target
    /// </summary>
    public class Sharing
    {
        /// <summary>Kada je podeljen target.</summary>
        public DateTime SharedDate { get; set; }

        /// <summary>Korisnik koji je podelio target.</summary>
        public User User { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        /// <summary>Grupa korisnika na kojoj je target podeljen.</summary>
        public Group Group { get; set; }
        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        //TODO Mozda bi trebalo omoguciti da se target podeli direktno nekom korisniku, a ne samo preko grupe.
        // Videti da li bi User/UserId trebalo preimenovati (u npr UserSender)
        // a za Group/GroupId dozvoliti da bude null
        //public User? UserReceiver { get; set; }
        //[ForeignKey(nameof(UserReceiver))]
        //public int? UserReceiverId { get; set; }

        /// <summary>Target koji je podeljen.</summary>
        public Target Target { get; set; }
        [ForeignKey(nameof(Target))]
        public int TargetId { get; set; }

        public override string ToString()
            => $"{Target} $ on {Group}";
    }
}
