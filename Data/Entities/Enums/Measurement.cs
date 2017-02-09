using System.ComponentModel;

namespace AthleticMarks.Data.Entities.Enums
{
    public enum Measurement
    {
        [Description("Distància")]
        Distance,

        [Description("Temps")]
        Time,

        [Description("Punts")]
        Points
    }
}