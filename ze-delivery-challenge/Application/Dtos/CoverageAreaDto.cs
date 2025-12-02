namespace ze_delivery_challenge.Application.Dtos;

public class CoverageAreaDto
{
    public string Type { get; set; } = string.Empty;
    public List<List<List<List<double>>>> Coordinates { get; set; } = new();
}
