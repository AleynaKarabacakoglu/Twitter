
using Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Like:EntityBase
    {
   
        public int PostId { get; set; }

        public int UserId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }

    }
}
