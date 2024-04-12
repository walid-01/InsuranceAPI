namespace InsuranceAPI.Dtos.DamagedPartDtos
{
    public class DamagePartResponse
    {
        public String? PartName { get; set; } = "Unknown part";
        public decimal PartPrice { get; set; }


        public required bool IsRepairable { get; set; }
    }
}