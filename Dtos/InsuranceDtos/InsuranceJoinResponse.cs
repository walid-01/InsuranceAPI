namespace InsuranceAPI.Dtos.InsuranceDtos
{
    public class InsuranceJoinResponse
    {
        public String Name { get; set; }= String.Empty;
        public required int AgencyCode { get; set; }
    }
}