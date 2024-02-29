using System.ComponentModel;

namespace SunTimeZone.Common.Enums
{
    public enum CoordinateFormat
    {
        [Description("None")]
        None = 0,

        [Description("Decimal Degree")]
        DD = 1,

        [Description("Decimal Degree Second")]
        DDS = 2,

        [Description("Degree Minute Second")]
        DMS = 3,
    }
}