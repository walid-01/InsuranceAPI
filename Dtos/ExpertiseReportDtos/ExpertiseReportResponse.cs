using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Dtos.ExpertiseReportDtos
{
    public class ExpertiseReportResponse
    {
        public int Id { get; set; }
        public required String Reference { get; set; }
        public required ExpertiseReportState State { get; set; }= ExpertiseReportState.Waiting_Appeal;
        public required String Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public required String VehicleConditionBeforeIncident { get; set; }
        public required String ImpactPoint { get; set; }
        public required String DamagedPoint { get; set; }
        public int PaintAndAdditions { get; set; }
        public required String LaborDescription { get; set; }
        public Decimal LaborCost { get; set; }
        public required decimal DamagePartTotalCostBeforeReduction { get; set; }
        public required decimal DamagePartTotalPercentage { get; set; }
        public required decimal DamagePartTotalReductionCost { get; set; }
        public required decimal DamagePartTotalCostAfterReduction { get; set; }
        public required decimal Total { get; set; }

        public List<DamagePartResponse> DamagedParts { get; set; }= new List<DamagePartResponse>();
    }
}