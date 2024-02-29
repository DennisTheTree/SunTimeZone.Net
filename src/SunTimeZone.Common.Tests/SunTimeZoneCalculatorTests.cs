namespace SunTimeZone.Common.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TimeZoneBasedOnDecimalDegree_OutOfRangeMinus180_ExpectException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => SunTimeZoneCalculator.TimeZoneBasedOnDecimalDegree(-180.001));
    }

    [TestMethod]
    public void TimeZoneBasedOnDecimalDegree_OutOfRange180_ExpectException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => SunTimeZoneCalculator.TimeZoneBasedOnDecimalDegree(180.001));
    }
}