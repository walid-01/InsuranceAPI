using InsuranceAPI.Dtos.InsuranceDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Mappers
{
    public static class InsuranceMapper
    {
        public static InsuranceResponseDto ToResponseInsuranceDto(this Insurance insuranceModel, String token)
        {
            return new InsuranceResponseDto
            {
                Token = token,
                Name = insuranceModel.Name,
                AgencyCode = insuranceModel.AgencyCode,
                Address = insuranceModel.Address,
                City = insuranceModel.City,
            };
        }


        public static Insurance FromCreateRequestDto(this InsuranceCreateRequestDto? insuranceRequest)
        {
            return new Insurance
            {
                Name = insuranceRequest.Name,
                AgencyCode = insuranceRequest.AgencyCode,
                Address = insuranceRequest.Address,
                City = insuranceRequest.City,
                UserName = insuranceRequest.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(insuranceRequest.Password)
            };
        }

        public static InsuranceListResponse ToInsurnaceListResponceDto(this Insurance insurance)
        {
            if (insurance is null)
                return null;
            return new InsuranceListResponse
            {
                Id = insurance.Id,
                Name= insurance.Name,
                AgencyCode = insurance.AgencyCode
            };
        }

        public static InsuranceJoinResponse ToInsurnaceJoinResponceDto(this Insurance insurance)
        {
            if (insurance is null)
                return null;
            return new InsuranceJoinResponse
            {
                Name= insurance.Name,
                AgencyCode = insurance.AgencyCode
            };
        }

    }
}