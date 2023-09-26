using UnitsNet;

namespace SpeedBoxTest.CdekApi;

public interface ICdekService
{
    Task<CdekLocationCode?> GetCodeByGuidAsync(Guid guid);

    Task<int> GetPriceAsync(
        CdekLocationCode from,
        CdekLocationCode to,
        Mass weight,
        Length length,
        Length width,
        Length height
    );
}