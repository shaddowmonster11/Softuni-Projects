using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldUniversity.Models.Entities
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
    }
}
