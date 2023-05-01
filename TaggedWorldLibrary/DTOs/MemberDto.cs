using System;

namespace TaggedWorldLibrary.DTOs
{
    /// <summary>Prenos podataka o clanstvu korisnika u grupi.</summary>
    public class MemberDto
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
