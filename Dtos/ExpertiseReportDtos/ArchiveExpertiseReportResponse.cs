using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ExpertiseReportDtos
{
    public class ArchiveExpertiseReportResponse
    {
        public int Id { get; set; }
        public required String expertName { get; set; }
        public required String Reference { get; set; }
        public required String Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public required String VehicleConditionBeforeIncident { get; set; }
        public required String ImpactPoint { get; set; }
        public required String DamagedPoint { get; set; }
        public int PaintAndAdditions { get; set; }
        public required String LaborDescription { get; set; }
        public decimal LaborCost { get; set; }
        public required decimal DamagePartTotalCostBeforeReduction { get; set; }
        public required decimal Reduction { get; set; }
        public required decimal DamagePartTotalReductionCost { get; set; }
        public required decimal DamagePartTotalCostAfterReduction { get; set; }
        public required decimal Total { get; set; }
        public required String VictimFullName { get; set; }
        public required String VictimPolicyNumber { get; set; }
        public String VictimInsuranceName { get; set; } = String.Empty;
        public String VictimInsuranceAddress { get; set; } = String.Empty;
        public required int VictimInsuranceCode { get; set; }
        public String? AtFaultPolicyNumber { get; set; }
        public String? AtFaultFullName { get; set; }
        public String? AtFaultInsuranceName { get; set; }
        public int? AtFaultInsuranceCode { get; set; }
        public String AtFaultInsuranceAddress { get; set; } = String.Empty;
        public List<DamagePartResponse> DamagedParts { get; set; } = new List<DamagePartResponse>();
    }
}