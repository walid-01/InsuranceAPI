using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceUpdateRequestDto
    {
        public required String Token { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Address { get; set; } = String.Empty;
        public required City City { get; set; }
        public required int AgencyCode { get; set; }
        public required String CurrentPassword { get; set; }
        public String? NewPassword { get; set; }

    }
}