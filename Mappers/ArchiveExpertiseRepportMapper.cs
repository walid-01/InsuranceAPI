using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Dtos.ExpertiseReportDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Mappers
{
    public static class ArchiveExpertiseRepportMapper
    {
        public static ArchiveExpertiseReport FromArchiveExpertiseReportCreateRequestDto(this ArchiveExpertiseReportCreateRequest expertiseReportRequest, string expertName)
        {
            return new ArchiveExpertiseReport
            {
                expartName = expertName,
                Reference = expertiseReportRequest.Reference,
                Incident = expertiseReportRequest.Incident,
                IncidentDate = expertiseReportRequest.IncidentDate,
                VehicleConditionBeforeIncident = expertiseReportRequest.VehicleConditionBeforeIncident,
                ImpactPoint = expertiseReportRequest.ImpactPoint,
                DamagedPoint = expertiseReportRequest.DamagedPoint,
                PaintAndAdditions = expertiseReportRequest.PaintAndAdditions,
                LaborDescription = expertiseReportRequest.LaborDescription,
                LaborCost = expertiseReportRequest.LaborCost,
                Reduction = expertiseReportRequest.Reduction,
                VictimFullName = expertiseReportRequest.VictimFullName,
                VictimPolicyNumber = expertiseReportRequest.VictimPolicyNumber,
                VictimInsuranceName = expertiseReportRequest.VictimInsuranceName,
                VictimInsuranceAddress = expertiseReportRequest.VictimInsuranceAddress,
                AtFaultFullName = expertiseReportRequest.AtFaultFullName,
                AtFaultPolicyNumber = expertiseReportRequest.AtFaultPolicyNumber,
                VictimInsuranceCode = expertiseReportRequest.VictimInsuranceCode,
                AtFaultInsuranceName = expertiseReportRequest.AtFaultInsuranceName,
                AtFaultInsuranceCode = expertiseReportRequest.AtFaultInsuranceCode,
                AtFaultInsuranceAddress = expertiseReportRequest.AtFaultInsuranceAddress,
                VehicleMakerAndModel = expertiseReportRequest.VehicleMakerAndModel,
                VehicleLicensePlate = expertiseReportRequest.VehicleLicensePlate,
                VehicleType = expertiseReportRequest.VehicleType,
                VehicleSeriesNumber = expertiseReportRequest.VehicleSeriesNumber,
                VehicleGenre = expertiseReportRequest.VehicleGenre,
                VehicleWeight = expertiseReportRequest.VehicleWeight,
            };
        }

        public static ArchiveExpertiseReport FromExpertiseReportCreateToArchiveRequestDto(this ExpertiseReport expertiseReportRequest)
        {
            if (expertiseReportRequest == null)
                return null;

            if (expertiseReportRequest.ServiceOrder.AtFaultInsurance is null)
            {
                return new ArchiveExpertiseReport
                {

                    Reference = expertiseReportRequest.Reference,
                    Incident = expertiseReportRequest.Incident,
                    IncidentDate = expertiseReportRequest.IncidentDate,
                    VehicleConditionBeforeIncident = expertiseReportRequest.VehicleConditionBeforeIncident,
                    ImpactPoint = expertiseReportRequest.ImpactPoint,
                    DamagedPoint = expertiseReportRequest.DamagedPoint,
                    PaintAndAdditions = expertiseReportRequest.PaintAndAdditions,
                    LaborDescription = expertiseReportRequest.LaborDescription,
                    LaborCost = expertiseReportRequest.LaborCost,
                    Reduction = expertiseReportRequest.Reduction,
                    VictimFullName = expertiseReportRequest.ServiceOrder.VictimFullName,
                    VictimPolicyNumber = expertiseReportRequest.ServiceOrder.VictimPolicyNumber,
                    VictimInsuranceName = expertiseReportRequest.ServiceOrder.VictimInsurance.Name,
                    VictimInsuranceAddress = expertiseReportRequest.ServiceOrder.VictimInsurance.Address,
                    AtFaultFullName = expertiseReportRequest.ServiceOrder.AtFaultFullName,
                    AtFaultPolicyNumber = expertiseReportRequest.ServiceOrder.AtFaultPolicyNumber,
                    VictimInsuranceCode = expertiseReportRequest.ServiceOrder.VictimInsurance.AgencyCode,
                    DamagedParts = expertiseReportRequest.DamagedParts,
                    expartName = expertiseReportRequest.ServiceOrder.AssociatedExpert.FirstName + "." + expertiseReportRequest.ServiceOrder.AssociatedExpert.FirstName,

                    VehicleMakerAndModel = expertiseReportRequest.ServiceOrder.VehicleMakerAndModel,
                    VehicleLicensePlate = expertiseReportRequest.ServiceOrder.VehicleLicensePlate,
                    VehicleType = expertiseReportRequest.ServiceOrder.VehicleType,
                    VehicleSeriesNumber = expertiseReportRequest.ServiceOrder.VehicleSeriesNumber,
                    VehicleGenre = expertiseReportRequest.ServiceOrder.VehicleGenre,
                    VehicleWeight = expertiseReportRequest.ServiceOrder.VehicleWeight,
                };
            }
            return new ArchiveExpertiseReport
            {
                Reference = expertiseReportRequest.Reference,
                Incident = expertiseReportRequest.Incident,
                IncidentDate = expertiseReportRequest.IncidentDate,
                VehicleConditionBeforeIncident = expertiseReportRequest.VehicleConditionBeforeIncident,
                ImpactPoint = expertiseReportRequest.ImpactPoint,
                DamagedPoint = expertiseReportRequest.DamagedPoint,
                PaintAndAdditions = expertiseReportRequest.PaintAndAdditions,
                LaborDescription = expertiseReportRequest.LaborDescription,
                LaborCost = expertiseReportRequest.LaborCost,
                Reduction = expertiseReportRequest.Reduction,
                VictimFullName = expertiseReportRequest.ServiceOrder.VictimFullName,
                VictimPolicyNumber = expertiseReportRequest.ServiceOrder.VictimPolicyNumber,
                VictimInsuranceName = expertiseReportRequest.ServiceOrder.VictimInsurance.Name,
                VictimInsuranceAddress = expertiseReportRequest.ServiceOrder.VictimInsurance.Address,
                AtFaultFullName = expertiseReportRequest.ServiceOrder.AtFaultFullName,
                AtFaultPolicyNumber = expertiseReportRequest.ServiceOrder.AtFaultPolicyNumber,
                AtFaultInsuranceName = expertiseReportRequest.ServiceOrder.AtFaultInsurance.Name,
                VictimInsuranceCode = expertiseReportRequest.ServiceOrder.VictimInsurance.AgencyCode,
                AtFaultInsuranceCode = expertiseReportRequest.ServiceOrder.AtFaultInsurance.AgencyCode,
                AtFaultInsuranceAddress = expertiseReportRequest.ServiceOrder.AtFaultInsurance.Address,
                DamagedParts = expertiseReportRequest.DamagedParts,
                expartName = expertiseReportRequest.ServiceOrder.AssociatedExpert.FirstName + "." + expertiseReportRequest.ServiceOrder.AssociatedExpert.FirstName,
                VehicleMakerAndModel = expertiseReportRequest.ServiceOrder.VehicleMakerAndModel,
                VehicleLicensePlate = expertiseReportRequest.ServiceOrder.VehicleLicensePlate,
                VehicleType = expertiseReportRequest.ServiceOrder.VehicleType,
                VehicleSeriesNumber = expertiseReportRequest.ServiceOrder.VehicleSeriesNumber,
                VehicleGenre = expertiseReportRequest.ServiceOrder.VehicleGenre,
                VehicleWeight = expertiseReportRequest.ServiceOrder.VehicleWeight,
            };
        }


        public static ArchiveExpertiseReportResponse ToArchiveExpertisReportResponseDto(this ArchiveExpertiseReport expertiseReportModel)
        {

            if (expertiseReportModel is null)
            {
                return null;
            }

            List<DamagePartResponse> damagePartResponses = new List<DamagePartResponse>();
            foreach (DamagedPart damagedPart in expertiseReportModel.DamagedParts)
            {
                damagePartResponses.Add(damagedPart.ToDamagedPartResponse());
            }

            decimal damagePartTotalCostBeforeReduction = 0;
            foreach (DamagedPart damagedPart in expertiseReportModel.DamagedParts)
            {
                damagePartTotalCostBeforeReduction += damagedPart.PartPrice;
            }



            decimal damagePartTotalReductionCost = damagePartTotalCostBeforeReduction * (expertiseReportModel.Reduction / 100);

            decimal damagePartTotalCostAfterReduction = damagePartTotalCostBeforeReduction - damagePartTotalReductionCost;

            decimal total = damagePartTotalCostAfterReduction + expertiseReportModel.LaborCost + expertiseReportModel.PaintAndAdditions;

            return new ArchiveExpertiseReportResponse
            {
                expertName = expertiseReportModel.expartName,
                Id = expertiseReportModel.ID,
                Reference = expertiseReportModel.Reference,
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
                DamagePartTotalReductionCost = damagePartTotalReductionCost,
                Total = total,
                DamagedParts = damagePartResponses,
                Reduction = expertiseReportModel.Reduction,
                VictimFullName = expertiseReportModel.VictimFullName,
                VictimInsuranceAddress = expertiseReportModel.VictimInsuranceAddress,
                VictimPolicyNumber = expertiseReportModel.VictimPolicyNumber,
                AtFaultFullName = expertiseReportModel.AtFaultFullName,
                AtFaultInsuranceName = expertiseReportModel.AtFaultInsuranceName,
                AtFaultPolicyNumber = expertiseReportModel.AtFaultPolicyNumber,
                VictimInsuranceCode = expertiseReportModel.VictimInsuranceCode,
                AtFaultInsuranceCode = expertiseReportModel.AtFaultInsuranceCode,
                AtFaultInsuranceAddress = expertiseReportModel.AtFaultInsuranceAddress,
                VehicleMakerAndModel= expertiseReportModel.VehicleMakerAndModel,
                VehicleLicensePlate= expertiseReportModel.VehicleLicensePlate,
                VehicleType= expertiseReportModel.VehicleType,
                VehicleSeriesNumber= expertiseReportModel.VehicleSeriesNumber,
                VehicleGenre= expertiseReportModel.VehicleGenre,
                VehicleWeight= expertiseReportModel.VehicleWeight,
            };
        }
    }
}