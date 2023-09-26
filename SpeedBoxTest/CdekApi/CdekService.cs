using UnitsNet;
using Flurl.Http;
using SpeedBoxTest.CdekApi.Dtos;

namespace SpeedBoxTest.CdekApi;

public class CdekService : ICdekService
{
    private readonly IFlurlClient _client;

    public CdekService(IHttpClientFactory httpClientFactory)
    {
        _client = new FlurlClient(httpClientFactory.CreateClient(nameof(CdekService)));
    }

    public async Task<CdekLocationCode?> GetCodeByGuidAsync(Guid guid)
    {
        var response = await _client.Request("/location/cities")
            .SetQueryParam("fias_guid", guid)
            .GetJsonAsync<List<LocationInfoOutDto>>();
        var location = response.ElementAtOrDefault(0);
        if (location == null)
        {
            return null;
        }

        return new CdekLocationCode(location.Code);
    }

    public async Task<int> GetPriceAsync(CdekLocationCode from, CdekLocationCode to, Mass weight, Length length, Length width, Length height)
    {
        var request = new PriceCalcInDto
        {
            Type = 1,
            TariffCode = 139,
            From = new LocationInDto { Code = from.Code },
            To = new LocationInDto { Code = to.Code },
            Packages = new List<PackageInDto>
            {
                new PackageInDto
                {
                    Weight = weight,
                    Length = length,
                    Width = width,
                    Height = height,
                },
            }
        };
        var response = await _client.Request("/calculator/tariff")
            .PostJsonAsync(request)
            .ReceiveJson<PriceCalcOutDto>();
        return response.Price;
    }
}