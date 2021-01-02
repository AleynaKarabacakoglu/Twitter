using Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Contact:EntityBase
    {
        
        [Key]
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int FollowerId { get; set; }

        [Key]
        [ForeignKey("User1")]
        [Column(Order = 2)]
        public int FollowingId { get; set; }

        public User User1 { get; set; }
        public User User { get; set; }


    }
}
