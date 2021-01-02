using Domain.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Retweet:EntityBase
    {
       
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }

    }
}   