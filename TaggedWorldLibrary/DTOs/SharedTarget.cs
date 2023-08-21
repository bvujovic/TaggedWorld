using System;

namespace TaggedWorldLibrary.DTOs
{
    /// <summary>
    /// Share-ovani tj. podeljeni target: svi podaci o targetu, grupa i korisnik koji je podelio target.
    /// </summary>
    public class SharedTarget : Model.Target
    {
        /// <summary>Grupa korisnika u okviru koje je target deljen.</summary>
        public string? ShareGroupName { get; set; }

        /// <summary>Korisnik koji je podelio target.</summary>
        public string? ShareUserName { get; set; }

        public Model.Target ToTarget()
        {
            //var t = new Model.Target();
            //return t;
            return new Model.Target
            {
                TargetId = TargetId,
                Content = Content,
                StrTags = StrTags,
                Tags = Tags,
                CreatedDate = CreatedDate,
                ModifiedDate = ModifiedDate,
                AccessedDate = AccessedDate,
                UserOwner = UserOwner,
                UserOwnerId = UserOwnerId,
                UserModified = UserModified,
                UserModifiedId = UserModifiedId,
                UserAccessed = UserAccessed,
                UserAccessedId = UserAccessedId,
                SharedDate = SharedDate,
                UserSender = UserSender,
                UserSenderId = UserSenderId,
                SharedOnGroup = SharedOnGroup,
                SharedOnGroupId = SharedOnGroupId,
                IsAccepted = IsAccepted,
            };
        }
    }
}
