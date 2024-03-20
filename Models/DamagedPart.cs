namespace InsuranceAPI.Models
{
    public class DamagedPart
    {
        public int Id { get; set; }
        public String? PartName { get; set; }
        public decimal PartPrice { get; set; }
        public int Reduction { get; set; }
        public int? ExpertiseReportID { get; set; }
        public ExpertiseReport? ExpertiseReport { get; set; }

    }
}