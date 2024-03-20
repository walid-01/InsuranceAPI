using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ExpertDtos
{
    public class ExpertCreateRequest
    {
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public required String UserName { get; set; }
        public required String Password { get; set; }
        public required String PhoneNumber { get; set; }
        public required String Address { get; set; }= String.Empty;

        public required City City { get; set; }
    }
}