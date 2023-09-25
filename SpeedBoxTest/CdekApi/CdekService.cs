using UnitsNet;

namespace SpeedBoxTest.CdekApi;

public class CdekService : ICdekService
{
    public Task<CdekLocationCode> GetCodeByGuidAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetPriceAsync(CdekLocationCode from, CdekLocationCode to, Mass weight, Length length, Length width, Length height)
    {
        throw new NotImplementedException();
    }
}