using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
