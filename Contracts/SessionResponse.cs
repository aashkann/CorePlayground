namespace Playground.Contracts;

public class SessionResponse
{
    public long Id { get; set; } // Assuming 'Id' is the primary key and is included in responses
    public string User { get; set; }
    public double Duration { get; set; }
    public long AreaInteractions { get; set; }
    public double AreaDuration { get; set; }
    public long SunlightInteractions { get; set; }
    public double SunlightDuration { get; set; }
    public string FilePath { get; set; }

    // If you have a timestamp in your database that records the creation time, add it here
    // public DateTime CreatedAt { get; set; }
}
