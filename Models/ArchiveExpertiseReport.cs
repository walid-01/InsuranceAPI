using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI
{
    public class ArchiveExpertiseReport
    {
        public int ID { get; set; }
        public required String expartName { get; set; }
        public  String Reference { get; set; }
        public  String Incident { get; set; }
        public DateTime IncidentDate { get; set; }
        public  String VehicleConditionBeforeIncident { get; set; }
        public  String ImpactPoint { get; set; }
        public  String DamagedPoint { get; set; }
        public int PaintAndAdditions { get; set; }
        public  String LaborDescription { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Reduction { get; set; }
        public  String VictimFullName { get; set; }
        public  String VictimPolicyNumber { get; set; }
        public String VictimInsuranceName { get; set; }= String.Empty;
        public   int VictimInsuranceCode { get; set; }
        public String VictimInsuranceAddress { get; set; }= String.Empty;
        public String? AtFaultFullName { get; set; }
        public String? AtFaultPolicyNumber { get; set; }
        public String? AtFaultInsuranceName { get; set; }
        public  int? AtFaultInsuranceCode { get; set; }
        public String? AtFaultInsuranceAddress { get; set; }
        public List<DamagedPart> DamagedParts { get; set; } = new List<DamagedPart>();
    }
}