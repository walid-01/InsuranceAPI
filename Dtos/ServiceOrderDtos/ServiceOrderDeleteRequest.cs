namespace InsuranceAPI.Dtos.ServiceOrderDtos
{
    public class ServiceOrderDeleteRequest
    {
        public required int ServiceOrderId { get; set; }
        public required String InsuranceToken { get; set; }
    }
}