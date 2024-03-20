using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public String IssueDate { get; set; } = DateTime.Now.ToString();
        public required String VictimFullName { get; set; }
        public required String VictimPolicyNumber { get; set; }
        public required int VictimInsuranceID { get; set; }
        public required Insurance? VictimInsurance { get; set; }
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
        public int? AtFaultInsuranceID { get; set; }
        public Insurance? AtFaultInsurance { get; set; }
        public required int AssociatedExpertID { get; set; }
        public required Expert? AssociatedExpert { get; set; }
        public ExpertiseReport? ExpertiseReport { get; set; }
    }
}