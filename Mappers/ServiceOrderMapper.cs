using InsuranceAPI.Dtos.ServiceOrderDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Mappers
{
    public static class ServiceOrderMapper
    {
        public static ServiceOrder FromCreateServiceOrderDto(this ServiceOrderCreateRequest serviceOrderRequest, int victimInsuranceID)
        {
            return new ServiceOrder
            {
                VictimFullName = serviceOrderRequest.VictimFullName,
                VictimPolicyNumber = serviceOrderRequest.VictimPolicyNumber,
                VictimCity = serviceOrderRequest.VictimCity,
                VehicleMakerAndModel = serviceOrderRequest.VehicleMakerAndModel,
                VehicleLicensePlate = serviceOrderRequest.VehicleLicensePlate,
                VehicleType = serviceOrderRequest.VehicleType,
                VehicleSeriesNumber = serviceOrderRequest.VehicleSeriesNumber,
                VehicleGenre = serviceOrderRequest.VehicleGenre,
                VehicleWeight = serviceOrderRequest.VehicleWeight,
                AtFaultFullName = serviceOrderRequest.AtFaultFullName,
                AtFaultPolicyNumber = serviceOrderRequest.AtFaultPolicyNumber,
                AtFaultCity = serviceOrderRequest.AtFaultCity,
                AssociatedExpertID = serviceOrderRequest.AssociatedExpertID,
                VictimInsuranceID = victimInsuranceID,
                AtFaultInsuranceID = serviceOrderRequest.AtFaultInsuranceID,
                AssociatedExpert = null,
                VictimInsurance = null,
                ExpertiseReport = null
            };
        }


        public static ServiceOrderResponse ToServiceOrderResponseDto(this ServiceOrder ServiceOrder)
        {
            return new ServiceOrderResponse
            {
                Id = ServiceOrder.Id,
                IssueDate= DateTime.Parse(ServiceOrder.IssueDate),
                VictimFullName= ServiceOrder.VictimFullName,
                VictimPolicyNumber= ServiceOrder.VictimPolicyNumber,
                VictimCity= ServiceOrder.VictimCity,
                VictimInsurance= ServiceOrder.VictimInsurance!.ToInsurnaceJoinResponceDto(),
                VehicleMakerAndModel= ServiceOrder.VehicleMakerAndModel,
                VehicleLicensePlate= ServiceOrder.VehicleLicensePlate,
                VehicleType= ServiceOrder.VehicleType,
                VehicleSeriesNumber= ServiceOrder.VehicleSeriesNumber,
                VehicleGenre= ServiceOrder.VehicleGenre,
                VehicleWeight= ServiceOrder.VehicleWeight,
                AtFaultFullName= ServiceOrder.AtFaultFullName,
                AtFaultPolicyNumber= ServiceOrder.AtFaultPolicyNumber,
                AtFaultCity= ServiceOrder.AtFaultCity,
                AtFaultInsurance= ServiceOrder.AtFaultInsurance!.ToInsurnaceJoinResponceDto(),
                AssociatedExpert= ServiceOrder.AssociatedExpert!.ToExpertJoinResponseDto(),
                ExpertiseReport = ServiceOrder.ExpertiseReport!.ToExpertisReportResponseDto()
            };
        }

    }
}