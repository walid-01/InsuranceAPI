using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceJoinResponse
    {
        public String Name { get; set; } = String.Empty;
        public required int AgencyCode { get; set; }

        public required String Address { get; set; }
        public required City City { get; set; }
    }
}