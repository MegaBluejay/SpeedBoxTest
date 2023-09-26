using Flurl.Http;
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
    public async Task<IActionResult> Post(PriceCalcInDto calcIn)
    {
        try
        {
            var fromTask = _cdekService.GetCodeByGuidAsync(calcIn.From);
            var toTask = _cdekService.GetCodeByGuidAsync(calcIn.To);
            var codes = await Task.WhenAll(fromTask, toTask);
            var (fromCode, toCode) = (codes[0], codes[1]);
            var price = await _cdekService.GetPriceAsync(
                from: fromCode,
                to: toCode,
                weight: calcIn.Weight,
                length: calcIn.Length,
                width: calcIn.Width,
                height: calcIn.Height);
            return Ok(new PriceCalcOutDto { Price = price });
        }
        catch (LocationNotFoundException e)
        {
            return NotFound($"location {e.Guid} not found");
        }
        catch (FlurlHttpException)
        {
            return BadRequest("CDEK API Error");
        }
    }
}