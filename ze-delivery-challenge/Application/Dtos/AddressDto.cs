namespace ze_delivery_challenge.Application.Dtos;

public class AddressDto
{
    public string Type { get; set; } = string.Empty;
    public List<double> Coordinates { get; set; } = new();
}
