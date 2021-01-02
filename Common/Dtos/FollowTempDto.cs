using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
    public class FollowTempDto
    {
        public FollowTempDto()
        {
            this.connections = new List<ContactDto>();
        }
   
        public UserDto userDto { get; set; }
        public List<ContactDto> connections { get; set; }
    }
}
