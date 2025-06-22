
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
}