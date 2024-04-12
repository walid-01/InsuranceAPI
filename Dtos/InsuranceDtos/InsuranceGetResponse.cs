using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceGetResponse
    {
        public String Name { get; set; } = String.Empty;
        public String Role { get; set; } = "insurance";
        public String Address { get; set; } = String.Empty;
        public City City { get; set; }
        public required int AgencyCode { get; set; }
    }
}