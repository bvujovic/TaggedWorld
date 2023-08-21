using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;

namespace TaggedWorldLibrary.DTOs
{
    public class TargetDto : TargetDtoBase
    {
        public int TargetId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int OwnerId { get; set; }

        /// <summary></summary>
        protected void CopyToTarget(Target t)
        {
            t.TargetId = TargetId;
            t.CreatedDate = CreatedDate;
            t.UserOwnerId = OwnerId;
            t.Content = Content;
            t.Tags = Tags.ParseTags(StrTags).ToList();
        }

        public virtual Target ToTarget()
        {
            var t = new Target();
            CopyToTarget(t);
            return t;
            //B
            //return new Target
            //{
            //    TargetId = TargetId,
            //    CreatedDate = CreatedDate,
            //    UserOwnerId = OwnerId,
            //    Content = Content,
            //    Tags = Tags.ParseTags(StrTags).ToList(),
            //};
        }
    }
}
