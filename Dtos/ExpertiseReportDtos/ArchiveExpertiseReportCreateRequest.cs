using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Dtos.ExpertiseReportDtos
{
    public class ArchiveExpertiseReportCreateRequest
    {
        public required String token { get; set; }
        public required String Reference { get; set; }
        public required String Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public required String VehicleConditionBeforeIncident { get; set; }
        public required String ImpactPoint { get; set; }
        public required String DamagedPoint { get; set; }
        public int PaintAndAdditions { get; set; }
        public required String LaborDescription { get; set; }
        public decimal LaborCost { get; set; }
        public int Reduction { get; set; }
        public required String VictimFullName { get; set; }
        public required String VictimPolicyNumber { get; set; }
        public required String VictimInsuranceName { get; set; }= String.Empty;
        public required String VictimInsuranceAddress { get; set; }= String.Empty;
        public String? AtFaultFullName { get; set; }
        public String? AtFaultPolicyNumber { get; set; }
        public String? AtFaultInsuranceName { get; set; }= String.Empty;
        public String VictimInsuranceInsuranceAddress { get; set; }= String.Empty;
        public  required int VictimInsuranceCode { get; set; }
        public  required int ?AtFaultInsuranceCode { get; set; }
        public String? AtFaultInsuranceAddress { get; set; }= String.Empty;
        public List<DamagedPartCreateRequest> DamagedParts { get; set; } = new List<DamagedPartCreateRequest>();
    }
}