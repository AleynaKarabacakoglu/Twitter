using Domain.Entities.Abstract;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User:EntityBase
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public int FollowingCount { get; set; }
        public int FollowerCount { get; set; }
     
        public bool IsFollowing { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Image> Images { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<Retweet> Retweets { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public string ProfileImage { get; set; }


    }
}
