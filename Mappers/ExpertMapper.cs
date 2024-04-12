using InsuranceAPI.Dtos.ExpertDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Mappers
{
    public static class ExpertMapper
    {
        public static ExpertResponse ToResponseExpertDto(this Expert expertModel, String token)
        {
            return new ExpertResponse
            {
                Token = token,
                FirstName = expertModel.FirstName,
                LastName = expertModel.LastName,
                PhoneNumber = expertModel.PhoneNumber,
                Address = expertModel.Address,
                City = expertModel.City
            };
        }

        public static ExpertGetResponse ToGetResponseExpertDto(this Expert expertModel, String token)
        {
            return new ExpertGetResponse
            {
                FirstName = expertModel.FirstName,
                LastName = expertModel.LastName,
                PhoneNumber = expertModel.PhoneNumber,
                Address = expertModel.Address,
                City = expertModel.City
            };
        }


        public static Expert FromCreateRequestDto(this ExpertCreateRequest expertRequest)
        {
            return new Expert
            {
                FirstName = expertRequest.FirstName,
                LastName = expertRequest.LastName,
                Address = expertRequest.Address,
                PhoneNumber = expertRequest.PhoneNumber,
                UserName = expertRequest.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(expertRequest.Password),
                City = expertRequest.City
            };
        }

        public static ExpertListResponse ToExpertListResponseDto(this Expert expertModel)
        {
            return new ExpertListResponse
            {
                Id = expertModel.Id,
                FirstName = expertModel.FirstName,
                LastName = expertModel.LastName,
                Address = expertModel.Address,
                PhoneNumber = expertModel.PhoneNumber,
                City = expertModel.City
            };
        }

        public static ExpertJoinResponse ToExpertJoinResponseDto(this Expert expertModel)
        {
            return new ExpertJoinResponse
            {
                FirstName = expertModel.FirstName,
                LastName = expertModel.LastName,
                Address = expertModel.Address,
                PhoneNumber = expertModel.PhoneNumber
            };
        }

    }
}