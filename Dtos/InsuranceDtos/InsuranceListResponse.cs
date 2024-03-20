using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceListResponse
    {
        public int Id { get; set; }
        public String Name { get; set; }= String.Empty;
        public required int AgencyCode { get; set; }
    }
}