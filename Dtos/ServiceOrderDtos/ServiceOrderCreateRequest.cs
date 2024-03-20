using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ServiceOrderDtos
{
    public class ServiceOrderCreateRequest
    {
        public required String VictimFullName { get; set; }
        public required String VictimPolicyNumber { get; set; }
        public City VictimCity { get; set; }
        public required String VehicleMakerAndModel { get; set; }
        public required String VehicleLicensePlate { get; set; }
        public required String VehicleType { get; set; }
        public required String VehicleSeriesNumber { get; set; }
        public required String VehicleGenre { get; set; }
        public required int VehicleWeight { get; set; }
        public String? AtFaultFullName { get; set; }
        public String? AtFaultPolicyNumber { get; set; }
        public City? AtFaultCity { get; set; }
        public required int AssociatedExpertID { get; set; }
        public required String VictimInsuranceToken { get; set; }
        public int? AtFaultInsuranceID { get; set; }

    }
}