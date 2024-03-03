using SunTimeZone.Common.Enums;

namespace SunTimeZone.Common;

public static class SunTimeZoneCalculator
{
    public static TimeSpan TimeZoneBasedOnDecimalDegree(double longitude)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(longitude, -180, nameof(longitude));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(longitude, 180, nameof(longitude));

        bool isNegative = longitude < 0;

        longitude = Math.Abs(longitude);
        var hour = Math.Truncate(longitude /15);
        var rem = Math.IEEERemainder(longitude, 15);
        var divider = 15/ rem;
        var mins = 60 / divider;
        var seconds = 60 * (mins - Math.Truncate(mins));
        var milliseconds = (seconds - Math.Truncate(seconds)) * 1000;
        var microseconds = (milliseconds - Math.Truncate(milliseconds)) * 1000;

        var TimeSpan = new TimeSpan(0, (int)hour, (int)Math.Truncate(mins), (int)Math.Truncate(seconds), (int)Math.Truncate(milliseconds), (int)Math.Truncate(microseconds));

        return isNegative ? TimeSpan.Negate() : TimeSpan;
    }

    public static TimeSpan TimeZoneBasedOnLongitude(string longitude, CoordinateFormat format)
    {
        var decimalDegree = CoordinateParser.longitude(longitude, format);
        return TimeZoneBasedOnDecimalDegree(decimalDegree);
    }
}
