using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Resources
{
    public class SaveStateProvinceResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
