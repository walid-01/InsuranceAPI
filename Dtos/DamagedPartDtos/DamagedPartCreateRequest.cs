namespace InsuranceAPI.Dtos.DamagedPartDtos
{
    public class DamagedPartCreateRequest
    {
        public String PartName { get; set; }="Unknown part";
        public decimal PartPrice { get; set; }
        public int Reduction { get; set; }
        public int? ExpertiseReportID { get; set; }
    }
}