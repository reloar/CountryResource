using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Entities
{
    public interface Audit
    {
        string CreatedBy { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdatedBy { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        string DeletedBy { get; set; }
    }
}
