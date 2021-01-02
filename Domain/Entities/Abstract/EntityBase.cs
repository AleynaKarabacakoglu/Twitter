using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Abstract
{
    public abstract class EntityBase
    {
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }


    }
}
