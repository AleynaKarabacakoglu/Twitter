using Domain.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Post:EntityBase
    {
        [Key]
        public int PostId { get; set; }

        public int UserId { get; set; }
        public string Text { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Post2")]
        public int? CommentTo { get; set; }

        public Post Post2 { get; set; }

        public bool? IsDeleted { get; set; }
        public int? ReplyCount { get; set; }
        public int? RetweetCount { get; set; }
        public int? LikeCount { get; set; }

        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Retweet> Retweets { get; set; }





    }
}
