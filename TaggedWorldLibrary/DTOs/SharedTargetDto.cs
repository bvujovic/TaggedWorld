using System;
using TaggedWorldLibrary.Utils;

namespace TaggedWorldLibrary.DTOs
{
    public class SharedTargetDto : TargetDto
    {
        /// <summary>Kada je podeljen target.</summary>
        public DateTime? SharedDate { get; set; }

        /// <summary>ID korisnika koji je poslao tj. podelio target.</summary>
        public int? UserSenderId { get; set; }

        public string? UserSender { get; set; }

        /// <summary>ID grupe korisnika na kojoj je target podeljen.</summary>
        public int? SharedOnGroupId { get; set; }

        public string? SharedOnGroup { get; set; }

        public override SharedTarget ToTarget()
        {
            var t = new SharedTarget();
            CopyToTarget(t);
            t.SharedDate = SharedDate;
            t.UserSenderId = UserSenderId;
            t.ShareUserName = UserSender;
            t.SharedOnGroupId = SharedOnGroupId;
            t.ShareGroupName = SharedOnGroup;
            return t;
            //B
            //return new SharedTarget
            //{
            //    TargetId = TargetId,
            //    Tags = Tags.ParseTags(StrTags).ToList(),
            //    Content = Content,
            //};
        }
    }
}
