using Postgrest.Attributes;
using Postgrest.Models;

namespace CorePlayground.Models;

[Table("sessions")]
public class Session : BaseModel
{
    [PrimaryKey("Id", false)]
    public long Id { get; set; } // Changed from int to long

    [Column("User")]
    public string User { get; set; }

    [Column("Duration")]
    public double Duration { get; set; }

    [Column("AreaInteractions")] // Name corrected as per schema (verify correct column name in your database)
    public long AreaInteractions { get; set; } // Changed from int to long

    [Column("AreaDuration")]
    public double AreaDuration { get; set; }

    [Column("SunlightInteractions")] // Name corrected as per schema (verify correct column name in your database)
    public long SunlightInteractions { get; set; } // Changed from int to long

    [Column("SunlightDuration")] // Verify correct column name in your database
    public double SunlightDuration { get; set; }

    [Column("FilePath")]
    public string FilePath { get; set; }
}