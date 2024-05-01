namespace CorePlayground.Contracts;

public class CreateSessionRequest
{
    public string User { get; set; }
    public double Duration { get; set; }
    public long AreaInteractions { get; set; } // Assuming the corrected type from your schema
    public double AreaDuration { get; set; }
    public long SunlightInteractions { get; set; } // Assuming the corrected type from your schema
    public double SunlightDuration { get; set; }
    public string FilePath { get; set; }
}
