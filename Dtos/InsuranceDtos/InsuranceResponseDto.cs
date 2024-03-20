using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceResponseDto
    {
        public required String Token { get; set; }

        public String Name { get; set; } = String.Empty;
        public String Address { get; set; } = String.Empty;
        public City City { get; set; }
        public required int AgencyCode { get; set; }

    
    }
}