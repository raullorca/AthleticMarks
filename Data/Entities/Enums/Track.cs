using System.ComponentModel;

namespace AthleticMarks.Data.Entities.Enums
{
    public enum Track
    {
        [Description("Pista coberta")]
        Indoor, // Pista cubierta

        [Description("Aire Lliure")]
        Outdoor // Aire Libre
    }
}