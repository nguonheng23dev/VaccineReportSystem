namespace VaccineReportSystem.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public ICollection<Visitor> Visitors { get; set; }
    }
}
