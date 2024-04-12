using InsuranceAPI.Models.Enums;

namespace InsuranceAPI.Models
{
    public class ExpertiseReport
    {
        public int Id { get; set; }
        public required String Reference { get; set; }
        public required String Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public required String VehicleConditionBeforeIncident { get; set; }
        public required String ImpactPoint { get; set; }
        public required String DamagedPoint { get; set; }
        public int PaintAndAdditions { get; set; }
        public ExpertiseReportState State { get; set; } = ExpertiseReportState.Waiting;
        public required String LaborDescription { get; set; }
        public decimal LaborCost { get; set; }
        public int? ServiceOrderId { get; set; }
        public ServiceOrder? ServiceOrder { get; set; }
        public List<DamagedPart> DamagedParts { get; set; } = new List<DamagedPart>();
        public decimal Reduction { get; set; }

    }
}