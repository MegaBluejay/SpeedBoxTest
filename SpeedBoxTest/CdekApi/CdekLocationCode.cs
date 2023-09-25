namespace SpeedBoxTest.CdekApi;

public struct CdekLocationCode
{
    public int Code { get; private set; }

    public CdekLocationCode(int code) : this()
    {
        Code = code;
    }
}