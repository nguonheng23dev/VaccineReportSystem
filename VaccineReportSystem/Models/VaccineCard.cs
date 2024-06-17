using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaccineReportSystem.Models
{
    public class VaccineCard
    {
        [Key]
        public int VaccineCardId { get; set; }

        [Required]
        public string CardType { get; set; } // MOH or MOD

        public ICollection<Visitor> Visitors { get; set; }
    }
}
