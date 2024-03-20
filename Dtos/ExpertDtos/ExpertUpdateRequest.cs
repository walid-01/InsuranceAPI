namespace InsuranceAPI.Dtos.ExpertDtos
{
    public class ExpertUpdateRequest
    {
        public String Token { get; set; }= String.Empty;
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public required String Address { get; set; }= String.Empty;
        public required String PhoneNumber { get; set; }
        public required String CurrentPassword { get; set; }
        public required String NewPassword { get; set; }
    }
}