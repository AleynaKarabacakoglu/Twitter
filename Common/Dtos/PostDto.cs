using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CommentTo { get; set; }
        public bool IsDeleted { get; set; }
        public int ReplyCount { get; set; }
        public int RetweetCount { get; set; }
        public int LikeCount { get; set; }

    }
}
