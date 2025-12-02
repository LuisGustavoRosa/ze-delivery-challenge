using ze_delivery_challenge.Domain.Entities;

namespace ze_delivery_challenge.Application.Dtos;

public class PartnerDto
{
    public int id { get; set; }
    public string ownerName { get; set; } = string.Empty;
    public string tradingName { get; set; } = string.Empty;
    public string document { get; set; } = string.Empty;
    public CoverageAreaDto? coverageArea { get; set; }
    public AddressDto? address { get; set; }
    


    public static Partner ConvertFromEntity(PartnerDto partnerDto)
    {
        return new Partner
        {
            Address = partnerDto.address,
            CoverageArea = partnerDto.coverageArea,
            Document = partnerDto.document,
            OwnerName = partnerDto.ownerName, 
            TradingName = partnerDto.tradingName,
            
        };
    }

    public static PartnerDto ConvertToEntity(Partner? partner)
    {
        if (partner == null)
            return new();
        return new PartnerDto
        {
            id = partner.Id,
            address = partner.Address,
            coverageArea = partner.CoverageArea,
            document = partner.Document,
            ownerName = partner.OwnerName,
            tradingName = partner.TradingName,
            
        };
    }
}
