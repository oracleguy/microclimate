using ClimateApi.Core;

namespace ClimateApi.Tests.Core;

public class DateOperationsTests
{
    private readonly DateOperations subject = new();

    [Fact]
    public void PreviousFiveYears()
    {
        var result = subject.GetPreviousFiveYears(DateOnly.Parse("2025-01-01")).ToList();
        result.Should().HaveCount(4);
    }
}