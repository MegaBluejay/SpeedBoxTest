namespace SpeedBoxTest.CdekApi;

public class LocationNotFoundException : Exception
{
    public Guid Guid { get; set; }
}