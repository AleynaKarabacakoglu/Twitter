using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Concrete
{
    public class Image:EntityBase
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] ProfilImg { get; set; }
        public byte[] BgImg { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public string path { get; set; }

    }
}
