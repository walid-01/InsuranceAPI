namespace InsuranceAPI.Dtos.ExpertiseReportDtos
{
    public class ExpertiseReportAcceptRequest
    {
        public required String InsuranceToken { get; set; } = String.Empty;
        public required int ExpertiseReportID { get; set; }
    }
}