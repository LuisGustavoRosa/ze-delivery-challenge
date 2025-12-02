using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using ze_delivery_challenge.Application.Dtos;

namespace ze_delivery_challenge.Domain.Entities;

public class Partner
{
    [Key]
    public int Id { get; set; }
    public string TradingName { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string CoverageAreaJson { get; set; } = string.Empty;
    public string AddressJson { get; set; } = string.Empty;

    [NotMapped]
    public CoverageAreaDto CoverageArea
    {
        get => JsonSerializer.Deserialize<CoverageAreaDto>(CoverageAreaJson);
        set => CoverageAreaJson = JsonSerializer.Serialize(value);
    }

    [NotMapped]
    public AddressDto Address
    {
        get => JsonSerializer.Deserialize<AddressDto>(AddressJson);
        set => AddressJson = JsonSerializer.Serialize(value);
    }
}
