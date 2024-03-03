using System.ComponentModel;

namespace SunTimeZone.Common.Enums
{
    public enum CoordinateFormat
    {
        [Description("None")]
        None = 0,

        [Description("Decimal Degrees")]
        DD = 1,

        [Description("Decimal Degree Seconds")]
        DDS = 2,

        [Description("Degree Minute Seconds")]
        DMS = 3,
    }
}