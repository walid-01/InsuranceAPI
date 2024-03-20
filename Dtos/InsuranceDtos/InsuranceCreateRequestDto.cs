using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceCreateRequestDto
    {
        public String Name { get; set; }= String.Empty;
        public String Address { get; set; }= String.Empty;
        public City City { get; set; }
        public required String UserName { get; set; }
        public required String Password { get; set; }
        public required int AgencyCode { get; set; }
    }
}