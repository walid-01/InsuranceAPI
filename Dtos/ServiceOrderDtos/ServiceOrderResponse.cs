using InsuranceAPI.Dtos.ExpertDtos;
using InsuranceAPI.Dtos.ExpertiseReportDtos;
using InsuranceAPI.Dtos.InsuranceDtos;
using InsuranceAPI.Models;
using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ServiceOrderDtos
{
    public class ServiceOrderResponse
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public required String VictimFullName { get; set; }
        public required String VictimPolicyNumber { get; set; }
        public City VictimCity { get; set; }
        public required InsuranceJoinResponse? VictimInsurance { get; set; }
        public required String VehicleMakerAndModel { get; set; }
        public required String VehicleLicensePlate { get; set; }
        public required String VehicleType { get; set; }
        public required String VehicleSeriesNumber { get; set; }
        public required String VehicleGenre { get; set; }
        public required int VehicleWeight { get; set; }
        public String? AtFaultFullName { get; set; }
        public String? AtFaultPolicyNumber { get; set; }
        public City? AtFaultCity { get; set; }
        public InsuranceJoinResponse? AtFaultInsurance { get; set; }
        public required ExpertJoinResponse? AssociatedExpert { get; set; }
        public ExpertiseReportResponse? ExpertiseReport { get; set; }
    }
}