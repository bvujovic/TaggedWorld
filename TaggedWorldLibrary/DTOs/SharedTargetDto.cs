using System;

namespace TaggedWorldLibrary.DTOs
{
    public class SharedTargetDto : TargetDto
    {
        /// <summary>Kada je podeljen target.</summary>
        public DateTime? SharedDate { get; set; }

        /// <summary>ID korisnika koji je poslao tj. podelio target.</summary>
        public int? UserSenderId { get; set; }

        /// <summary>ID grupe korisnika na kojoj je target podeljen.</summary>
        public int? SharedOnGroupId { get; set; }
    }
}
