using Microsoft.EntityFrameworkCore;
using ze_delivery_challenge.Application.Dtos;
using ze_delivery_challenge.Domain.Entities;
using ze_delivery_challenge.Domain.Interfaces;

namespace ze_delivery_challenge.Infra.Repositories;

public class PartnerRepository(Context context) : IPartnerRepository
{
    public async Task<int> Create(Partner partner)
    {
        await context.Partners.AddAsync(partner);
        await context.SaveChangesAsync();

        return partner.Id;
    }

    public async Task CreateAll(List<Partner> partner)
    {
        await context.Partners.AddRangeAsync(partner);
        await context.SaveChangesAsync();
    }

    public async Task<List<Partner>> GetAll()
    => await context.Partners.ToListAsync();


    public async Task<Partner?> GetById(int id)
        => await context.Partners.FindAsync(id);
}
