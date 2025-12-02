using ze_delivery_challenge.Domain.Entities;

namespace ze_delivery_challenge.Domain.Interfaces;

public interface IPartnerRepository
{
    Task<int> Create(Entities.Partner partner);
    Task<List<Entities.Partner>> GetAll();
    Task<Partner?> GetById(int id);
    Task CreateAll(List<Partner> partner);

}
