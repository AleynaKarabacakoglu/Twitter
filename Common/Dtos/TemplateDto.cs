using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    public class TemplateDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public int FollowingCount { get; set; }
        public int FollowerCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int ReplyCount { get; set; }
        public int RetweetCount { get; set; }
        public int LikeCount { get; set; }

        public int PostId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProfilImage { get; set; }
    }
}
