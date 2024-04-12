namespace InsuranceAPI.Dtos.DamagedPartDtos
{
    public class DamagedPartCreateRequest
    {
        public String? PartName { get; set; }
        public decimal PartPrice { get; set; }

        public bool IsRepairable { get; set; }
    }
}