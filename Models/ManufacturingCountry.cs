using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAgency.Models
{
    [Table("Manufacturing_Country")]
    public class ManufacuringCountry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int countryId { get; set; }

        
        public String countryName { get; set; }
    }
}
