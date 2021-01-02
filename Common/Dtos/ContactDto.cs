using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    public class ContactDto
    {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
