using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ExpertDtos
{
    public class ExpertListResponse
    {
        public int Id { get; set; }
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public required String Address { get; set; }= String.Empty;
        public required String PhoneNumber { get; set; }
        public required City City { get; set; }
    }
}