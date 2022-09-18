using System;

namespace WorldUniversity.Data.Common.Models
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}