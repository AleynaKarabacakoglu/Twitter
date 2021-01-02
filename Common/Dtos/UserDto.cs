using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int FollowingCount { get; set; }
        public int FollowerCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsFollowing { get; set; }
        public ICollection<PostDto> usePosts { get; set; }
        public string ProfileImage { get; set; }
    }
}
