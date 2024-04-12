using InsuranceAPI.Dtos.DamagedPartDtos;
using InsuranceAPI.Models;

namespace InsuranceAPI.Mappers
{
    public static class DamagedPartMapper
    {
        public static DamagedPart FromDamagedPartCreateRequestDto(this DamagedPartCreateRequest damagedPartRequest)
        {
            return new DamagedPart
            {
                PartName = damagedPartRequest.PartName,
                PartPrice = damagedPartRequest.PartPrice,
                IsRepairable = damagedPartRequest.IsRepairable
            };
        }

        public static DamagePartResponse ToDamagedPartResponse(this DamagedPart damagedPart)
        {
            return new DamagePartResponse
            {
                PartName = damagedPart.PartName,
                PartPrice = damagedPart.PartPrice,
                IsRepairable = damagedPart.IsRepairable
            };
        }
    }
}