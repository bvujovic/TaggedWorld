using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaggedWorldLibrary
{
    /// <summary>
    /// Korisnik aplikacije.
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = default!;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public bool IsActive { get; set; } = true;

        public List<Member> MemberOf { get; set; }

        public List<Target>? OwnedTargets { get; set; } = null;
        public List<Target>? ModifiedTargets { get; set; } = null;
        public List<Target>? AccessedTargets { get; set; } = null;

        public List<Sharing>? Sharings { get; set; }

        public override string ToString()
            => $"{FullName} ({Username})";
    }
}