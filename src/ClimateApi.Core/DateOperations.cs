
namespace ClimateApi.Core;

internal class DateOperations : IDateOperations
{
    public IEnumerable<DateOnly> GetPreviousFiveYears(DateOnly start)
    {
        var today = DateTime.Now;
        for (var c = -1; c > -5; c--)
        {
            yield return DateOnly.FromDateTime(today.AddYears(c));
        }
    }

    public DateOnly Today()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }

    public DateOnly Yesterday()
    {
        return DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
    }
}