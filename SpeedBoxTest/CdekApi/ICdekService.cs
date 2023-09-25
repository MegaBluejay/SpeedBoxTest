using UnitsNet;

namespace SpeedBoxTest.CdekApi;

public interface ICdekService
{
    Task<CdekLocationCode> GetCodeByGuid(Guid guid);

    Task<int> GetPrice(
        CdekLocationCode from,
        CdekLocationCode to,
        Mass weight,
        Length length,
        Length width,
        Length height
    );
}