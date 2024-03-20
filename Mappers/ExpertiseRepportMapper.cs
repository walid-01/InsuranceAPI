using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Dtos.ExpertiseReportDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Mappers
{
    public static class ExpertiseRepportMapper
    {
        public static ExpertiseReport FromExpertiseReportCreateRequestDto(this ExpertiseReportCreateRequest expertiseReportRequest)
        {
            return new ExpertiseReport
            {
                Reference = expertiseReportRequest.Reference,
                Incident = expertiseReportRequest.Incident,
                IncidentDate = expertiseReportRequest.IncidentDate,
                VehicleConditionBeforeIncident = expertiseReportRequest.VehicleConditionBeforeIncident,
                ImpactPoint = expertiseReportRequest.ImpactPoint,
                DamagedPoint = expertiseReportRequest.ImpactPoint,
                PaintAndAdditions = expertiseReportRequest.PaintAndAdditions,
                LaborDescription = expertiseReportRequest.LaborDescription,
                LaborCost = expertiseReportRequest.LaborCost,
                ServiceOrderId = expertiseReportRequest.ServiceOrderId,
            };
        }

        public static ExpertiseReportResponse ToExpertisReportResponseDto(this ExpertiseReport expertiseReportModel)
        {

            // if (expertiseReportModel is null)
            // {
            //     return null;
            // }

            List<DamagePartResponse> damagePartResponses = new List<DamagePartResponse>();
            foreach (DamagedPart damagedPart in expertiseReportModel.DamagedParts)
            {
                damagePartResponses.Add(damagedPart.ToDamagedPartResponse());
            }

            decimal damagePartTotalCostBeforeReduction = 0;
            foreach (DamagedPart damagedPart in expertiseReportModel.DamagedParts)
            {
                damagePartTotalCostBeforeReduction+=damagedPart.PartPrice;
            }

            decimal damagePartTotalPercentage = 0;
            foreach (DamagedPart damagedPart in expertiseReportModel.DamagedParts)
            {
                damagePartTotalPercentage+=damagedPart.Reduction;
            }

            decimal damagePartTotalReductionCost= damagePartTotalCostBeforeReduction*(damagePartTotalPercentage/100);

            decimal damagePartTotalCostAfterReduction = damagePartTotalCostBeforeReduction - damagePartTotalReductionCost;

            decimal total = damagePartTotalCostAfterReduction +expertiseReportModel.LaborCost+expertiseReportModel.PaintAndAdditions;

            return new ExpertiseReportResponse
            {
                Id = expertiseReportModel.Id,
                Reference = expertiseReportModel.Reference,
                State = expertiseReportModel.State,
                Incident = expertiseReportModel.Incident,
                IncidentDate = expertiseReportModel.IncidentDate,
                VehicleConditionBeforeIncident = expertiseReportModel.VehicleConditionBeforeIncident,
                ImpactPoint = expertiseReportModel.ImpactPoint,
                DamagedPoint = expertiseReportModel.ImpactPoint,
                PaintAndAdditions = expertiseReportModel.PaintAndAdditions,
                LaborDescription = expertiseReportModel.LaborDescription,
                LaborCost = expertiseReportModel.LaborCost,
                DamagePartTotalCostBeforeReduction = damagePartTotalCostBeforeReduction,
                DamagePartTotalCostAfterReduction = damagePartTotalCostAfterReduction,
                DamagePartTotalPercentage = damagePartTotalPercentage,
                DamagePartTotalReductionCost = damagePartTotalReductionCost,
                Total = total,
                DamagedParts = damagePartResponses
            };
        }
    }
}