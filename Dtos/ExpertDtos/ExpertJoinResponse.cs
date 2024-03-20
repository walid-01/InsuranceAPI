namespace InsuranceAPI.Dtos.ExpertDtos
{
    public class ExpertJoinResponse
    {
        public required String FirstName { get; set; }
        public required String LastName { get; set; }
        public required String Address { get; set; }= String.Empty;
        public required String PhoneNumber { get; set; }
    }
}