using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Dtos.ExpertiseReportDtos
{
    public class ExpertiseReportCreateRequest
    {
        public String ExpertToken { get; set; } = String.Empty;
        public required String Reference { get; set; }
        public required String Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public required String VehicleConditionBeforeIncident { get; set; }
        public required String ImpactPoint { get; set; }
        public required String DamagedPoint { get; set; }
        public int PaintAndAdditions { get; set; }
        public required String LaborDescription { get; set; }
        public decimal LaborCost { get; set; }
        public int? ServiceOrderId { get; set; }
        public int Reduction { get; set; }
        public List<DamagedPartCreateRequest> DamagedParts { get; set; } = new List<DamagedPartCreateRequest>();
    }
}