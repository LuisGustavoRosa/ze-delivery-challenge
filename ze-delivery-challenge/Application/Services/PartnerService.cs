using GeoCoordinatePortable;
using ze_delivery_challenge.Application.Dtos;
using ze_delivery_challenge.Domain.Entities;
using ze_delivery_challenge.Domain.Interfaces;



namespace ze_delivery_challenge.Application.Services;

public class PartnerService(IPartnerRepository partnerRepository) : IPartnerService
{
    public Task<int> Create(PartnerDto partnerDto)
    {
        Domain.Entities.Partner partner = PartnerDto.ConvertFromEntity(partnerDto);
        return partnerRepository.Create(partner);
    }

    public async Task CreateAll(List<PartnerDto> partnerDtos)
    => await partnerRepository.CreateAll(partnerDtos.Select(PartnerDto.ConvertFromEntity).ToList());
   
    public async Task<List<PartnerDto>> GetAll()
    => (await partnerRepository.GetAll()).Select(PartnerDto.ConvertToEntity).ToList();

    public async Task<PartnerDto> GetById(int id)
    {
        var partnerBanco = await partnerRepository.GetById(id) ?? throw new KeyNotFoundException();
        return PartnerDto.ConvertToEntity(partnerBanco);
    }

    public async Task<PartnerDto?> GetNearestPartner(double lon, double lat)
    {
        var partners = await partnerRepository.GetAll();
        Partner? nearestPartner = null;
        double minDistance = double.MaxValue;

        foreach (var partner in partners)
        {
            if (partner.CoverageArea == null || partner.Address == null)
                continue;

            if (!IsPointInMultiPolygon(lon, lat, partner.CoverageArea.Coordinates))
                continue;

            var distance = GetDistance(
                lat, lon,
                partner.Address.Coordinates[1], partner.Address.Coordinates[0]
            );

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPartner = partner;
            }
        }

        return PartnerDto.ConvertToEntity(nearestPartner);
    }


    private bool IsPointInMultiPolygon(double lon, double lat, List<List<List<List<double>>>> multiPolygon)
    {
        foreach (var polygon in multiPolygon)
        {
            foreach (var ring in polygon)
            {
                if (IsPointInPolygon(lon, lat, ring))
                    return true;
            }
        }
        return false;
    }
    private bool IsPointInPolygon(double lon, double lat, List<List<double>> polygon)
    {
        bool inside = false;
        int j = polygon.Count - 1;
        for (int i = 0; i < polygon.Count; j = i++)
        {
            double xi = polygon[i][0], yi = polygon[i][1];
            double xj = polygon[j][0], yj = polygon[j][1];

            bool intersect = ((yi > lat) != (yj > lat)) &&
                             (lon < (xj - xi) * (lat - yi) / (yj - yi + double.Epsilon) + xi);
            if (intersect)
                inside = !inside;
        }
        return inside;
    }


    private double GetDistance(double lat1, double lon1, double lat2, double lon2)
    {
        var sCoord = new GeoCoordinate(lat1, lon1);
        var eCoord = new GeoCoordinate(lat2, lon2);
        return sCoord.GetDistanceTo(eCoord);
    }
}
