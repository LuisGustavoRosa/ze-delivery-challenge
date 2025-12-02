using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ze_delivery_challenge.Application.Dtos;
using ze_delivery_challenge.Domain.Interfaces;

namespace ze_delivery_challenge.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PartnerController(IPartnerService partnerService) : Controller
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PartnerDto partnerDto)
    => Ok(await partnerService.Create(partnerDto));

    [HttpGet]
    public async Task<IActionResult> GetAll()
    => Ok(await partnerService.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    => Ok(await partnerService.GetById(id));

    [HttpPost("create_all")]
    public async Task<IActionResult> CreateAll([FromBody] List<PartnerDto> partnerDto)
    {
        await partnerService.CreateAll(partnerDto);
        return Created();
    }
    [HttpGet("nearest_partner")]
    public async Task<IActionResult> GetNearestPartner(double lon, double lat) => Ok(await partnerService.GetNearestPartner(lon, lat));

}
