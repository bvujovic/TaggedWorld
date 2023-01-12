namespace TaggedWorldLibrary.DTOs
{
    public class UserRegistrationReq : UserLoginReq
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
