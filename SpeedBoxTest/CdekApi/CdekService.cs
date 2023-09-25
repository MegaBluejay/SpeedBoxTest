using UnitsNet;

namespace SpeedBoxTest.CdekApi;

public class CdekService : ICdekService
{
    public Task<CdekLocationCode> GetCodeByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetPrice(CdekLocationCode from, CdekLocationCode to, Mass weight, Length length, Length width, Length height)
    {
        throw new NotImplementedException();
    }
}