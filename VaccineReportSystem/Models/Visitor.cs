using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaccineReportSystem.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Doses { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        public Province Province { get; set; }

        [Required]
        public int VaccineCardId { get; set; }

        [ForeignKey(nameof(VaccineCardId))]
        public VaccineCard VaccineCard { get; set; }
    }
}

