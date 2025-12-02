using ze_delivery_challenge.Application.Dtos;

namespace ze_delivery_challenge.Domain.Interfaces;

public interface IPartnerService
{
    Task<int> Create(PartnerDto partnerDto);
    Task<List<PartnerDto>> GetAll();
    Task<PartnerDto> GetById(int id);
    Task CreateAll(List<PartnerDto> partnerDtos);
    Task<PartnerDto?> GetNearestPartner(double lon, double lat);
}
