using Microsoft.AspNetCore.Mvc;
using SpeedBoxTest.CdekApi;
using SpeedBoxTest.Dtos;

namespace SpeedBoxTest.Controllers;

[ApiController]
[Route("/")]
public class PriceCalcController : ControllerBase
{
    private readonly ICdekService _cdekService;

    public PriceCalcController(ICdekService cdekService)
    {
        _cdekService = cdekService;
    }

    [HttpPost(Name = "GetPrice")]
    public async Task<PriceCalcOutDto> Post(PriceCalcInDto calcIn)
    {
        var fromTask = _cdekService.GetCodeByGuid(calcIn.From);
        var toTask = _cdekService.GetCodeByGuid(calcIn.To);
        var codes = await Task.WhenAll(fromTask, toTask);
        var (fromCode, toCode) = (codes[0], codes[1]);
        var price = await _cdekService.GetPrice(
            from: fromCode,
            to: toCode,
            weight: calcIn.Weight,
            length: calcIn.Length,
            width: calcIn.Width, 
            height: calcIn.Height);
        return new PriceCalcOutDto() { Price = price };
    }
}